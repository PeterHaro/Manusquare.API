FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Source/Manusquare.API/Manusquare.API.csproj", "Source/Manusquare.API/"]
RUN dotnet restore "Source/Manusquare.API/Manusquare.API.csproj"
COPY . .
WORKDIR "/src/Source/Manusquare.API"
RUN dotnet build "Manusquare.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Manusquare.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Manusquare.API.dll"]