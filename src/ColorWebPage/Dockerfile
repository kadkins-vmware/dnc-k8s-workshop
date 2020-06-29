FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ColorWebPage.csproj", "ColorWebPage/"]
RUN dotnet restore "ColorWebPage/ColorWebPage.csproj"
WORKDIR "/src/ColorWebPage"
COPY . .
RUN dotnet build "ColorWebPage.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ColorWebPage.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ColorWebPage.dll"]