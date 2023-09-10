pipeline {
  agent any
  stages {
    stage('Git Checkout') {
      steps {
        git(url: 'https://github.com/tselloss/StorePersons.git', branch: 'main', credentialsId: 'Jenkins_authorization')
      }
    }

    stage('Build') {
      steps {
        dotnetBuild(continueOnError: true, project: 'PersonDatabase.sln', sdk: '.Net6')
      }
    }
    stage('SonarQube') {
        steps{
            withSonarQubeEnv('sonarqube-10.1') {
                    sh '''\
                        sonar-scanner \
                        -Dsonar.projectKey=PersonsDatabase \
                        -Dsonar.sources=. \
                        -Dsonar.host.url=https://eac2-5-203-227-180.ngrok-free.app \
                        -Dsonar.login=sqp_a52fe29bb8ddb57cf88f7e113fe3191ad29e12c7
                    '''
            }
        }
    } 
    } 
  }

