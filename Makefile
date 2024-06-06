include .env
export

.PHONY: publish
publish-all-dockers: publish-api publish-identity publish-storefront publish-backoffice

.PHONY: publish-api
publish-api:
	dotnet publish ./src/RookieShop.ApiService/RookieShop.ApiService.csproj --os linux --arch x64 /t:PublishContainer -c Release
	docker tag rookieshop-webapi:latest ghcr.io/foxminchan/rookieshop/rookieshop-webapi:${VERSION}
	docker rmi rookieshop-webapi:latest
	docker push ghcr.io/foxminchan/rookieshop/rookieshop-webapi:${VERSION}

.PHONY: publish-identity
publish-identityserver:
	dotnet publish ./src/RookieShop.IdentityService/RookieShop.IdentityService.csproj --os linux --arch x64 /t:PublishContainer -c Release
	docker tag rookieshop-identity:latest ghcr.io/foxminchan/rookieshop/rookieshop-identity:${VERSION}
	docker rmi rookieshop-identity:latest
	docker push ghcr.io/foxminchan/rookieshop/rookieshop-identity:${VERSION}

.PHONY: publish-storefront
publish-storefront:
	dotnet publish ./ui/storefront/RookieShop.Storefront.csproj --os linux --arch x64 /t:PublishContainer -c Release
	docker tag rookieshop-storefront:latest ghcr.io/foxminchan/rookieshop/rookieshop-storefront:${VERSION}
	docker rmi rookieshop-storefront:latest
	docker push ghcr.io/foxminchan/rookieshop/rookieshop-storefront:${VERSION}

.PHONY: publish-backoffice
publish-backoffice:
	docker build -f ./ui/backoffice/Dockerfile . --tag ghcr.io/foxminchan/rookieshop/rookieshop-backoffice:${VERSION}
	docker rmi rookieshop-backoffice:latest
	docker push ghcr.io/foxminchan/rookieshop/rookieshop-backoffice:${VERSION}
