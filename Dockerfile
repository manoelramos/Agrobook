#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Agrobook.Api/Agrobook.Api.csproj", "Agrobook.Api/"]
COPY ["Agrobook.Infra.Data/Agrobook.Infra.Data.csproj", "Agrobook.Infra.Data/"]
COPY ["Agrobook.Domain/Agrobook.Domain.csproj", "Agrobook.Domain/"]
COPY ["Agrobook.Domain.Core/Agrobook.Domain.Core.csproj", "Agrobook.Domain.Core/"]
COPY ["Agrobook.Application/Agrobook.Application.csproj", "Agrobook.Application/"]
RUN dotnet restore "Agrobook.Api/Agrobook.Api.csproj"
COPY . .
WORKDIR "/src/Agrobook.Api"
RUN dotnet build "Agrobook.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Agrobook.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS http://+:80
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "Agrobook.Api.dll"]