pipeline {
    agent any
    
    tools{
        dotnetsdk '.Net6'
        jdk 'jdk17'
    }
    
    environment {
        
        SCANNER_HOME= tool 'sonarscannermsbuild'
    }

    stages {
        stage('Git Checkout ') {
            steps {
                git(url: 'https://github.com/tselloss/StorePersons.git', branch: 'main')
            }
        }
        
        // stage('OWASP Dependency Check') {
        //     steps {
        //         dependencyCheck additionalArguments: ' --scan ./ ', odcInstallation: 'DC'
        //             dependencyCheckPublisher pattern: '**/dependency-check-report.xml'
        //     }
        // }
        
        // stage('Trivy FS SCan') {
        //     steps {
        //         sh "trivy fs ."
        //     }
        // }
        
         stage('Sonarqube Analysis') {
            steps {
                
                withSonarQubeEnv('sonar'){
                  sh ''' $SCANNER_HOME/bin/sonar-scanner -Dsonar.projectName=dotnet-demo \
                    -Dsonar.projectKey=dotnet-demo ''' 
               }
                
               
            }
        }
                
               
        //     }
        // }
        
        // stage("Quality Gate") {
        //     steps {
        //         timeout(time: 5, unit: 'MINUTES') {
        //             // Parameter indicates whether to set pipeline to UNSTABLE if Quality Gate fails
        //             // true = set pipeline to UNSTABLE, false = don't
        //             waitForQualityGate abortPipeline: true
        //         }
        //     }
        // }
        
        
    }
}

