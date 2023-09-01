pipeline {
  agent any
  stages {
    stage('SonarScanner') {
      steps {
        withSonarQubeEnv(installationName: 'sonarqube', envOnly: true)
      }
    }

  }
}