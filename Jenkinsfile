node {
  stage('SCM') {
    checkout scm
  }
  stage('SonarQube analysis') {
    def msbuildHome = tool 'MSBuild'
    def scannerHome = tool 'SonarScanner'
    withSonarQubeEnv() {
      bat "\"${scannerHome}\\SonarScanner.MSBuild.exe\" begin /k:jfj /d:sonar.host.url=\"http://localhost:9000\" /d:sonar.login=5d821bd5467b27bfdb8a4545995ba22b75e24078"
     // bat "\"${scannerHome}\\SonarScanner.MSBuild.exe begin /k:"jfj"/d:sonar.host.url="http://localhost:9000"/d:sonar.login="5d821bd5467b27bfdb8a4545995ba22b75e24078""
      bat "\"${msbuildHome}\\MsBuild.exe /t:Rebuild"
      bat "\"${scannerHome}\\SonarScanner.MSBuild.exe end /d:sonar.login="5d821bd5467b27bfdb8a4545995ba22b75e24078"""
    }
  }
}
