FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln ./
COPY SingleDatabaseMultiTenancy.Api/*.csproj ./SingleDatabaseMultiTenancy.Api/
COPY SingleDatabaseMultiTenancy.Domain/*.csproj ./SingleDatabaseMultiTenancy.Domain/
COPY SingleDatabaseMultiTenancy.Data/*.csproj ./SingleDatabaseMultiTenancy.Data/
COPY SingleDatabaseMultiTenancy.Service/*.csproj ./SingleDatabaseMultiTenancy.Service/
RUN dotnet restore

COPY SingleDatabaseMultiTenancy.Api/. ./SingleDatabaseMultiTenancy.Api/
COPY SingleDatabaseMultiTenancy.Domain/. ./SingleDatabaseMultiTenancy.Domain/
COPY SingleDatabaseMultiTenancy.Data/. ./SingleDatabaseMultiTenancy.Data/
COPY SingleDatabaseMultiTenancy.Service/. ./SingleDatabaseMultiTenancy.Service/

WORKDIR /app/SingleDatabaseMultiTenancy.Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/SingleDatabaseMultiTenancy.Api/out .

ENTRYPOINT [ "dotnet", "SingleDatabaseMultiTenancy.Api.dll" ]