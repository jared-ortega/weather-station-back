# Runtime for ARM64
FROM mcr.microsoft.com/dotnet/aspnet:8.0-bullseye-slim-arm64v8 AS base
WORKDIR /app
EXPOSE 80

# Build ARM64
FROM mcr.microsoft.com/dotnet/sdk:8.0-bullseye-slim-arm64v8 AS build
WORKDIR /src

# Copy and restore dependencies
COPY . .
RUN dotnet publish weather-station-back.csproj -c Release -r linux-arm64 --self-contained true -o /app/publish

# Final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["./weather-station-back"]
