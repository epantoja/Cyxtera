#******************************************#
#***************  IMAGE BUILD *************#
#******************************************#
FROM alexsuch/angular-cli:7.0.4 as build

# FROM alexsuch/angular-cli:7.0.4

# LABEL authors="Alejandro Such <alejandro.such@gmail.com> , Mihai Bob <mihai.m.bob@gmail.com>"

# RUN apk update \
#   && npm install -g @angular/cli@7.0.2 \
#   && rm -rf /tmp/* /var/cache/apk/* *.tar.gz ~/.npm \
#   && npm cache clear --force \
#   && yarn cache clean \
#   && sed -i -e "s/bin\/ash/bin\/sh/" /etc/passwd

WORKDIR /app
ADD . .
RUN npm install > /dev/null 2>&1
RUN ng build --prod

#******************************************#
#***************  IMAGE CLIENT ************#
#******************************************#
FROM nginx
RUN rm -rf /usr/share/nginx/html/*
WORKDIR /usr/share/nginx/html
COPY --from=build /app/dist/CYXTERA .

# CMD [ "sh" ]