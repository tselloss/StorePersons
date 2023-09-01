// pipeline {
//   agent any
//   stages {
//     stage('Verify') {
//       steps {
//         sh 'echo "$GIT_BRANCH"'
//       }
//     }

//     stage('Sonarqube') {
//       steps {
//         withSonarQubeEnv('SonarScanner') {
//           dotnetBuild(project: 'PersonDatabase.sln', sdk: '.Net6')
//         }

//       }
//     }

//     stage('Build') {
//       steps {
//         dotnetBuild(project: 'PersonDatabase.sln', sdk: '.Net6')
//       }
//     }

//   }
// }
pipeline {
  agent any
  stages {
    stage('SonarQube analysis') {
      steps {
        script {
          // requires SonarQube Scanner 2.8+
          scannerHome = tool 'SonarScanner'
        }
        withSonarQubeEnv('SonarQube Scanner') {
          sh "/var/jenkins_home/sonar-scanner-3.3.0.1492-linux"  
        }
      }
    }
  }
}
