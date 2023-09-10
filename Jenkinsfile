pipeline {
    agent any
    environment {
        SONARQUBE_SCANNER_HOME = tool name: 'SonarScanner', type: 'hudson.plugins.sonar.SonarRunnerInstallation'    
        DOTNET_HOME = tool name: '.Net6', type: 'io.jenkins.plugins.dotnet.DotNetSDK'
        DOTNET_COMMAND = "${DOTNET_HOME}/dotnet"
    }
    stages {
        stage('Git Checkout') {
            steps {
                git(url: 'https://github.com/tselloss/StorePersons.git', branch: 'main', credentialsId: 'Jenkins_authorization')
            }
        }
        stage('Build') {
            steps {
                script {
                    sh """
                    ${DOTNET_COMMAND} --version
                    ${DOTNET_COMMAND} restore
                    ${DOTNET_COMMAND} build PersonDatabase.sln
                    """
                }
            }
        }
        stage('SonarQube') {
    steps {
        withSonarQubeEnv(installationName: 'server-sonar', credentialsId: 'gene-token') {
            script {
                def sonarScannerCommand = "${DOTNET_COMMAND} SonarScanner"
                sh """
                ${SONARQUBE_SCANNER_HOME}/bin/sonar-scanner begin /k:"PersonsDatabase" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="squ_7769ef3b9086b36be1acb25e1d8ee6d2aedd40f4"
                ${DOTNET_COMMAND} build
                ${SONARQUBE_SCANNER_HOME}/bin/sonar-scanner end /d:sonar.login="squ_7769ef3b9086b36be1acb25e1d8ee6d2aedd40f4"
                """
            }
        }
    }
}

    }
}
