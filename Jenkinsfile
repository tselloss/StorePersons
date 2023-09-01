pipeline {
  agent any
  stages {
    stage('SonarScanner') {
      steps {
        withSonarQubeEnv(installationName: 'SonarQubeScanner', envOnly: true, credentialsId: 'PersonsSonar') {
          dotnetBuild(project: 'PersonDatabase.sln', sdk: '.Net6')
        }

      }
    }

  }
}
