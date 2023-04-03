#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Paylocity.Benefits.Presentation.Api/Paylocity.Benefits.Presentation.Api.csproj", "Paylocity.Benefits.Presentation.Api/"]
RUN dotnet restore "Paylocity.Benefits.Presentation.Api/Paylocity.Benefits.Presentation.Api.csproj"
COPY . .
WORKDIR "/src/Paylocity.Benefits.Presentation.Api"
RUN dotnet build "Paylocity.Benefits.Presentation.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Paylocity.Benefits.Presentation.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Paylocity.Benefits.Presentation.Api.dll"]