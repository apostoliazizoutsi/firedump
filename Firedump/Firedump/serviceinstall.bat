REM RUN AS ADMINISTATOR else the service cant be installed

cd %~dp0

@ECHO OFF
 
TASKKILL /F /IM firedump.exe

START firedump.exe install
ECHO installing firedump service
TIMEOUT /T 3

:LOOP
TASKLIST firedump.exe >nul 2>&1
IF ERRORLEVEL 1 (
GOTO CONTINUE
) ELSE (
  REM ECHO firedump.exe install is still running
SLEEP 2  GOTO LOOP
)

:CONTINUE

START firedump.exe start

ECHO Starting firedump service
TIMEOUT /T 6
