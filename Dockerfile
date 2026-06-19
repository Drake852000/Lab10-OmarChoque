FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

COPY . .

RUN dotnet restore Lab10-OmarChoque.Api/Lab10-OmarChoque.Api.csproj
RUN dotnet publish Lab10-OmarChoque.Api/Lab10-OmarChoque.Api.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "Lab10-OmarChoque.Api.dll"]
