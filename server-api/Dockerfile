# release
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

WORKDIR /target
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080

# release
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS compile

## copy solution and project files to container, restore nuget packages
WORKDIR /source

### solution
COPY ./*.sln ./

### copy src projects and move them to their respective folders
COPY ./src/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done

### copy test projects and move them to their respective folders
COPY ./test/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p test/${file%.*}/ && mv $file test/${file%.*}/; done

RUN dotnet restore

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