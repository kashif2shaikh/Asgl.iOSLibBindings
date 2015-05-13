# Asgl.iOSLibBindings
C# Bindings to Native iOS Libraries

A project designed to make it easy to download cocoapods and generate universal libs and bindings for Xamarin bindings.

# HOW TO

First add your pods to Xcode/Podfile and run pod install or pod update. This will fetch the cocoapods and generate the Pods directory.

Under Asgl.iOSLibsBinding, run Scripts/UniversalLibs.sh. This will generate the fat libraries (for simulator, armv7, arm64) for each pod under iOSLibs/build/universal/{Debug|Release}

Then run Scripts/SharpieBind.sh . This will generate the ApiDefinition.cs and StructAndEnums.cs for the pod from headers in iOSLibs/Pods/Header/Public/ and store results under Asgl.iOSLibsBinding/.

Open Asgl.iOSLibsBinding solution file and import directory with ApiDefinition.cs and StructAndEnums.cs into the iOSLibsBinding project. Also import the generate fat library from iOSLib/build/universal/Release/.a

Verify/Modify ApiDefinition per sharpie output.

Build library and import iOSLibsBinding project into your other solutions and Enjoy!

#NUGET Export

Build your Binding project under Mac or Windows (latest Xamarin supports this). Edit the Asgl.iOSLibBindings.nuspec with -1 for the 3rd component of the version number.
Then run pack_Asgl.iOSLibBindings.bat from Windows to create package and push to nuget server.

ENJOY!
