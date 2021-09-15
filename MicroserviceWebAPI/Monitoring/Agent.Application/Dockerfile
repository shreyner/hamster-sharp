FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Agent.Application/Agent.Application.csproj", "Agent.Application/"]
RUN dotnet restore "Agent.Application/Agent.Application.csproj"
COPY . .
WORKDIR "/src/Agent.Application"
RUN dotnet build "Agent.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Agent.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Agent.Application.dll"]
