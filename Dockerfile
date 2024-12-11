# ��� 1: ���� - ����� ������ Docker �� ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# ��� 2: Build - ����� ������ Docker �� .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["VersionMmanagementSystem.csproj", "./"]
RUN dotnet restore "./VersionMmanagementSystem.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet publish "./VersionMmanagementSystem.csproj" -c Release -o /app/publish

# ��� 3: Final - ����� ������ Runtime ����� ���������
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "VersionMmanagementSystem.dll"]
