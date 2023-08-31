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
        withSonarQubeEnv(installationName: 'Persons', credentialsId: 'squ_4939c0eee0c7f961b9dcfd7faf1784d999a9684f') {
          dotnetBuild(project: 'PersonDatabase.sln', sdk: '.Net6')
        }

      }
    }

    stage('Build') {
      steps {
        dotnetBuild(project: 'PersonDatabase.sln', sdk: '.Net6')
      }
    }

  }
}