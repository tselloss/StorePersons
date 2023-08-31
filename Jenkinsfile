pipeline {
  agent any
  stages {
    stage('Verify') {
      steps {
        sh 'echo "$GIT_BRANCH"'
      }
    }

    stage('Sonarqube') {
      steps {
        waitForQualityGate(abortPipeline: true, credentialsId: 'squ_4939c0eee0c7f961b9dcfd7faf1784d999a9684f')
      }
    }

    stage('Build') {
      steps {
        dotnetBuild(project: 'PersonDatabase.sln', sdk: '.Net6')
      }
    }

  }
}