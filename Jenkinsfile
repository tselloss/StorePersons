pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        dotnetBuild(continueOnError: true, framework: 'Net 6.', project: 'PersonDatabase.sln', sdk: '.Net6')
      }
    }

  }
}