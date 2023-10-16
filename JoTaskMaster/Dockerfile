#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["JoTaskMaster/JoTaskMaster.csproj", "JoTaskMaster/"]
RUN dotnet restore "JoTaskMaster/JoTaskMaster.csproj"
COPY . .
WORKDIR "/src/JoTaskMaster"
RUN dotnet build "JoTaskMaster.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JoTaskMaster.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JoTaskMaster.dll"]