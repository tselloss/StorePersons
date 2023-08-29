pipeline {
  agent any
  stages {
    stage('Clean Project') {
      steps {
        dotnetClean()
      }
    }

    stage('CreateNuget') {
      steps {
        dotnetPack(continueOnError: true)
      }
    }

    stage('Build') {
      steps {
        dotnetBuild()
      }
    }

  }
}