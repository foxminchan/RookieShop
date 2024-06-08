include .env
export

.PHONY: publish
publish-all-dockers: publish-api publish-identity publish-storefront publish-backoffice publish-bff

.PHONY: publish-api
publish-api:
	dotnet publish ./src/RookieShop.ApiService/RookieShop.ApiService.csproj --os linux --arch x64 /t:PublishContainer -c Release
	docker tag rookieshop-apiservice:latest ghcr.io/foxminchan/rookieshop/rookieshop-apiservice:${VERSION}
	docker rmi rookieshop-apiservice:latest
	docker push ghcr.io/foxminchan/rookieshop/rookieshop-apiservice:${VERSION}

.PHONY: publish-identity
publish-identityserver:
	dotnet publish ./src/RookieShop.IdentityService/RookieShop.IdentityService.csproj --os linux --arch x64 /t:PublishContainer -c Release
	docker tag rookieshop-identityservice:latest ghcr.io/foxminchan/rookieshop/rookieshop-identityservice:${VERSION}
	docker rmi rookieshop-identityservice:latest
	docker push ghcr.io/foxminchan/rookieshop/rookieshop-identityservice:${VERSION}

.PHONY: publish-storefront
publish-storefront:
	dotnet publish ./ui/storefront/RookieShop.Storefront.csproj --os linux --arch x64 /t:PublishContainer -c Release
	docker tag rookieshop-storefront:latest ghcr.io/foxminchan/rookieshop/rookieshop-storefront:${VERSION}
	docker rmi rookieshop-storefront:latest
	docker push ghcr.io/foxminchan/rookieshop/rookieshop-storefront:${VERSION}

.PHONY: publish-bff
publish-bff:
	dotnet publish ./src/RookieShop.Bff/RookieShop.Bff.csproj --os linux --arch x64 /t:PublishContainer -c Release
	docker tag rookieshop-bff:latest ghcr.io/foxminchan/rookieshop/rookieshop-bff:${VERSION}
	docker rmi rookieshop-bff:latest
	docker push ghcr.io/foxminchan/rookieshop/rookieshop-bff:${VERSION}

.PHONY: publish-backoffice
publish-backoffice:
	docker build -f ./ui/backoffice/Dockerfile . --tag ghcr.io/foxminchan/rookieshop/rookieshop-backoffice:${VERSION}
	docker rmi rookieshop-backoffice:latest
	docker push ghcr.io/foxminchan/rookieshop/rookieshop-backoffice:${VERSION}
