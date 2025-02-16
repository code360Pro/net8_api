
# Docker commands 
# docker run -d -p 8080:80 --name learning-api-container us-central1-docker.pkg.dev/rp-dev-450309/rp-dev-net-repo/dotnet8-api:e03c17c
# docker logs learning-api-container
# Check Container Status: Ensure the container is running:
# docker ps -a
# Inspect the Container: Inspect the container for any issues:
# docker inspect learning-api-container
# Test the API: Try accessing the API directly from the container:
# docker exec -it learning-api-container curl http://localhost:80
# docker stop learning-api-container
# docker rm learning-api-container
# docker rmi us-central1-docker.pkg.dev/rp-dev-450309/rp-dev-net-repo/dotnet8-api:e03c17c