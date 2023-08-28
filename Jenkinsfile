pipeline {
  agent any
  stages {
    stage('Verify Branch') {
      parallel {
        stage('Verify Branch') {
          steps {
            echo "$GIT_BRANCH"
          }
        }

        stage('Clean') {
          steps {
            sh '''
    cleanWs()
 '''
          }
        }

      }
    }

    stage('Restore') {
      steps {
        sh 'dotnet ef build'
      }
    }

  }
}