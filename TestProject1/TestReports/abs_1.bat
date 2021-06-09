echo off
Set test=No Available
for /f "delims=" %%d in ('dir /a:d /b /o:n') do (
    set test=%%d 
goto :break
)
:break

timeout