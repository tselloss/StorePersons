pipeline {
    agent any
    stages {
        stage('Git Checkout') {
            steps {
                git(url: 'https://github.com/tselloss/StorePersons.git', branch: 'main', credentialsId: 'Jenkins_authorization')
            }
        }
        stage('Build') {
            steps {	
               sh 'dotnet clean var/jenkins_home/workspace/Pipe/PersonsDatabase.sln'                          
               sh 'dotnet restore var/jenkins_home/workspace/Pipe/PersonsDatabase.sln'                          
               sh 'dotnet build var/jenkins_home/workspace/Pipe/PersonsDatabase.sln'                          
            }
        }
        stage('SonarQube') {
            steps {
                withSonarQubeEnv(installationName: 'server-sonar', credentialsId: 'gene-token') {
                }
            }
        }
    }
}
