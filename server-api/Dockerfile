# release
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

WORKDIR /target
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080

# release
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS compile

## copy solution and project files to container, restore nuget packages
WORKDIR /source
COPY ["server-api.sln", "server-api.sln"]
COPY ["src/Hermes.Server.Api/Hermes.Server.Api.csproj", "src/Hermes.Server.Api/"]
COPY ["src/Hermes.Server.Api.Core/Hermes.Server.Api.Core.csproj", "src/Hermes.Server.Api.Core/"]
COPY ["src/Hermes.Server.Api.Data/Hermes.Server.Api.Data.csproj", "src/Hermes.Server.Api.Data/"]
COPY ["test/Hermes.Tests.Server.Api.Core/Hermes.Tests.Server.Api.Core.csproj", "test/Hermes.Tests.Server.Api.Core/"]
RUN dotnet restore "server-api.sln"

## copy remaining files to container, build, test and publish
COPY . .

RUN dotnet build "server-api.sln" --no-restore --nologo --configuration Release
RUN dotnet test "server-api.sln" --no-build --nologo --configuration Release

FROM compile AS publish
RUN dotnet publish "server-api.sln" --no-build --nologo --configuration Release --output /target/publish

FROM runtime AS release
WORKDIR /target
COPY --from=publish /target/publish .

ENTRYPOINT ["dotnet", "Hermes.Server.Api.dll"]