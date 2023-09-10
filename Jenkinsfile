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
            withSonarQubeEnv(installationName: 'sonarqube-10.1', credentialsId: 'PToken') {
                    dotnetBuild(sdk: '.Net6', project: 'PersonsDatabase')
                 }            
            }
        }
    } 
  }
