FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["JoTaskMaster/JoTaskMaster.Api.csproj", "JoTaskMaster/"]
COPY ["JoTaskMaster.Application.Validation/JoTaskMaster.Application.Validation.csproj", "JoTaskMaster.Application.Validation/"]
COPY ["JoTaskMaster.Application/JoTaskMaster.Application.csproj", "JoTaskMaster.Application/"]
COPY ["JoTaskMaster.Domain/JoTaskMaster.Domain.csproj", "JoTaskMaster.Domain/"]
COPY ["JoTaskMaster.Persistence.RelationalDB/JoTaskMaster.Persistence.RelationalDB.csproj", "JoTaskMaster.Persistence.RelationalDB/"]
COPY ["JoTaskMaster.Shared/JoTaskMaster.Shared.csproj", "JoTaskMaster.Shared/"]
COPY ["JoTaskMaster.Infrastructure.Services/JoTaskMaster.Infrastructure.Services.csproj", "JoTaskMaster.Infrastructure.Services/"]
RUN dotnet restore "JoTaskMaster/JoTaskMaster.Api.csproj"
COPY . .
WORKDIR "/src/JoTaskMaster"
RUN dotnet build "JoTaskMaster.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JoTaskMaster.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JoTaskMaster.Api.dll"]
