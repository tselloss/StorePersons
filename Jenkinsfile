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
        environment { 
                MSBUILD_SQ_SCANNER_HOME = tool name: 'sq1'
            }
        steps{            
            withSonarQubeEnv('sonarqube-10.1') {
                    sh "dotnet ${MSBUILD_SQ_SCANNER_HOME}/SonarScanner.MSBuild.dll  begin /k:'PersonsDatabase' /d:sonar.host.url='https://eac2-5-203-227-180.ngrok-free.app' /d:sonar.token='sqp_a52fe29bb8ddb57cf88f7e113fe3191ad29e12c7'"
                    dotnetBuild(continueOnError: true, project: 'PersonDatabase.sln', sdk: '.Net6')   
                    sh "dotnet ${MSBUILD_SQ_SCANNER_HOME}/SonarScanner.MSBuild.dll end /d:sonar.token='sqp_a52fe29bb8ddb57cf88f7e113fe3191ad29e12c7'"             
            }
        }
    } 
  }
}





