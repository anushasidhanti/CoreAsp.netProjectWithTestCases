FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 8000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build 
WORKDIR /app
COPY MVCCore/*.csproj ./
RUN dotnet restore
COPY . .
RUN dotnet build MVCCore/*.csproj -c Release


FROM build AS publish
RUN dotnet publish MVCCore/*.csproj -c Release -o /publish


FROM base AS final
WORKDIR /app
COPY --from=publish /publish .
ENTRYPOINT ["dotnet", "MVCCore.dll"]
