pipeline {
  agent any
  stages {
    stage('Git Checkout') {
      steps {
        git(url: 'https://github.com/tselloss/StorePersons.git', branch: 'main')
      }
    }
    stage('Nugets') {
      steps {
        dotnetPack(continueOnError: true, project: 'PersonsDatabase', sdk: '.Net6')
      }
    }
    stage('Build') {
      steps {
        dotnetBuild(continueOnError: true, project: 'PersonDatabase.sln', sdk: '.Net6')
      }
    }

  }
}
