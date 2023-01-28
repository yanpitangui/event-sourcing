FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EventSourcing.Api/EventSourcing.Api.csproj", "EventSourcing.Api/"]
RUN dotnet restore "EventSourcing.Api/EventSourcing.Api.csproj"
COPY . .
WORKDIR "/src/EventSourcing.Api"
RUN dotnet build "EventSourcing.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EventSourcing.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventSourcing.Api.dll"]
