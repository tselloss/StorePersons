pipeline{
    stage('SCM') {
         echo 'Gathering code from version control'
         git branch: '${branch}', url: 'https://github.com/tselloss/StorePersons.git'
    }
    stage('Build') {
         echo 'Building....'
         sh 'dotnet --version'
         sh 'dotnet build PersonDatabase'
         echo 'Building new feature'
    }
    stage('Test') {
         echo 'Testing....'
    }
    stage('Deploy') {
         echo 'Deploying....'
    }
}
