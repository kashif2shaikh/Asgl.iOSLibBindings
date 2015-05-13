@echo off
set "src=..\packages"
set "dest=\\vmdev.anguslan\c$\angusanywhere\Asgl.NugetServer\packages"
for /r "%src%" /d %%F in (*) do (
	xcopy /D /Q /I /y "%%F\*.nupkg" "%dest%"
)