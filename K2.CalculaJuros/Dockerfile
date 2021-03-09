#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["K2.CalculaJuros/K2.CalculaJuros.csproj", "K2.CalculaJuros/"]
COPY ["K2.CalculaJuros.Application/K2.CalculaJuros.Application.csproj", "K2.CalculaJuros.Application/"]
RUN dotnet restore "K2.CalculaJuros/K2.CalculaJuros.csproj"
COPY . .
WORKDIR "/src/K2.CalculaJuros"
RUN dotnet build "K2.CalculaJuros.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "K2.CalculaJuros.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "K2.CalculaJuros.dll"]