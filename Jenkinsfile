pipeline {
    agent any
    
    stages {
        stage('SCM') {
            steps {
                checkout scm
            }
        }
        
        stage('Build') {
            steps {
                sh 'mvn clean package'
            }
        }
        
        stage('SonarQube analysis') {
            steps {
                script {
                    withSonarQubeEnv('sonarqube-8.9') {
                        sh "mvn sonar:sonar"
                    }
                }
            }
        }
    }
}
