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
        hudson.plugins.sonar.SonarRunnerInstallation 'SonarScanner'
      }
      steps {
        withSonarQubeEnv('SonarQube Scanner') {
          sh 'SonarScanner'
        }
      }
    }
  }
}
