FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ReceiptApp.API/ReceiptApp.API.csproj", "ReceiptApp.API/"]
RUN dotnet restore "ReceiptApp.API/ReceiptApp.API.csproj"
COPY . .
WORKDIR "/src/ReceiptApp.API"
RUN dotnet build "ReceiptApp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReceiptApp.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReceiptApp.API.dll"]
