# Dockerfile para CrudToAlgo API
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar arquivos de projeto e restaurar dependências
COPY ["CrudToAlgo.API/CrudToAlgo.API.csproj", "CrudToAlgo.API/"]
COPY ["CrudToAlgo.Application/CrudToAlgo.Application.csproj", "CrudToAlgo.Application/"]
COPY ["CrudToAlgo.Domain/CrudToAlgo.Domain.csproj", "CrudToAlgo.Domain/"]
COPY ["CrudToAlgo.Infrastructure/CrudToAlgo.Infrastructure.csproj", "CrudToAlgo.Infrastructure/"]

RUN dotnet restore "CrudToAlgo.API/CrudToAlgo.API.csproj"

# Copiar código fonte
COPY . .

# Build da aplicação
WORKDIR "/src/CrudToAlgo.API"
RUN dotnet build "CrudToAlgo.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Estágio de publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CrudToAlgo.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Estágio final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Criar usuário não-root para segurança
RUN adduser --disabled-password --gecos '' appuser && chown -R appuser /app
USER appuser

ENTRYPOINT ["dotnet", "CrudToAlgo.API.dll"]