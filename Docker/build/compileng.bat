@echo off

set apsimx=C:\ApsimX
if not exist %apsimx% (
	echo C:\ApsimX does not exist. This directory must be mounted via the docker run -v switch.
	exit 1
)

rem Call VS developer command prompt to setup environment
call "C:\BuildTools\Common7\Tools\VsDevCmd.bat"

rem Download nuget packages
echo Downloading NuGet packages.
cd %apsimx%
nuget restore

rem Copy files from deployment support
echo Copying DeploymentSupport files.
copy /y %apsimx%\DeploymentSupport\Windows\Bin64\* %apsimx%\Bin\

echo Building ApsimX.
msbuild /m %apsimx%\ApsimX.sln

set error=%errorlevel%

if %error% equ 0 (
	rem We need to archive the binaries, but ApsimX\Bin is quite large. First we delete everything from DeploymentSupport,
	rem then we compress what's left.
	for /r %%i in (.\ApsimX\DeploymentSupport\Windows\Bin64\*) do del .\ApsimX\Bin\%%~nxi
	powershell -Command Compress-Archive .\ApsimX\Bin\* -DestinationPath %apsimx%\bin.zip -CompressionLevel Optimal
)

exit %error%