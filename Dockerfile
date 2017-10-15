FROM microsoft/dotnet:latest

COPY . /app
WORKDIR /app

RUN dotnet restore
RUN dotnet build

ENTRYPOINT dotnet run -p src/Nasa.RocketLauncher.Console/