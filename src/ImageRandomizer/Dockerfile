FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0

RUN apt-get update && apt-get install -y apt-utils \
    && apt-get install -y libfontconfig1 \
    && apt-get install -y libgdiplus \
    && apt-get install -y libc6-dev \
    && ln -s /usr/lib/libgdiplus.so/usr/lib/gdiplus.dll

WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "ImageRandomizer.dll"]