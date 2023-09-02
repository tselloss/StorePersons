pipeline {
  agent any
  stages {  
    stage('SonarScanner') {
      steps {
        withSonarQubeEnv(installationName: 'sonarscannermsbuild', credentialsId: 'PersonsSonar') {
          dotnetBuild(project: 'PersonDatabase.sln', sdk: '.Net6')
        }         
          timeout(time: 1, unit: 'HOURS') {
            waitForQualityGate abortPipeline: true
          }
      }
    }

  }
}


