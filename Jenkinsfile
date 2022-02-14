node {
  stage('SCM') {
    checkout scm
  }
  stage('SonarQube analysis') {
    def msbuildHome = tool 'MSBuild'
    def scannerHome = tool 'SonarScanner'
    withSonarQubeEnv() {
      bat "\"${scannerHome}\\SonarScanner.MSBuild.exe\" begin /k:\"jfj\""
      bat "\"${msbuildHome}\\MSBuild.exe\" /t:Rebuild"
      bat "\"${scannerHome}\\SonarScanner.MSBuild.exe\" end"
    }
  }
}
