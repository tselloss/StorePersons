pipeline {
    agent any
     environment {
        // sonarscanner

        PROJECTKEY= 'PersonsDatabase'
        SONARURL = 'http://localhost:9000'
        LOGIN= 'squ_7769ef3b9086b36be1acb25e1d8ee6d2aedd40f4'


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
                    def dotnetHome = tool name: '.Net6', type: 'io.jenkins.plugins.dotnet.DotNetSDK'
                    def dotnetCommand = "${dotnetHome}/dotnet"

                    sh """
                    ${dotnetCommand} --version
                    ${dotnetCommand} restore
                    ${dotnetCommand} build PersonDatabase.sln
                    """
                }
            }
        }
      

        stage('Code Quality Check via SonarQube') {
                steps {
                    script {
                    def scannerHome = tool 'sonarscanner';
                       withSonarQubeEnv(credentialsId: 'gene-token'){
                        sh "/var/jenkins_home/sonar-scanner-3.3.0.1492-linux/bin/sonar-scanner \
                        -Dsonar.projectKey=${env.PROJECTKEY} \
                        -Dsonar.sources=. \
                        -Dsonar.host.url=${env.SONARURL} \
                        -Dsonar.login=${env.LOGIN}"
                            }
                        }
                    }
                }


        
        stage("Quality Gate") {
            steps {
                timeout(time: 5, unit: 'MINUTES') {
                    // Parameter indicates whether to set pipeline to UNSTABLE if Quality Gate fails
                    // true = set pipeline to UNSTABLE, false = don't
                    waitForQualityGate abortPipeline: true
                }
            }
        }
    }
}
