# Get base SDK Image from Microsoft
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy the csproj file and restore any dependencies.
COPY *.csproj ./
RUN dotnet restore

# Copy the project files and build
#RUN apt-get update && \   
    #apt-get install -y gnupg  libgconf-2-4 wget && \
    #wget -q -O - https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add - && \
    #sh -c 'echo "deb [arch=amd64] http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google.list' && \
    #apt-get update && \
    #apt-get install -y google-chrome-unstable --no-install-recommends
#
COPY . ./
RUN dotnet publish -c Release -o out

# Generate runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "BankJoakim.dll"]


