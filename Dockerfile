FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
EXPOSE 80

# Copy csproj and restore as distinct layers
COPY *.sln ./
COPY Bpm.Api/*.csproj ./Bpm.Api/
COPY Bpm.Logic/*.csproj ./Bpm.Logic/
COPY Identity.Api/*.csproj ./dentity.Api/
COPY Identity.Logic/*.csproj ./Identity.Logic/
COPY Integration.Api/*.csproj ./Integration.Api/
COPY Integration.Logic/*.csproj ./Integration.Logic/
COPY Admin.Api/*.csproj ./Admin.Api/
COPY Admin.Logic/*.csproj ./Admin.Logic/
COPY Test.Api/*.csproj ./Test.Api/
COPY Test.Logic/*.csproj ./Test.Logic/
COPY Scoring.Api/*.csproj ./Scoring.Api/
COPY Scoring.Logic/*.csproj ./Scoring.Logic/
COPY Shared.Api/*.csproj ./Shared.Api/
COPY Shared.Data/*.csproj ./Shared.Data/
COPY Shared.Logic/*.csproj ./Shared.Logic/
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish 'Agro.Bpm.Api' -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Agro.Bpm.Api.dll"]