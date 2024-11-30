# ApiCoreService.Web

A .NET 8.0-based web application, designed to run in Docker containers on both Windows and Linux.

## Prerequisites
1. Install [Docker Desktop](https://www.docker.com/products/docker-desktop).
2. Ensure Docker is set to the appropriate container mode:
   - **Windows Containers** for Windows OS.
   - **Linux Containers** for Linux OS.

## Build and Run Instructions

### Windows Containers

1. **Switch to Windows Containers** (Docker Desktop):
   - Right-click the Docker icon in your system tray and select `Switch to Windows Containers`.
   
2. **Build the Image**:
   - docker build -t apicoreserviceweb-windows . 
   
3. **Run the Container**:
   - docker run -d -p 8080:8080 --name apicoreservice-container apicoreserviceweb-windows

4. **Access the Application** (Open your browser and go to):
   - http://localhost:8080

5. **Stop and Remove the Container** (Optional):
   - docker stop apicoreservice-container
   - docker rm apicoreservice-container
   
### Linux Containers

1. **Switch to Linux Containers** (Docker Desktop):
   - Right-click the Docker icon in your system tray and select `Switch to Linux Containers`.
   
2. **Build the Image**:
   - docker build -f Dockerfile.linux -t apicoreserviceweb-linux .
   
3. **Run the Container**:
   - docker run -d -p 8080:8080 --name apicoreservice-container apicoreserviceweb-linux

4. **Access the Application** (Open your browser and go to):
   - http://localhost:8080

5. **Stop and Remove the Container** (Optional):
   - docker stop apicoreservice-container
   - docker rm apicoreservice-container
   
## Troubleshooting

1. **Check Docker Logs**:
   - docker logs apicoreservice-container
   
2. **Verify Container Status**:
   - docker ps
   
3. **Port Issues**:
   - Ensure port 8080 is open and not blocked by your firewall.

4. **Restart Docker** ( If issues persist, restart Docker Desktop):
   - This should now display correctly when rendered as a Markdown file. Let me know if you need any more adjustments!
