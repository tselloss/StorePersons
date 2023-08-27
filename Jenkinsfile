node {
  stage('SCM') {
    checkout scm
  }
  stage('SonarQube Analysis') {
    def scannerHome = tool 'SonarScanner for MSBuild'
    withSonarQubeEnv() {
      bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll begin /k:\"PersonsDatabase\""
      bat "dotnet build"
      bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll end"
    }
  }
}
