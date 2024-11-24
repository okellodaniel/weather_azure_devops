FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["WeatherApi/WeatherApi.csproj", "WeatherApi/"]
RUN dotnet restore "WeatherApi/WeatherApi.csproj"

# Copy remaining files, build
COPY . .
RUN dotnet build "WeatherApi/WeatherApi.csproj" -c Release -o /app/build

# Run Tests
COPY ["WeatherAPI.Tests/WeatherAPI.Tests.csproj", "WeatherApi.Tests/"] 
RUN dotnet restore "WeatherAPI.Tests/WeatherAPI.Tests.csproj"
RUN dotnet test "WeatherAPI.Tests/WeatherAPI.Tests.csproj" -c Release

# Publish
RUN dotnet publish "WeatherApi/WeatherApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Create runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WeatherApi.dll"]