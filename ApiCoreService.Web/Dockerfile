# Use the Windows Server Core image for ASP.NET 8.0
FROM mcr.microsoft.com/dotnet/aspnet:8.0-windowsservercore-ltsc2019 AS base

# Set the working directory inside the container
WORKDIR /app

# Copy the published application into the container
COPY bin/Release/net8.0/publish/ .

# Expose the port the app is running on inside the container
EXPOSE 8080
EXPOSE 80
EXPOSE 5000

# Set environment variable to make ASP.NET Core listen on multiple ports
ENV ASPNETCORE_URLS=http://+:80;http://+:8080;http://+:5000

# Keep the same entrypoint as before
ENTRYPOINT ["dotnet", "ApiCoreService.Web.dll"]
