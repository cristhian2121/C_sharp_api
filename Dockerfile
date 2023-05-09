# Use the .NET Core 3.1 runtime image as the base image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Set the working directory to /app
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining files
COPY . .

# Set environment variables for SQL Server connection string
ENV SQLSERVER_DB_SERVER=CrisServer
ENV SQLSERVER_DB_NAME=ExampleDB
ENV SQLSERVER_DB_USER=Developer
ENV SQLSERVER_DB_PASSWORD=Test123.

# Set environment variables for hot reload
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_USE_POLLING_FILE_WATCHER=true
ENV ASPNETCORE_HOSTINGSTARTUPASSEMBLIES=Microsoft.Extensions.Hosting

# Expose port 80 for the container
EXPOSE 80

# Start the application with hot reload using the dotnet command
ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:80"]