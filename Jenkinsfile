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
                script {
                    def dotnetHome = tool name: '.Net6', type: 'io.jenkins.plugins.dotnet.DotNetSDK'
                    def dotnetCommand = "${dotnetHome}/dotnet"
                    def dotnetSdkEnv = ["DOTNET_HOME=${dotnetHome}", "PATH+DOTNET=${dotnetHome}"]

                    sh """
                    ${dotnetCommand} --version
                    ${dotnetCommand} restore
                    ${dotnetCommand} build PersonDatabase.sln
                    """
                }
            }
        }
        stage('SonarQube') {
            steps {
                withSonarQubeEnv(installationName: 'server-sonar', credentialsId: 'gene-token') {
                    sh "${dotnetCommand} sonarscanner -X"
                    sh """
                    ${dotnetCommand} sonarscanner begin /k:"PersonsDatabase" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="squ_7769ef3b9086b36be1acb25e1d8ee6d2aedd40f4"
                    ${dotnetCommand} build
                    ${dotnetCommand} sonarscanner end /d:sonar.login="squ_7769ef3b9086b36be1acb25e1d8ee6d2aedd40f4"
                    """
                }
            }
        }
    }
}
