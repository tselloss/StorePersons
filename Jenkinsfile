pipeline {
  agent any
  stages {
    stage('Git Checkout') {
      steps {
        git(url: 'https://github.com/tselloss/StorePersons.git', branch: 'main', credentialsId: 'Jenkins_authorization')
      }
    }
stage('SonarQube') {
        environment { 
                MSBUILD_SQ_SCANNER_HOME = tool name: 'sq1'
            }
         withSonarQubeEnv(installationName: 'sq1', credentialsId: 'sonarqube-10.1') {
          dotnetBuild(sdk: '.Net6', project: 'PersonsDatabase.sln')
        }
    } 
   
    } 
  }










