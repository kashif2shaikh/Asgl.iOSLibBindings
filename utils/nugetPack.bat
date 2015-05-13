@echo off
rem Batch command to create ASGL NuGet packages.
rem Requires nuget.exe and xml.exe
rem Modified to add "Platform=AnyCPU" to build for iOS

setlocal

set "nugetServ=http://vmdev/NugetServer/api/v2/package"
set "SymbSrcServ=http://vmdev/SymbolSource/Nuget"
set "apikey=AsglNuget"

set /a "pre=0"
set /a "created=0"
set /a "push=0"

set "ver="
set "out="

if "%1"=="" goto :error
:start
if "%1"=="-pre" (set /a pre=1 && shift)
if "%1"=="-out" if "%3"=="" (goto :error) else ((if not exist %2 (mkdir %2)) && set "out=%2" && shift && shift)
if "%1"=="-ver" if "%3"=="" (goto :error) else (set "ver=%2" && shift && shift)
if "%1"=="-push" (set /a push=1 && shift)

rem additional flags

if "%2"=="" (goto :main) 
rem else if "%2"=="-r"  if not "%3"=="" (goto :main) else (goto :error)
goto :start

:main
rem set year
For /f "tokens=4 delims=/ " %%a in ('date /t') do (set year=%%a)

rem Strip trailing \ from path and set proj to project name (last path element)
set "p=%1::::"
set "p=%p:\::::=%"
set "p=%p:/::::=%"
set "p=%p:::::=%"

set "projPath=%p%\"
if not exist %projPath% (goto :error)

for %%a in ("%p%") do (set "proj=%%~na%%~xa")

if not exist %projPath%%proj%.nuspec (echo Cannot find %projPath%%proj%.nuspec && goto :end)

echo Creating NuGet package for "%proj%"

rem read version from nuspec
for /f %%i in ('XML.EXE sel -N "nuspec=http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd" -t -v "//nuspec:version" %projPath%%proj%.nuspec') do (set "oldver=%%i")

if not "%ver%"=="" (goto :setOut)

set "ver=%oldver%"
rem update version with revision
for /f "tokens=3 delims=. " %%a in ("%ver%") do (set "rev=%%a")
for /f "tokens=* delims= " %%a in ("%rev%") do (set "rev=%%a")
set rev=%rev:-pre=%
set /a rev+=1
for /f "tokens=1-2 delims=. " %%a in ("%ver%") do (set "ver=%%a.%%b.%rev%")
rem apply pre flag
if "%pre%"=="1" (set "ver=%ver%-pre")

:setOut
if "%out%"=="" (set "out=%projPath%")
set "p=%out%::::"
set "p=%p:\::::=%"
set "p=%p:/::::=%"
set "p=%p:::::=%"
set "out=%p%\%proj%.%ver%\"
if not exist %out% mkdir %out%

:make
XML.EXE ed -L -P -N "nuspec=http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd" -u "//nuspec:version" -v %ver% %projPath%%proj%.nuspec

nuget.exe pack %projPath%%proj%.csproj -Symbols -version %ver% -IncludeReferencedProjects -Prop "Configuration=Release;Platform=AnyCPU" -Verbosity detailed -OutputDirectory %out% && set "created=1"

if "%created%"=="0" (XML.EXE ed -L -P -N "nuspec=http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd" -u "//nuspec:version" -v %oldver% %projPath%%proj%.nuspec & goto :end) 

if "%push%"=="0" (goto :end)

echo pushing package '%proj%.%ver%.nupkg' to server
nuget.exe SetApiKey -Source %nugetServ% %apikey%
nuget.exe SetApiKey -Source %SymbSrcServ% %apikey%
nuget.exe push %out%%proj%.%ver%.nupkg -s %nugetServ%
nuget.exe push %out%%proj%.%ver%.symbols.nupkg -s %SymbSrcServ%

goto :end
:error
echo argument error
:end
endlocal 
rem &if "%2"=="-r" (if "%created%"=="1" (set "%~3=%proj%.%ver%.nupkg") else (set "%~3="))