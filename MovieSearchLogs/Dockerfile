# Stage 1: Setup
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Restore
COPY MovieSearchLogs/*.csproj ./MovieSearchLogs/
RUN dotnet restore ./MovieSearchLogs/MovieSearchLogs.csproj

# Stage 2: Build and publish
COPY . ./
RUN dotnet publish ./MovieSearchLogs/MovieSearchLogs.csproj -c Release -o out

# Stage 3: Run
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "MovieSearchLogs.dll"]
