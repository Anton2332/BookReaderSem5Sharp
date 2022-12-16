FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5172

ENV ASPNETCORE_URLS=http://+:5172

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["project2/API2/API2.csproj", "project2/API2/"]
COPY ["project2/BLL2/BLL2.csproj", "project2/BLL2/"]
COPY ["project2/DAL2/DAL2.csproj", "project2/DAL2/"]
COPY ["SharedProject/SharedProject.csproj", "SharedProject/"]
RUN dotnet restore "project2/API2/API2.csproj"
COPY . .
WORKDIR "/src/project2/API2"
RUN dotnet dev-certs https --trust
RUN dotnet build "API2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API2.dll"]
