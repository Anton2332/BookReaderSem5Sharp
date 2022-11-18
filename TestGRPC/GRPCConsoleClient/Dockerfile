FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TestGRPC/GRPCConsoleClient/GRPCConsoleClient.csproj", "GRPCConsoleClient/"]
RUN dotnet restore "TestGRPC/GRPCConsoleClient/GRPCConsoleClient.csproj"
COPY . .
WORKDIR "/src/GRPCConsoleClient"
RUN dotnet build "GRPCConsoleClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GRPCConsoleClient.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GRPCConsoleClient.dll"]
