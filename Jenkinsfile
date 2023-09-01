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
      tools {
        sonarQube 'SonarQube Scanner 2.8'
      }
      steps {
        withSonarQubeEnv('SonarQube Scanner') {
          sh 'sonar-scanner'
        }
      }
    }
  }
}
