@echo off
echo Building the .NET 4.5 application against .NET 4.0
msbuild NET45App\NET45App.csproj > nul

echo Building the .NET 4.0 application
msbuild NET40App\NET40App.csproj > nul


echo Building the .NET 4.5 application against .NET 4.5
msbuild Net45App\Net45App.csproj /p:TargetFrameworkVersion=v4.5 /target:Rebuild /p:DefineConstants="NET45" > nul

echo Copying the .NET 4.5 application built against 4.5 to the .NET 4.0 application's bind directory
copy NET45App\bin\debug\NET45App.exe NET40App\bin\debug /y > nul

echo.
echo *** Running the .NET 4.5 application ***
NET40App\bin\debug\NET45App.exe

echo.
echo *** Running the .NET 4.0 application ***
NET40App\bin\debug\NET40App.exe
