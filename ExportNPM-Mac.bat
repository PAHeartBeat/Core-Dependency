ECHO Step 2: Removing Extra DLLs
export LOCATION=com.iPAHeartBeat.Core.Dependency
rm ./Unity/Packages/$LOCATION/Runtime/Newtonsoft.Json.dll -f

# Create Node package for Unity
ECHO Step 3: Creating Node Package for Unity Package Manager.
cd Unity/Packages/$LOCATION
npm pack --pack-destination="../../../Packages/UnityNPM/"
cd ..
cd ..
cd ..
ECHO Packages are Created.
