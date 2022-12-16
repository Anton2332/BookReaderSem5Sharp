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
COPY ["project1/API1/API1.csproj", "project1/API1/"]
COPY ["project1/BLL1/BLL1.csproj", "project1/BLL1/"]
COPY ["project1/DAL1/DAL1.csproj", "project1/DAL1/"]
RUN dotnet restore "project1/API1/API1.csproj"
COPY . .
WORKDIR "/src/project1/API1"
RUN dotnet dev-certs https --trust
RUN dotnet build "API1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API1.dll"]
