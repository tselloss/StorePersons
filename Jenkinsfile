pipeline {
  agent any
  stages {  
    stage('SonarQube Analysis') {
			steps {
				script {
					def msbuildHome = tool name: 'MSBuild', type: 'hudson.plugins.msbuild.MsBuildInstallation'
					def scannerHome = tool 'sq1'
					withSonarQubeEnv(credentialsId: 'Users', installationName: 'SonarQubeScanner') {
						bat "\"${scannerHome}\\SonarScanner.MSBuild.exe\" begin /k:\"StorePersons\""
						bat "\"${msbuildHome}\\MSBuild.exe\" PersonDatabase.sln"
						bat "\"${scannerHome}\\SonarScanner.MSBuild.exe\" end"
					}
				
          timeout(time: 1, unit: 'HOURS') {
            waitForQualityGate abortPipeline: false, credentialsId: 'Users'
          }
      }
    }

  }
}
}

