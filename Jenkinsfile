pipeline{
    
    agent any
    environment{
        dockerImage = ''
        registry = 'anushasidhanti/pipelinedocker'
        registryCredential ='DockerHubID'
        containers = ''
        AllContainers = ''
    }
    
    stages{
        stage('checkout'){
            steps{
                checkout([$class: 'GitSCM', branches: [[name: '*/master']], browser: [$class: 'GithubWeb', repoUrl: ''], extensions: [[$class: 'CleanBeforeCheckout', deleteUntrackedNestedRepositories: true]], userRemoteConfigs: [[url: 'https://github.com/anushasidhanti/CoreAsp.netProjectWithTestCases']]])
            }            
        }
        stage('Run Tests'){
            steps{
                script{
                    bat(script:'@dotnet test')
                }
            }
        }
        stage('Build Docker Image'){
            steps{
                script{
                    dockerImage = docker.build registry
                }
            }
        }
        stage('Uploading Image'){
            steps{
                script{
                    docker.withRegistry('',registryCredential){
                        dockerImage.push()
                    }
                }
            }            
        }
        stage('Stop Docker Containers'){
            steps{
                script{
                    
                    containers = bat (script:'@docker ps -f ancestor='+ registry + ' -q ', returnStdout: true).trim()
                    
                    if (containers?.trim()) {
                        echo " containers is: " + containers + "." 
                        containers = containers.split('\n')
                        for (i in containers) {
                            echo 'Container: ' + i + ' is stopped'
                            bat (script:'docker stop ' + i)
                        }
                    }
                    AllContainers = bat (script:'@docker ps -f ancestor='+ registry + ' -a -q', returnStdout: true).trim()
                    if (AllContainers?.trim()) {
                        AllContainers = AllContainers.split('\n')
                          for (i in AllContainers) {
                            echo 'Container name: ' + i
                            bat (script:'docker rm ' + i) 
                        }
                    }
                }
            }
        }
        stage('Docker run'){
            steps{
                script{
                    dockerImage.run("-p 9000:80 --rm")
                }
            }
        }
    }    
}
