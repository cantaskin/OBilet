#!/bin/bash
dotnet tool install -g dotnet-ef --version 8.0.3
export PATH="$PATH:/root/.dotnet/tools"
dotnet-ef database update --startup-project src/oBiletClone/WebAPI --project src/oBiletClone/Persistence --connection "Server=db;Database=OBiletCloneDb;User Id=sa;Password=Your_password123;TrustServerCertificate=true;"
