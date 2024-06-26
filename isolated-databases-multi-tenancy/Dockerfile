FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln ./
COPY IsolatedDatabasesMultiTenancy.Api/*.csproj ./IsolatedDatabasesMultiTenancy.Api/
COPY IsolatedDatabasesMultiTenancy.Domain/*.csproj ./IsolatedDatabasesMultiTenancy.Domain/
COPY IsolatedDatabasesMultiTenancy.Data/*.csproj ./IsolatedDatabasesMultiTenancy.Data/
COPY IsolatedDatabasesMultiTenancy.Service/*.csproj ./IsolatedDatabasesMultiTenancy.Service/
RUN dotnet restore

COPY IsolatedDatabasesMultiTenancy.Api/. ./IsolatedDatabasesMultiTenancy.Api/
COPY IsolatedDatabasesMultiTenancy.Domain/. ./IsolatedDatabasesMultiTenancy.Domain/
COPY IsolatedDatabasesMultiTenancy.Data/. ./IsolatedDatabasesMultiTenancy.Data/
COPY IsolatedDatabasesMultiTenancy.Service/. ./IsolatedDatabasesMultiTenancy.Service/

WORKDIR /app/IsolatedDatabasesMultiTenancy.Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/IsolatedDatabasesMultiTenancy.Api/out .

ENTRYPOINT [ "dotnet", "IsolatedDatabasesMultiTenancy.Api.dll" ]