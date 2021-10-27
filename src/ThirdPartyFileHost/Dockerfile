# Start with the build image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# Copy the project file into image and perform restore
COPY ThirdPartyFileHost.csproj ./
RUN dotnet restore

# Once restore is complete, we can copy the remaining files in
COPY ./ ./
RUN dotnet publish -c Release -o /build

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80/tcp

COPY --from=build /build .

ENTRYPOINT ["dotnet", "ThirdPartyFileHost.dll"]