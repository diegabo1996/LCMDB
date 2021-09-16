#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["LCMDB.IISExtractor.MicroServicio/LCMDB.IISExtractor.MicroServicio.csproj", "LCMDB.IISExtractor.MicroServicio/"]
RUN dotnet restore "LCMDB.IISExtractor.MicroServicio/LCMDB.IISExtractor.MicroServicio.csproj"
COPY . .
WORKDIR "/src/LCMDB.IISExtractor.MicroServicio"
RUN dotnet build "LCMDB.IISExtractor.MicroServicio.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LCMDB.IISExtractor.MicroServicio.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LCMDB.IISExtractor.MicroServicio.dll"]