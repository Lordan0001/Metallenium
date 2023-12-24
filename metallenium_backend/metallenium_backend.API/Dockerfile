#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["metallenium_backend.API/metallenium_backend.API.csproj", "metallenium_backend.API/"]
COPY ["metallenium_backend.Application/metallenium_backend.Application.csproj", "metallenium_backend.Application/"]
COPY ["metallenium_backend.Domain/metallenium_backend.Domain.csproj", "metallenium_backend.Domain/"]
COPY ["metallenium_backend.Infrastructure/metallenium_backend.Infrastructure.csproj", "metallenium_backend.Infrastructure/"]
COPY . ./
WORKDIR "/src/metallenium_backend.API"
RUN dotnet build "metallenium_backend.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "metallenium_backend.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "metallenium_backend.API.dll"]