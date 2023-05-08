# Use the .NET Core 3.1 runtime image as the base image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

# Set the working directory to /app
WORKDIR /app

# Copy the published application to the container
COPY bin/Release/netcoreapp3.1/publish/ .

# Set environment variables for SQL Server connection string
ENV SQLSERVER_DB_SERVER=<server_name>
ENV SQLSERVER_DB_NAME=<database_name>
ENV SQLSERVER_DB_USER=<username>
ENV SQLSERVER_DB_PASSWORD=<password>

# Expose port 80 for the container
EXPOSE 80

# Start the application using the dotnet command
CMD ["dotnet", "<project_name>.dll"]