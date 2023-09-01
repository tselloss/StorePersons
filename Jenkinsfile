pipeline {
  agent any
  stages {
    stage('SonarScanner') {
      steps {
        withSonarQubeEnv(installationName: 'SonarQubeScanner', envOnly: true, credentialsId: 'PersonsSonar') {
        }
        waitForQualityGate(webhookSecretId: 'Jenkins', credentialsId: 'SonarQubeScanner', abortPipeline: true)
      }
    }

  }
}
