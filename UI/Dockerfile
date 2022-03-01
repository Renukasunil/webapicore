FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY "LMS.sln" "LMS.sln"

COPY "LMS.Model/LMS.Model.csproj" "LMS.Model/LMS.Model.csproj"
COPY "LMS.Service/LMS.Service.csproj" "LMS.Service/LMS.Service.csproj"
COPY "LMS.API/LMS.API.csproj" "LMS.API/LMS.API.csproj"
COPY "UI/UI.csproj" "UI/UI.csproj"

RUN dotnet restore "LMS.sln"
COPY . .

WORKDIR /src/UI
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build /app .
ENTRYPOINT ["dotnet", "UI.dll"]