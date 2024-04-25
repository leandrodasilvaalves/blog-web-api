FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY src/Blog.Api/Blog.Api.csproj ./src/Blog.Api/Blog.Api.csproj 
COPY src/Blog.Contracts/Blog.Contracts.csproj ./src/Blog.Contracts/Blog.Contracts.csproj
RUN dotnet restore ./src/Blog.Api/Blog.Api.csproj

COPY src/Blog.Api/ ./src/Blog.Api/
COPY src/Blog.Contracts/ ./src/Blog.Contracts/
RUN dotnet build ./src/Blog.Api/Blog.Api.csproj --no-restore --configuration Release --output ./build

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY --from=build-env /app/build .
CMD ["dotnet", "Blog.Api.dll"]