#!/bin/sh


VERSION="0.1.0"
echo "Create Nuget V $VERSION"


dotnet pack ./DependencyInjectionAttributeNet/DependencyInjectionAttributeNet.csproj --configuration Release -p:VersionPrefix=$VERSION
dotnet nuget push "DependencyInjectionAttributeNet/bin/Release/DependencyInjectionAttributeNet.$VERSION.nupkg" --source "davil74"
