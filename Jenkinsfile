pipeline {
  agent any
  stages {
    stage('Verify') {
      steps {
        sh 'echo "$GIT_BRANCH"'
      }
    }

    stage('Build') {
      steps {
        dotnetBuild(project: 'PersonDatabase.sln', sdk: '.Net6')
      }
    }

  }
}