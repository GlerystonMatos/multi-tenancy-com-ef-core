FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY *.sln ./
COPY SingleDatabaseMultiTenancy.Api/*.csproj ./SingleDatabaseMultiTenancy.Api/
COPY SingleDatabaseMultiTenancy.CrossCutting/*.csproj ./SingleDatabaseMultiTenancy.CrossCutting/
COPY SingleDatabaseMultiTenancy.Domain/*.csproj ./SingleDatabaseMultiTenancy.Domain/
COPY SingleDatabaseMultiTenancy.NUnitTest/*.csproj ./SingleDatabaseMultiTenancy.NUnitTest/
COPY SingleDatabaseMultiTenancy.Repositorie/*.csproj ./SingleDatabaseMultiTenancy.Repositorie/
COPY SingleDatabaseMultiTenancy.Service/*.csproj ./SingleDatabaseMultiTenancy.Service/
RUN dotnet restore

COPY SingleDatabaseMultiTenancy.Api/. ./SingleDatabaseMultiTenancy.Api/
COPY SingleDatabaseMultiTenancy.CrossCutting/. ./SingleDatabaseMultiTenancy.CrossCutting/
COPY SingleDatabaseMultiTenancy.Domain/. ./SingleDatabaseMultiTenancy.Domain/
COPY SingleDatabaseMultiTenancy.NUnitTest/. ./SingleDatabaseMultiTenancy.NUnitTest/
COPY SingleDatabaseMultiTenancy.Repositorie/. ./SingleDatabaseMultiTenancy.Repositorie/
COPY SingleDatabaseMultiTenancy.Service/. ./SingleDatabaseMultiTenancy.Service/

WORKDIR /app/SingleDatabaseMultiTenancy.Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

COPY --from=build /app/SingleDatabaseMultiTenancy.Api/out .

ENTRYPOINT [ "dotnet", "SingleDatabaseMultiTenancy.Api.dll" ]