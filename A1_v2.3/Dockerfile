#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 as build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY A1_v2.3/A1_v2.3.csproj A1_v2.3/
RUN dotnet restore "A1_v2.3/A1_v2.3.csproj"
COPY . .
WORKDIR "/src/A1_v2.3"
RUN dotnet build "A1_v2.3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "A1_v2.3.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "A1_v2.3.dll"]
