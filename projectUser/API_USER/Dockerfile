FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["projectUser/API_USER/API_USER.csproj", "API_USER/"]
RUN dotnet restore "projectUser/API_USER/API_USER.csproj"
COPY . .
WORKDIR "/src/API_USER"
RUN dotnet build "API_USER.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API_USER.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API_USER.dll"]
