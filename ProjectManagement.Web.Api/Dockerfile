FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ProjectManagement.Web.Api/ProjectManagement.Web.Api.csproj", "ProjectManagement.Web.Api/"]
RUN dotnet restore "ProjectManagement.Web.Api/ProjectManagement.Web.Api.csproj"
COPY . .
WORKDIR "/src/ProjectManagement.Web.Api"
RUN dotnet build "ProjectManagement.Web.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectManagement.Web.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectManagement.Web.Api.dll"]
