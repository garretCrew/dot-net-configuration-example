#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["dot-net-configuration-example-api/dot-net-configuration-example-api.csproj", "dot-net-configuration-example-api/"]
RUN dotnet restore "./dot-net-configuration-example-api/./dot-net-configuration-example-api.csproj"
COPY . .
WORKDIR "/src/dot-net-configuration-example-api"
RUN dotnet build "./dot-net-configuration-example-api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./dot-net-configuration-example-api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dot-net-configuration-example-api.dll"]