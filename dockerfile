# Use the SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the .csproj file and restore dependencies
COPY ["CustomApi.csproj", "./"]
RUN dotnet restore "CustomApi.csproj"

# Copy the entire source code to the container
COPY . .

# Build the application in Release mode
RUN dotnet build "CustomApi.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "CustomApi.csproj" -c Release -o /app/publish --no-restore

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "CustomApi.dll"]
