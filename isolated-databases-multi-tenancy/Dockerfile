FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY *.sln ./
COPY IsolatedDatabasesMultiTenancy.Api/*.csproj ./IsolatedDatabasesMultiTenancy.Api/
COPY IsolatedDatabasesMultiTenancy.CrossCutting/*.csproj ./IsolatedDatabasesMultiTenancy.CrossCutting/
COPY IsolatedDatabasesMultiTenancy.Domain/*.csproj ./IsolatedDatabasesMultiTenancy.Domain/
COPY IsolatedDatabasesMultiTenancy.NUnitTest/*.csproj ./IsolatedDatabasesMultiTenancy.NUnitTest/
COPY IsolatedDatabasesMultiTenancy.Repositorie/*.csproj ./IsolatedDatabasesMultiTenancy.Repositorie/
COPY IsolatedDatabasesMultiTenancy.Service/*.csproj ./IsolatedDatabasesMultiTenancy.Service/
RUN dotnet restore

COPY IsolatedDatabasesMultiTenancy.Api/. ./IsolatedDatabasesMultiTenancy.Api/
COPY IsolatedDatabasesMultiTenancy.CrossCutting/. ./IsolatedDatabasesMultiTenancy.CrossCutting/
COPY IsolatedDatabasesMultiTenancy.Domain/. ./IsolatedDatabasesMultiTenancy.Domain/
COPY IsolatedDatabasesMultiTenancy.NUnitTest/. ./IsolatedDatabasesMultiTenancy.NUnitTest/
COPY IsolatedDatabasesMultiTenancy.Repositorie/. ./IsolatedDatabasesMultiTenancy.Repositorie/
COPY IsolatedDatabasesMultiTenancy.Service/. ./IsolatedDatabasesMultiTenancy.Service/

WORKDIR /app/IsolatedDatabasesMultiTenancy.Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

COPY --from=build /app/IsolatedDatabasesMultiTenancy.Api/out .

ENTRYPOINT [ "dotnet", "IsolatedDatabasesMultiTenancy.Api.dll" ]