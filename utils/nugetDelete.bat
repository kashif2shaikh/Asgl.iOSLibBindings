@echo off

cd ..\utils\
setlocal

set "nugetServ=http://vmdev/NugetServer/api/v2/package"
set "SymbSrcServ=http://vmdev/SymbolSource/Nuget"
set "apikey=AsglNuget"


if "%1"=="" goto :error
if "%2"=="" goto :error
:start
..\utils\nuget.exe SetApiKey -Source %nugetServ% %apikey%
..\utils\nuget.exe SetApiKey -Source %SymbSrcServ% %apikey%
..\utils\nuget.exe delete %1 %2 -Source %nugetServ%
..\utils\nuget.exe delete %1 %2 -Source %SymbSrcServ%

goto :end
endlocal
:error
echo argument error
:end
endlocal 