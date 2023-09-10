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
                dotnetBuild(continueOnError: true, project: 'PersonDatabase.sln', sdk: '.Net6')
                dotnetClean(continueOnError: true, project: 'PersonDatabase.sln', sdk: '.Net6')
                dotnetListPackage(continueOnError: true, project: 'PersonDatabase.sln', sdk: '.Net6')
                dotnetNuGetDelete(continueOnError: true, project: 'PersonDatabase.sln', sdk: '.Net6')
                dotnetNuGetPush(continueOnError: true, project: 'PersonDatabase.sln', sdk: '.Net6')
                dotnetPack(continueOnError: true, project: 'PersonDatabase.sln', sdk: '.Net6')
                dotnetPublish(continueOnError: true, project: 'PersonDatabase.sln', sdk: '.Net6')
                dotnetRestore(continueOnError: true, project: 'PersonDatabase.sln', sdk: '.Net6')
                dotnetTest(continueOnError: true, project: 'PersonDatabase.sln', sdk: '.Net6')
                dotnetToolRestore(continueOnError: true, project: 'PersonDatabase.sln', sdk: '.Net6')
            }
        }
        stage('SonarQube') {
            steps {
                withSonarQubeEnv(installationName: 'server-sonar', credentialsId: 'gene-token') {                    
                     sh' .Net6 sonarscanner begin /k:"PersonsDatabase" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="squ_7769ef3b9086b36be1acb25e1d8ee6d2aedd40f4"'
                     sh' .Net6 build
                     sh' .Net6 sonarscanner end /d:sonar.login="squ_7769ef3b9086b36be1acb25e1d8ee6d2aedd40f4"'
                }
            }
        }
    }
}

