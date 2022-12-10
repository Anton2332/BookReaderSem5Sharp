#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["project1/API1/API1.csproj", "project1/API1/"]
COPY ["SharedProject/SharedProject.csproj", "SharedProject/"]
COPY ["project1/BLL1/BLL1.csproj", "project1/BLL1/"]
COPY ["project1/DAL1/DAL1.csproj", "project1/DAL1/"]
RUN dotnet restore "project1/API1/API1.csproj"
COPY . .
WORKDIR "/src/project1/API1"
RUN dotnet build "API1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API1.dll"]