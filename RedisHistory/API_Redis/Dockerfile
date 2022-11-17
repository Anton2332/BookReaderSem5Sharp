FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RedisHistory/API_Redis/API_Redis.csproj", "API_Redis/"]
RUN dotnet restore "RedisHistory/API_Redis/API_Redis.csproj"
COPY . .
WORKDIR "/src/API_Redis"
RUN dotnet build "API_Redis.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API_Redis.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API_Redis.dll"]
