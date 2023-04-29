#!/bin/sh


VERSION="1.0.0"
echo "Create Nuget V $VERSION"


dotnet pack ./DependencyInjectionAttributeNet/DependencyInjectionAttributeNet.csproj --configuration Release -p:VersionPrefix=$VERSION

