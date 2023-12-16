# Build project for Relapse
ECHO Building project for Release configuration.
dotnet clean Src/. -c Debug
dotnet clean Src/. -c Release
dotnet build Src/. -c Release

# Creating NuGet packages
ECHO Creating NuGet Package
dotnet pack Src/. --include-symbols --force -c Release --output ./Packages/NuGet/.

# Creating Unity NPM Project
ECHO Step 1: Publishing Code for Unity Package
export LOCATION=com.iPAHeartBeat.Core.Dependency
# rm Unity/Packages/$LOCATION/Runtime/* -r
dotnet publish Src/$LOCATION.csproj -c Release --no-dependencies --framework net471 --output ./Unity/Packages/$LOCATION/Runtime/.

# For Step two first update Package in Unity, remove duplicate files, and Run ExportNPM-Mac.bat
