#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
COPY . .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet TZ_sogaz.dll
#EXPOSE 8443

#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /src
#COPY ["TZ_sogaz/TZ_sogaz.csproj", "TZ_sogaz/"]
#RUN dotnet restore "TZ_sogaz/TZ_sogaz.csproj"
#COPY . .
#WORKDIR "/src/TZ_sogaz"
#RUN dotnet build "TZ_sogaz.csproj" -c Release -o /app/build

#FROM build AS publish
#RUN dotnet publish "TZ_sogaz.csproj" -c Release -o /app/publish

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "TZ_sogaz.dll"]