pipeline {
  agent any
  stages {
    stage('Verify Branch') {
      steps {
        echo "$GIT_BRANCH"
      }
    }

    stage('Restore') {
      steps {
        sh '''

dotnet restore'''
      }
    }

    stage('Build') {
      steps {
        sh 'dotnet build'
      }
    }

  }
}