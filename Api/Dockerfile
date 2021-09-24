FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY . ./
RUN dotnet restore "ResourceManagementApi.csproj"
RUN dotnet publish "ResourceManagementApi.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
ENV TZ=America/Sao_Paulo
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ResourceManagementApi.dll"]