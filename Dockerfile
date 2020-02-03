FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY src/DataDisplay.Api.WebApi /src/DataDisplay.Api.WebApi/
COPY src/DataDisplay.Infrastructure.Contract /src/DataDisplay.Infrastructure.Contract/
COPY src/DataDisplay.Infrastructure.Implementation /src/DataDisplay.Infrastructure.Implementation/
COPY src/DataDisplay.Application.Contract /src/DataDisplay.Application.Contract/
COPY src/DataDisplay.Application.Implementation /src/DataDisplay.Application.Implementation/
COPY src/DataDisplay.Common /src/DataDisplay.Common/
COPY src/DataDisplay.sln /src/

WORKDIR /src

# restores the required dependencies
RUN dotnet restore

# copies the rest of your code
RUN dotnet publish --output /app/

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /app
COPY --from=build-env /app .
EXPOSE 80/tcp
ENTRYPOINT ["dotnet", "DataDisplay.Api.WebApi.dll"]
