#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/backend/HomeCloud.Maps.Server/HomeCloud.Maps.Server.csproj", "src/backend/HomeCloud.Maps.Server/"]
COPY ["src/frontend/HomeCloud.Maps.Client/HomeCloud.Maps.Client.csproj", "src/frontend/HomeCloud.Maps.Client/"]
COPY ["src/frontend/HomeCloud.Maps.Client.WebApi/HomeCloud.Maps.Client.WebApi.csproj", "src/frontend/HomeCloud.Maps.Client.WebApi/"]
COPY ["src/backend/HomeCloud.Maps.Application/HomeCloud.Maps.Application.csproj", "src/backend/HomeCloud.Maps.Application/"]
COPY ["src/backend/HomeCloud.Maps.Domain/HomeCloud.Maps.Domain.csproj", "src/backend/HomeCloud.Maps.Domain/"]
COPY ["src/backend/HomeCloud.Maps.Infrastructure/HomeCloud.Maps.Infrastructure.csproj", "src/backend/HomeCloud.Maps.Infrastructure/"]
RUN dotnet restore "src/backend/HomeCloud.Maps.Server/HomeCloud.Maps.Server.csproj"
COPY . .
WORKDIR "/src/src/backend/HomeCloud.Maps.Server"
RUN dotnet build "HomeCloud.Maps.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HomeCloud.Maps.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomeCloud.Maps.Server.dll"]