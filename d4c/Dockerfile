FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["d4c/d4c.csproj", "d4c/"]
RUN dotnet restore "d4c/d4c.csproj"
COPY . .
WORKDIR "/src/d4c"
RUN dotnet build "d4c.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "d4c.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ADD "d4c/contents" /app
ADD "d4c/prod.keys" /app/prod.keys
ENTRYPOINT ["dotnet", "d4c.dll"]
