# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy all .csproj files and restore dependencies
COPY ["TravelTracker.Api/TravelTracker.Api.csproj", "TravelTracker.Api/"]
COPY ["TravelTracker.Application/TravelTracker.Application.csproj", "TravelTracker.Application/"]
COPY ["TravelTracker.Domain/TravelTracker.Domain.csproj", "TravelTracker.Domain/"]
COPY ["TravelTracker.Infrastructure/TravelTracker.Infrastructure.csproj", "TravelTracker.Infrastructure/"]
RUN dotnet restore "TravelTracker.Api/TravelTracker.Api.csproj"

# Copy the rest of the source code
COPY . .
WORKDIR "/src/TravelTracker.Api"
RUN dotnet build "TravelTracker.Api.csproj" -c Release -o /app/build

# Stage 2: Publish the application
FROM build AS publish
RUN dotnet publish "TravelTracker.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 3: Create the final, lightweight image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TravelTracker.Api.dll"]