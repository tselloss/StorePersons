pipeline {
  agent any
  stages {
    stage('Verify Branch') {
      parallel {
        stage('Verify Branch') {
          steps {
            echo "$GIT_BRANCH"
          }
        }
      stage('Clean') {
        steps {
          bat "msbuild.exe ${workspace}\\C:\\Users\\karac\\source\\repos\\StorePersons\\PersonDatabase.sln /nologo /nr:false /p:platform=\"x64\" /p:configuration=\"release\" /t:clean"
        }
      }
            }
          }
          stage('Build') {
          steps {
              bat "msbuild.exe ${workspace}\\C:\\Users\\karac\\source\\repos\\StorePersons\\PersonDatabase.sln /nologo /nr:false /p:platform=\"x64\" /p:configuration=\"release\" /p:PackageCertificateKeyFile=C:\\path\\to\\certificate\\file.pfx /t:clean;restore;rebuild"
          }
      }
    stage('Restore') {
      steps {
        sh 'dotnet ef build'
      }
    }

  }
}
