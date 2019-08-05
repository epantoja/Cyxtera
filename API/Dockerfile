#******************************************#
#***************  IMAGE BUILD *************#
#******************************************#
FROM microsoft/dotnet:sdk AS build-env
ADD . /app
WORKDIR /app
RUN dotnet restore
RUN dotnet publish -c Release -o out

#******************************************#
#***************  IMAGE SERVER ************#
#******************************************#
FROM microsoft/dotnet:sdk
WORKDIR /app
COPY --from=build-env /app/out .
COPY --from=build-env /app/Cyxtera.db .
ENTRYPOINT ["dotnet", "API.dll"]