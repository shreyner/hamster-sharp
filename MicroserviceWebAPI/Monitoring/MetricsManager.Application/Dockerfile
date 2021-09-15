FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MetricsManager.Application/MetricsManager.Application.csproj", "MetricsManager.Application/"]
RUN dotnet restore "MetricsManager.Application/MetricsManager.Application.csproj"
COPY . .
WORKDIR "/src/MetricsManager.Application"
RUN dotnet build "MetricsManager.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MetricsManager.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MetricsManager.Application.dll"]
