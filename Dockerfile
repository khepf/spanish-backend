FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /back-end
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /back-end
COPY ["back-end.csproj", "./"]
RUN dotnet restore "back-end.csproj"
COPY . .
WORKDIR /back-end
RUN dotnet build "back-end.csproj" -c Release -o /back-end/build

FROM build AS publish
RUN dotnet publish "back-end.csproj" -c Release -o /back-end/publish

FROM base AS final
WORKDIR /back-end
COPY --from=publish /back-end/publish .
ENTRYPOINT ["dotnet", "back-end.dll"]
