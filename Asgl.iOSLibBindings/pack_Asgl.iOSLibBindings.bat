@echo off

setlocal
set "out=..\packages\"

cd ..\utils\
call nugetPack.bat -push -out %out% ..\Asgl.iOSLibBindings
endlocal
cd ..\Asgl.iOSLibBindings
pause