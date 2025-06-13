# ==== [ Base SDK Image for Building and Migrations ] ====
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /src

# Projeyi kopyala
COPY . .

# NuGet restore
RUN dotnet restore OBiletClone.sln

# Uygulama build ve publish
WORKDIR /src/src/oBiletClone/WebAPI
RUN dotnet publish -c Release -o /app/publish


# ==== [ Runtime Image for Web App ] ====
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/publish .

# Uygulamayı başlat
ENTRYPOINT ["dotnet", "WebAPI.dll"]
