FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Backend/Enceja.API/Escola.API.csproj", "Backend/Enceja.API/"]
COPY ["Backend/Enceja.Domain/Escola.Domain.csproj", "Backend/Enceja.Domain/"]
COPY ["Backend/Enceja.Infrastructure/Escola.Infrastructure.csproj", "Backend/Enceja.Infrastructure/"]
COPY ["Backend/Enceja.Application/Escola.Application.csproj", "Backend/Enceja.Application/"]

RUN dotnet restore "./Backend/Enceja.API/Enceja.API.csproj"
COPY . .
WORKDIR "/src/Backend/Enceja.API"
RUN dotnet build "./Enceja.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Enceja.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Enceja.API.dll"]