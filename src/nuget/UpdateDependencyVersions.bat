@ECHO OFF
PowerShell.exe -Command "& '%~dpn0.ps1' -version %APPVEYOR_BUILD_VERSION%"