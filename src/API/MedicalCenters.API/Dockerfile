#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 23412
EXPOSE 23413

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/API/MedicalCenters.API/MedicalCenters.API.csproj", "src/API/MedicalCenters.API/"]
COPY ["src/Core/MedicalCenters.Application/MedicalCenters.Application.csproj", "src/Core/MedicalCenters.Application/"]
COPY ["src/Utility/Utility.csproj", "src/Utility/"]
COPY ["src/Core/MedicalCenters.Domain/MedicalCenters.Domain.csproj", "src/Core/MedicalCenters.Domain/"]
COPY ["src/Infrastructure/MedicalCenters.Identity/MedicalCenters.Identity.csproj", "src/Infrastructure/MedicalCenters.Identity/"]
COPY ["src/Infrastructure/MedicalCenters.Cache/MedicalCenters.Cache.csproj", "src/Infrastructure/MedicalCenters.Cache/"]
COPY ["src/Infrastructure/MedicalCenters.Infrastructure/MedicalCenters.Persistence.csproj", "src/Infrastructure/MedicalCenters.Infrastructure/"]
RUN dotnet restore "./src/API/MedicalCenters.API/MedicalCenters.API.csproj"
COPY . .
WORKDIR "/src/src/API/MedicalCenters.API"
RUN dotnet build "./MedicalCenters.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MedicalCenters.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MedicalCenters.API.dll"]