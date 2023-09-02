pipeline {
  agent any
  stages {    
    stage('SCM') {
        git 'https://github.com/tselloss/StorePersons.git'
      }
    stage('SonarScanner') {
      steps {
        withSonarQubeEnv(installationName: 'sq1', credentialsId: 'PersonsSonar') {
          dotnetBuild(project: 'PersonDatabase.sln', sdk: '.Net6')
        }         
          timeout(time: 1, unit: 'HOURS') {
            waitForQualityGate abortPipeline: true
          }
      }
    }

  }
}


