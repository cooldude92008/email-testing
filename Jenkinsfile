def git_Url;
//def msbuildHome;
def scannerHome;
def sonar_url;
def sonar_project_token;
node {
    stage('checkout') 
       {
           
        // Check out the C sharp code from a GitHub repository by using below pipeline syntax command
         git_Url = "https://github.com/mohankrishna1990/email-testing.git"
         
         //Below command is used to check Git URL
         checkout([$class: 'GitSCM',
                   branches: [[name: '*/master']], 
                   extensions: [],
                   userRemoteConfigs: [[credentialsId: 'Git_repo_ID', url: "${git_Url}"]]])
         }
    stage('static_code_analysis') 
        {
                
        //msbuildHome = tool 'MS_Build'
        scannerHome = tool 'SonarScanner'
        sonar_url = "http://localhost:9000"
        sonar_project_token = "396c900134884936a0a41a9abfc075e302bae9c8"
            
            withSonarQubeEnv() 
            {
            //try{
            //Below command is used to begin the sonar scanner for our porject(jenkins_pipeline_scripted is the name of the token from sonar)   
            bat "\"${scannerHome}\\SonarScanner.MSBuild.exe\" begin /k:email-testing /d:sonar.host.url=${sonar_url} /d:sonar.login=${sonar_project_token}"
            //Below command is used to generate the nuget package for rebbuild
            bat "\"${msbuildHome}\\MSBuild.exe\" -t:restore"
            //Below command is used to build the application
            bat "\"${msbuildHome}\\MSBuild.exe\" /t:Rebuild"
            //Below command is used to end the sonar scanner which we have begin in first step
            bat "\"${scannerHome}\\SonarScanner.MSBuild.exe\" end /d:sonar.login=${sonar_project_token}"
            }
        }        
             stage("test email"){
            emailext (
             subject:"Job Details '${env.JOB_NAME}' ",
            body:"""<p> Started job '${env.JOB_NAME}' [${env.BUILD_NUMBER}]'":</P>
            <P>Check the console at "<a href="${env.RUN_DISPLAY_URL}">${env.JOB_NAME}  [${env.BUILD_NUMBER}]</a>"</p>""",
            to:"mohankrishnavenkata82@gmail.com"
            )
            
          }
          
        }
