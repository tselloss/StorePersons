node {
  try {  
    stage('Static Analysis') {
      withSonarQubeEnv('SonarQube1') {
        bat '"C:\\path\\to\\dotnet" build'
        bat '"C:\\path\\to\\sonar-scanner" -Dsonar.projectKey=my-dotnet-project -Dsonar.sources=. -Dsonar.host.url=http://your-sonarqube-server -Dsonar.login=your-sonarqube-token'
        echo 'Static Analysis Completed' 
      }
    }
   
    stage("Quality Gate") {
      timeout(time: 1, unit: 'HOURS') {
        script {
          def qg = waitForQualityGate()
          if (qg.status != 'OK') {
            error "Pipeline aborted due to quality gate failure: ${qg.status}"
          }
        }
        echo 'Quality Gate Passed' 
      }
    }
  } catch (Exception e) {
    currentBuild.result = 'FAILURE'
    throw e
  } finally {
    step([$class: 'JUnitResultArchiver', testResults: '**/target/surefire-reports/TEST-*.xml'])
    step([$class: 'CucumberTestResultArchiver', testResults: '**/target/cucumber-reports/cucumber.xml'])
  }
}

