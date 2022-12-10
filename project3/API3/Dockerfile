#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["project3/API3/API3.csproj", "project3/API3/"]
COPY ["SharedProject/SharedProject.csproj", "SharedProject/"]
COPY ["project3/Application/Application.csproj", "project3/Application/"]
COPY ["project3/Domain/Domain.csproj", "project3/Domain/"]
COPY ["project3/Infrastructure/Infrastructure.csproj", "project3/Infrastructure/"]
RUN dotnet restore "project3/API3/API3.csproj"
COPY . .
WORKDIR "/src/project3/API3"
RUN dotnet build "API3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API3.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API3.dll"]