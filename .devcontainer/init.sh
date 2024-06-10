#!/bin/sh

## Restore the project
dotnet restore ./RookieShop.sln

## Restore the dotnet tools
dotnet tool restore

## Restore the npm packages
npm install --force

## Install Bun
npm install -g bun

## Install Aspire workload
dotnet workload update
dotnet workload install aspire

## Create a k3d cluster
while (! kubectl cluster-info ); do
  echo "Waiting for Docker to launch..."
  k3d cluster delete
  k3d registry create foxminchan.localhost --port 8900
  k3d cluster create -p '8081:80@loadbalancer' --k3s-arg '--disable=traefik@server:0' --registry-use k3d-foxminchan.localhost:8900
  sleep 1
done
