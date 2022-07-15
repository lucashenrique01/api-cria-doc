FROM mcr.microsoft.com/dotnet/runtime:6.0-focal AS base
WORKDIR /app

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["api-cria-doc.csproj", "./"]
RUN dotnet restore "api-cria-doc.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "api-cria-doc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api-cria-doc.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api-cria-doc.dll"]
