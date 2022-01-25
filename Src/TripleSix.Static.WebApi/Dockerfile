FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Src/TripleSix.Static.WebApi/TripleSix.Static.WebApi.csproj", "Src/TripleSix.Static.WebApi/"]
COPY ["Src/TripleSix.Static.Common/TripleSix.Static.Common.csproj", "Src/TripleSix.Static.Common/"]
COPY ["Src/TripleSix.Static.Quartz/TripleSix.Static.Quartz.csproj", "Src/TripleSix.Static.Quartz/"]
COPY ["Src/TripleSix.Static.Data/TripleSix.Static.Data.csproj", "Src/TripleSix.Static.Data/"]
COPY ["Src/TripleSix.Static.Middle/TripleSix.Static.Middle.csproj", "Src/TripleSix.Static.Middle/"]
RUN dotnet restore "Src/TripleSix.Static.WebApi/TripleSix.Static.WebApi.csproj"
COPY . .
WORKDIR "/src/Src/TripleSix.Static.WebApi"
RUN dotnet build "TripleSix.Static.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TripleSix.Static.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN apt-get update -qq
RUN apt-get install -yq libgdiplus
ENTRYPOINT ["dotnet", "TripleSix.Static.WebApi.dll"]
