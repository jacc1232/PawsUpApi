FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:5000

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["PetsManagerApi.csproj", "./"]
RUN dotnet restore "PetsManagerApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "PetsManagerApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PetsManagerApi.csproj" -c Release -o /app/publish /p:UseAppHost=false
RUN apt-get update && apt-get install -y libssl-dev


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetsManagerApi.dll"]
