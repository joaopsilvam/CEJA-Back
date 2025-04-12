# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
COPY ["Escola.API/Escola.API.csproj", "src/Escola.API/"]
COPY ["Escola.Domain/Escola.Domain.csproj", "src/Escola.Domain/"]
COPY ["Escola.Infrastructure/Escola.Infrastructure.csproj", "src/Escola.Infrastructure/"]

RUN dotnet restore "./Escola.API/Escola.API.csproj"

COPY . .

WORKDIR "/Escola.API"

RUN dotnet build "./Escola.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app
COPY --from=build /app/build .

# Instala a ferramenta Entity Framework no container
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

ENTRYPOINT ["dotnet", "Escola.API.dll"]