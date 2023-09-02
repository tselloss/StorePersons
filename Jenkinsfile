pipeline {
  agent any
  stages {
    stage('SonarScanner') {
      steps {
        withSonarQubeEnv(installationName: 'SonarQubeScanner', credentialsId: 'PersonsSonar') {
        }         
          timeout(time: 1, unit: 'HOURS') {
            waitForQualityGate abortPipeline: true
          }
      }
    }

  }
}
