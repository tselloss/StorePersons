pipeline {
    agent any
    
    tools{
        
        jdk 'jdk17'
    }
    
    environment {
        
        SCANNER_HOME= tool 'sonar-scanner'
    }

    stages {
        stage('Git Checkout ') {
            steps {
                git(url: 'https://github.com/tselloss/StorePersons.git', branch: 'main', credentialsId: 'Jenkins_authorization')
            }
        }
        
        stage('OWASP Dependency Check') {
            steps {
                dependencyCheck additionalArguments: ' --scan ./ ', odcInstallation: 'DC'
                    dependencyCheckPublisher pattern: '**/dependency-check-report.xml'
            }
        }
        
        // stage('Trivy FS SCan') {
        //     steps {
        //         sh "trivy fs ."
        //     }
        // }
        
        stage('Sonarqube Analysis') {
            steps {
                
                withSonarQubeEnv('sonar'){
                  sh' dotnet sonarscanner begin /k:"PersonsDatabase"'
                     sh' dotnet build PersonsDatabase.sln'
                     sh' dotnet sonarscanner end '
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

