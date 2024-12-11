# ��� 1: ���� - ����� ������ Docker �� ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# ��� 2: Build - ����� ������ Docker �� .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["YourProjectName.csproj", "./"]
RUN dotnet restore "./YourProjectName.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet publish "./YourProjectName.csproj" -c Release -o /app/publish

# ��� 3: Final - ����� ������ Runtime ����� ���������
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "YourProjectName.dll"]
