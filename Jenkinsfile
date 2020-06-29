node{

stage('SCM Checkout'){
	git 'https://github.com/Mugiw4rr4/Block_breaker'
  }
  stage('Compile-Package'){
  def mvnHome = tool name: 'maven-3' , type:'maven'
  sh "$(mvnHome)/bin/mvn package"
  
  }
  }
