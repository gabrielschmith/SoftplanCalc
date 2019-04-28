FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY SoftplanCalc/SoftplanCalc.Api.csproj SoftplanCalc/
COPY SoftplanCalc.Models/SoftplanCalc.Models.csproj SoftplanCalc.Models/
COPY SoftplanCalc.Services/SoftplanCalc.Services.csproj SoftplanCalc.Services/
COPY SoftplanCalc.Logger/SoftplanCalc.Logger.csproj SoftplanCalc.Logger/
COPY SoftplanCalc.Utils/SoftplanCalc.Utils.csproj SoftplanCalc.Utils/
RUN dotnet restore SoftplanCalc/SoftplanCalc.Api.csproj
COPY . .
WORKDIR /src/SoftplanCalc
RUN dotnet build SoftplanCalc.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SoftplanCalc.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SoftplanCalc.Api.dll"]
