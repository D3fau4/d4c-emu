FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["sun/sun.csproj", "sun/"]
RUN dotnet restore "sun/sun.csproj"
COPY . .
WORKDIR "/src/sun"
RUN dotnet build "sun.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "sun.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "sun.dll"]
