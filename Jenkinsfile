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
      def scannerHome = tool 'sonarqube-10.1'
        steps{            
            withSonarQubeEnv(installationName: 'sonarqube-10.1', credentialsId: 'PToken') {
                    bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll begin /k:\"PersonsDatabase\""
                    dotnetBuild(continueOnError: true, project: 'PersonDatabase.sln', sdk: '.Net6')
                    bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll end"      
                 }            
            }
        }
    } 
  }
