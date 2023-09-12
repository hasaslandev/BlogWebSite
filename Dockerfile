FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR  /app

COPY ./Entity/*.csproj ./Entity/
COPY ./CoreL/*.csproj ./CoreL/
COPY ./BlogProjesi/*.csproj ./BlogProjesi/
COPY ./BlogProjesiAPI/*.csproj ./BlogProjesiAPI/
COPY ./Business/*.csproj ./Business/
COPY ./DataAccess/*.csproj ./DataAccess/
COPY ./BlogProject/*.csproj ./BlogProject/
COPY *.sln .
RUN dotnet restore
COPY . .
RUN dotnet publish ./BlogProjesi/*.csproj -o /publish/
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /publish .
ENV ASPNETCORE_URLS="http://*:5000"
ENTRYPOINT ["dotnet","BlogProjesi.dll"]