FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY . ./
Run ls
#WORKDIR /app/CovidUi
#RUN dotnet publish -c Release 

FROM nginx:alpine

WORKDIR /var/www/web
COPY --from=build-env /app/bin/Release/netstandard2.1/publish/wwwroot .
WORKDIR /var/www/web
RUN ls
RUN cp nginx.conf /etc/nginx/nginx.conf
RUN cat /etc/nginx/nginx.conf

#RUN cp nginx.conf /etc/nginx/nginx.conf
#COPY /var/www/web/nginx.conf /etc/nginx/
EXPOSE 12345
EXPOSE 80