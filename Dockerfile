# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["src/apptlink.Api/apptlink.Api.csproj", "src/apptlink.Api/"]
COPY ["src/apptlink.Application/apptlink.Application.csproj", "src/apptlink.Application/"]
COPY ["src/apptlink.Domain/apptlink.Domain.csproj", "src/apptlink.Domain/"]
COPY ["src/apptlink.Infraestructure/apptlink.Infraestructure.csproj", "src/apptlink.Infraestructure/"]
RUN dotnet restore "src/apptlink.Api/apptlink.Api.csproj"
COPY . .
WORKDIR "/src/src/apptlink.Api"
RUN dotnet build "apptlink.Api.csproj" -c Release -o /app/build

# Etapa de publicación
FROM build AS publish
RUN dotnet publish "apptlink.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV LANG=es_ES.UTF-8

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "apptlink.Api.dll"]