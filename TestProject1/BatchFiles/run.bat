@echo off
Set Projectpath=C:\Users\rajivsa_90\source\repos\TestProject1\TestProject1\bin\Debug\netcoreapp3.1\
set projectdll=TestProject1.dll
set OutputPath=C:\Users\rajivsa_90\source\repos\TestProject1\TestProject1\TestReports\AutomationResults03062021_5_15_AM\test1.html
@echo on
livingdoc test-assembly %Projectpath%%projectdll% -t %Projectpath%TestExecution.json --output %OutputPath%
pause



