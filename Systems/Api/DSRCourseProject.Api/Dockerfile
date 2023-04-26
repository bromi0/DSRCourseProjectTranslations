#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/Api/DSRCourseProject.Api/DSRCourseProject.Api.csproj", "Systems/Api/DSRCourseProject.Api/"]
COPY ["Services/DSRCourseProject.Services.Settings/DSRCourseProject.Services.Settings.csproj", "Services/DSRCourseProject.Services.Settings/"]
COPY ["Shared/DSRCourseProject.Settings/DSRCourseProject.Settings.csproj", "Shared/DSRCourseProject.Settings/"]
COPY ["Shared/DSRCourseProject.Common/DSRCourseProject.Common.csproj", "Shared/DSRCourseProject.Common/"]
COPY ["Systems/Api/DSRCourseProject.Api.Settings/DSRCourseProject.Api.Settings.csproj", "Systems/Api/DSRCourseProject.Api.Settings/"]
RUN dotnet restore "Systems/Api/DSRCourseProject.Api/DSRCourseProject.Api.csproj"
COPY . .
WORKDIR "/src/Systems/Api/DSRCourseProject.Api"
RUN dotnet build "DSRCourseProject.Api.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "DSRCourseProject.Api.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DSRCourseProject.Api.dll"]