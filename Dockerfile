#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["wxhshine.Interface.RestAPI/wxhshine.Interface.RestAPI.csproj", "wxhshine.Interface.RestAPI/"]
COPY ["wxhshine.Domain.IRepositories/wxhshine.Domain.IRepositories.csproj", "wxhshine.Domain.IRepositories/"]
COPY ["wxhshine.Domian.Entities/wxhshine.Domian.Entities.csproj", "wxhshine.Domian.Entities/"]
COPY ["wxhshine.Infrastructure.Common/wxhshine.Infrastructure.Common.csproj", "wxhshine.Infrastructure.Common/"]
COPY ["wxhshine.Domain.Repositories/wxhshine.Domain.Repositories.csproj", "wxhshine.Domain.Repositories/"]
COPY ["wxhshine.Application.DTO/wxhshine.Application.DTO.csproj", "wxhshine.Application.DTO/"]
RUN dotnet restore "wxhshine.Interface.RestAPI/wxhshine.Interface.RestAPI.csproj"
COPY . .
WORKDIR "/src/wxhshine.Interface.RestAPI"
RUN dotnet build "wxhshine.Interface.RestAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "wxhshine.Interface.RestAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "wxhshine.Interface.RestAPI.dll"]