FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ./back-end/back-end.csproj ./back-end/
RUN dotnet restore "./back-end/back-end.csproj"
COPY ./back-end/ ./back-end/
WORKDIR /src/back-end
RUN dotnet build "back-end.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "back-end.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "back-end.dll"]
