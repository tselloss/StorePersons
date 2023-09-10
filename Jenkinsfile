pipeline {
    agent any
    stages {
        stage('Git Checkout') {
            steps {
                git(url: 'https://github.com/tselloss/StorePersons.git', branch: 'main', credentialsId: 'Jenkins_authorization')
            }
        }
        stage('Clean') {
            steps {                
                dotnetClean(continueOnError: true, project: 'PersonDatabase.sln', sdk: '.Net6')         
            }
        }
           stage('Restore') {
            steps {                           
                dotnetRestore(continueOnError: true, project: 'PersonDatabase.sln', sdk: '.Net6')
            }
        }
           stage('Build') {
            steps {                
                dotnetBuild(continueOnError: true, project: 'PersonDatabase.sln', sdk: '.Net6')
            }
        }
           stage('Publish') {
            steps {                
                dotnetPublish(continueOnError: true, project: 'PersonDatabase.sln', sdk: '.Net6')
            }
        }
        stage('SonarQube') {
            steps {
                withSonarQubeEnv(installationName: 'server-sonar', credentialsId: 'gene-token') {                    
                     sh' dotnet sonarscanner begin /k:"PersonsDatabase" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="squ_7769ef3b9086b36be1acb25e1d8ee6d2aedd40f4"'
                     sh' dotnet build PersonsDatabase.sln'
                     sh' dotnet sonarscanner end /d:sonar.login="squ_7769ef3b9086b36be1acb25e1d8ee6d2aedd40f4"'
                }
            }
        }
    }
}

