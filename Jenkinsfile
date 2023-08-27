pipeline {
  agent any
  stages {
    stage('Verify Branch') {
      steps {
        echo "$GIT_BRANCH"
      }
    }

    stage('Build') {
      steps {
        sh '''

dotnet build'''
      }
    }

    stage('End') {
      steps {
        sh 'exit'
      }
    }

  }
}