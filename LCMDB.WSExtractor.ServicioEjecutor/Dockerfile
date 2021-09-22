#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["LCMDB.WSExtractor.ServicioEjecutor/LCMDB.WSExtractor.ServicioEjecutor.csproj", "LCMDB.WSExtractor.ServicioEjecutor/"]
RUN dotnet restore "LCMDB.WSExtractor.ServicioEjecutor/LCMDB.WSExtractor.ServicioEjecutor.csproj"
COPY . .
WORKDIR "/src/LCMDB.WSExtractor.ServicioEjecutor"
RUN dotnet build "LCMDB.WSExtractor.ServicioEjecutor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LCMDB.WSExtractor.ServicioEjecutor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LCMDB.WSExtractor.ServicioEjecutor.dll"]