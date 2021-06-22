# docker build -t kubedemo-public-service:latest -f Dockerfile ../..

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

COPY ["src/PublicService/PublicService.csproj", "/project/src/PublicService/"]
RUN dotnet restore "/project/src/PublicService/PublicService.csproj"

COPY "src/PublicService" "/project/src/PublicService/"
COPY "KubernetesDemo.src.ruleset" "/project/"
COPY "LICENSE.txt" "/project/"

RUN dotnet build "/project/src/PublicService/PublicService.csproj" --no-restore -c Release

FROM build AS publish
RUN dotnet publish "/project/src/PublicService/PublicService.csproj" --no-build -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish /app

ENTRYPOINT ["dotnet", "PublicService.dll"]
