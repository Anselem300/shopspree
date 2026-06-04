# ======================
# BUILD STAGE
# ======================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copy everything
COPY . .

# restore ONLY main web project
RUN dotnet restore ShopSpree.Web/ShopSpree.Web.csproj

# publish ONLY web project
RUN dotnet publish ShopSpree.Web/ShopSpree.Web.csproj -c Release -o /app/publish

# ======================
# RUNTIME STAGE
# ======================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "shopspree.web.dll"]