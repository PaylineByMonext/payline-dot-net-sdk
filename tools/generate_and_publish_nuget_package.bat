@echo off

set script_directory=%~dp0
set nuget_bin=NuGet.exe

cd "%script_directory%.."

echo Remove old packages...
del /f "%script_directory%..\*.nupkg"

echo Generate package in directory %script_directory%.. ...
"%script_directory%%nuget_bin%" pack

echo Publish package...
rem "%script_directory%%nuget_bin%" push "%script_directory%..\*.nupkg" -Source https://api.nuget.org/v3/index.json -ApiKey "%api_key%"

rem del /f "%script_directory%..\*.nupkg"

pause