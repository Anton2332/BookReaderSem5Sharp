FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5065

ENV ASPNETCORE_URLS=http://+:5065

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["project3/API3/API3.csproj", "project3/API3/"]
COPY ["project3/Application/Application.csproj", "project3/Application/"]
COPY ["project3/Domain/Domain.csproj", "project3/Domain/"]
COPY ["project3/Infrastructure/Infrastructure.csproj", "project3/Infrastructure/"]
COPY ["SharedProject/SharedProject.csproj", "SharedProject/"]
RUN dotnet restore "project3/API3/API3.csproj"
COPY . .
WORKDIR "/src/project3/API3"
RUN dotnet dev-certs https --trust
RUN dotnet build "API3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API3.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API3.dll"]
