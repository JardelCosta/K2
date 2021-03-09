#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["K2.Juros/K2.Juros.csproj", "K2.Juros/"]
COPY ["K2.Application/K2.Application.csproj", "K2.Application/"]
RUN dotnet restore "K2.Juros/K2.Juros.csproj"
COPY . .
WORKDIR "/src/K2.Juros"
RUN dotnet build "K2.Juros.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "K2.Juros.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "K2.Juros.dll"]