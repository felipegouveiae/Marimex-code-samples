#!/usr/bin/env sh

SWAGGER_URL=https://identity.hellogym.io/swagger/v1/swagger.json

npm i nswag@13.20.0

npx nswag swagger2csclient \
   /input:$SWAGGER_URL \
   /DateTimeType:System.DateTime \
   /InjectHttpClient:false \
   /classname:IdentityClient \
   /namespace:VimCorPro.Identity.Api.Client \
   /output:./IdentityClient.cs