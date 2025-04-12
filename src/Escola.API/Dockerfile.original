FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 44389

# Este est gio   utilizado para construir o projeto de servi o
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar arquivos de projeto espec ficos
COPY Backend/src/Escola.API/Escola.API.csproj Escola.API/
COPY Backend/src/Escola.Domain/Escola.Domain.csproj Escola.Domain/
COPY Backend/src/Escola.Infrastructure/Escola.Infrastructure.csproj Escola.Infrastructure/

# Restaurar pacotes
RUN dotnet restore "Escola.API/Escola.API.csproj"

# Copiar o restante dos arquivos da pasta src
COPY Backend/src/ .

# Definir o diretorio de trabalho e compilar o projeto
WORKDIR "/src/Escola.API"
RUN dotnet build "Escola.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Este est gio   utilizado para publicar o projeto de servi o e copi -lo para o est gio final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Escola.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

ENV ASPNETCORE_URLS="http://+:8080;https://+:44389"
ENV ASPNETCORE_HTTPS_PORT=44389

# Este est gio   utilizado em produ  o
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Escola.API.dll"]
