FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MWALesson_1/MWALesson_1.csproj", "MWALesson_1/"]
RUN dotnet restore "MWALesson_1/MWALesson_1.csproj"
COPY . .
WORKDIR "/src/MWALesson_1"
RUN dotnet build "MWALesson_1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MWALesson_1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MWALesson_1.dll"]
