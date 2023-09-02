#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebNews.API/WebNews.API.csproj", "WebNews.API/"]
COPY ["WebNews.Application/WebNews.Application.csproj", "WebNews.Application/"]
COPY ["WebNews.Domain/WebNews.Domain.csproj", "WebNews.Domain/"]
COPY ["WebNews.Service/WebNews.Service.csproj", "WebNews.Service/"]
COPY ["WebNews.Infrastructure/WebNews.Infrastructure.csproj", "WebNews.Infrastructure/"]
COPY ["WebNews.IoC/WebNews.IoC.csproj", "WebNews.IoC/"]
RUN dotnet restore "WebNews.API/WebNews.API.csproj"
COPY . .
WORKDIR "/src/WebNews.API"
RUN dotnet build "WebNews.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebNews.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebNews.API.dll"]