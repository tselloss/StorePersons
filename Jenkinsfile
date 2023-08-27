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
        sh 'dotnet ef build'
      }
    }

  }
}