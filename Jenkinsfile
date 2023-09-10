pipeline {
  agent any
  stages {
    stage('Git Checkout') {
      steps {
        git(url: 'https://github.com/tselloss/StorePersons.git', branch: 'main')
      }
    }
    stage('Build') {
      steps {
        dotnetBuild(continueOnError: true, project: 'PersonDatabase.sln', sdk: '.Net6')
      }
    }

  }
}
