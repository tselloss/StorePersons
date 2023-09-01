pipeline {
  agent any
  stages {
    stage('SonarScanner') {
      steps {
        withSonarQubeEnv(installationName: 'SonarQubeScanner', credentialsId: 'PersonsSonar') {
        }
        waitForQualityGate(webhookSecretId: 'Jenkins', credentialsId: 'SonarQubeScanner', abortPipeline: true)
      }
    }

  }
}
