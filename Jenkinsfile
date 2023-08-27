pipeline {
   agent any

   stages {
      stage('Verify Branch') {
         steps {
            echo "$GIT_BRANCH"
         }
      }
         stage('Build') {
            steps {
                bat "msbuild.exe PersonDatabase.csproj /p:Configuration=Release"
            }
        }
      
   }
}
