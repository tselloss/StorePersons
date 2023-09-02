pipeline {
  agent any
  stages {  
    stage('SonarQube Analysis') {
			steps {
				script {
					def msbuildHome = tool 'Default MSBuild'
					def scannerHome = tool 'SonarScanner for MSBuild'
					withSonarQubeEnv('SonarQube') {
						bat "\"${scannerHome}\\SonarScanner.MSBuild.exe\" begin /k:\"StorePersons\""
						bat "\"${msbuildHome}\\MSBuild.exe\" MSPChallenge-Client-SonarQube.sln"
						bat "\"${scannerHome}\\SonarScanner.MSBuild.exe\" end"
					}        
          timeout(time: 1, unit: 'HOURS') {
            waitForQualityGate abortPipeline: true
          }
      }
    }

  }
}



