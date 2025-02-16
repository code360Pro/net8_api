# Use the official .NET 8 SDK image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /app


ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

# Copy the project file and restore dependencies
COPY src/Learning.Api/*.csproj ./
RUN dotnet restore

# Copy the rest of the application source code
COPY . ./

# Build the application
RUN dotnet publish -c Release -o out

# Use the official .NET 8 runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Set the working directory
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/out .

RUN ls -R /app


# Command to run the application
ENTRYPOINT ["dotnet", "Learning.Api.dll"]