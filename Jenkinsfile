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
        dotnetBuild(continueOnError: true, project: 'PersonDatabase.sln', sdk: '.Net6')
      }
    }
    stage('SonarQube') {
        steps{            
            withSonarQubeEnv(installationName: 'server-sonar', credentialsId: 'gene-token') {
                    dotnetBuild(continueOnError: true, project: 'PersonDatabase.sln', sdk: '.Net6')  
                 }            
            }
        }
    } 
  }
