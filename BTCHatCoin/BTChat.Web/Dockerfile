FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["BTChat.Web/BTChat.Web.csproj", "BTChat.Web/"]
RUN dotnet restore "BTChat.Web/BTChat.Web.csproj"
COPY . .
WORKDIR "/src/BTChat.Web"
RUN dotnet build "BTChat.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BTChat.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BTChat.Web.dll"]