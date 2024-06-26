#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["01 - Presentation/ExcursaoApp.Api/ExcursaoApp.Api.csproj", "01 - Presentation/ExcursaoApp.Api/"]
COPY ["02 - Application/ExcursaoApp.Application/ExcursaoApp.Application.csproj", "02 - Application/ExcursaoApp.Application/"]
COPY ["03 - Infrastructure/ExcursaoApp.Configuration/ExcursaoApp.Configuration.csproj", "03 - Infrastructure/ExcursaoApp.Configuration/"]
COPY ["03 - Infrastructure/ExcursaoApp.IoC/ExcursaoApp.IoC.csproj", "03 - Infrastructure/ExcursaoApp.IoC/"]
COPY ["03 - Infrastructure/ExcursaoApp.Persistence/ExcursaoApp.Persistence.csproj", "03 - Infrastructure/ExcursaoApp.Persistence/"]
COPY ["04 - Domain/ExcursaoApp.Domain/ExcursaoApp.Domain.csproj", "03 - Infrastructure/ExcursaoApp.Domain/"]
RUN dotnet restore "./01 - Presentation/ExcursaoApp.Api/ExcursaoApp.Api.csproj"
COPY . .
WORKDIR "/src/01 - Presentation/ExcursaoApp.Api"
RUN dotnet build "./ExcursaoApp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ExcursaoApp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExcursaoApp.Api.dll"]