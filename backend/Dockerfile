FROM mcr.microsoft.com/dotnet/sdk:9.0 as build
WORKDIR /src

#Restore
COPY ["RestFulAPI.API/RestFulAPI.API.csproj", "RestFulAPI.API/"]
COPY ["RestFulAPI.Application/RestFulAPI.Application.csproj", "RestFulAPI.Application/"]
COPY ["RestFulAPI.Core/RestFulAPI.Core.csproj", "RestFulAPI.Core/"]
COPY ["RestFulAPI.DataAccess/RestFulAPI.DataAccess.csproj", "RestFulAPI.DataAccess/"]
COPY ["RentProjectTests/RentProjectTests.csproj", "RentProjectTests/"]
COPY ["RestFulAPI.sln","./"]
RUN dotnet restore

#Build
COPY . .
RUN dotnet build -c Release -o /app/build

#Publish
FROM build as publish
RUN dotnet publish -c Release -o /app/publish

#Run
FROM mcr.microsoft.com/dotnet/aspnet:9.0
ENV ASPNETCORE_HTTP_PORTS=29180
EXPOSE 29180
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RestFulAPI.API.dll"]