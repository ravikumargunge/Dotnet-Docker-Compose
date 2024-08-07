FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY webapi/*.csproj .

RUN dotnet restore
COPY * .

RUN dotnet build webapi.csproj -c Release

RUN dotnet publish webapi.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .

EXPOSE 8000

ENTRYPOINT ["dotnet", "webapi.dll"]

