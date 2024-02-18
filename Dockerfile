# Base Image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build Image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["KanbanBlazorServer.csproj", "."]
RUN dotnet restore "./KanbanBlazorServer.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "KanbanBlazorServer.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish Image
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "KanbanBlazorServer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
RUN chown -R app:app /app/publish

# Final Image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN chmod 664 /app/*.db

ENTRYPOINT ["dotnet", "KanbanBlazorServer.dll"]
