# Dockerfile — place in the same folder as CampSessionAPI.csproj

# Stage 1 Build
FROM mcr.microsoft.comdotnetsdk8.0 AS build
WORKDIR app
COPY .csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o out

# Stage 2 Runtime
FROM mcr.microsoft.comdotnetaspnet8.0 AS runtime
WORKDIR app
COPY --from=build appout .

# Render assigns PORT via environment variable
ENV ASPNETCORE_URLS=http+$PORT
EXPOSE 8080

ENTRYPOINT [dotnet, CampSessionAPI.dll]
