#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["project2/API2/API2.csproj", "project2/API2/"]
COPY ["SharedProject/SharedProject.csproj", "SharedProject/"]
COPY ["project2/BLL2/BLL2.csproj", "project2/BLL2/"]
COPY ["project2/DAL2/DAL2.csproj", "project2/DAL2/"]
RUN dotnet restore "project2/API2/API2.csproj"
COPY . .
WORKDIR "/src/project2/API2"
RUN dotnet build "API2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API2.dll"]