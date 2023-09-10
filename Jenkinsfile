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
                dotnet sonarscanner begin /k:"PersonsDatabase" /d:sonar.host.url="https://eac2-5-203-227-180.ngrok-free.app"  /d:sonar.token="sqp_a52fe29bb8ddb57cf88f7e113fe3191ad29e12c7"
                dotnet build
                dotnet sonarscanner end /d:sonar.token="sqp_a52fe29bb8ddb57cf88f7e113fe3191ad29e12c7"  
                
            }
        }
    } 
  }
}
