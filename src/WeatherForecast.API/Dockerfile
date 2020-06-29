FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["WeatherForecast.API.csproj", "WeatherForecast.API/"]
RUN dotnet restore "WeatherForecast.API/WeatherForecast.API.csproj"
WORKDIR "/src/WeatherForecast.API"
COPY . .
RUN dotnet build "WeatherForecast.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeatherForecast.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherForecast.API.dll"]