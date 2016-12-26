REM RUN AS ADMINISTATOR 
cd %~dp0

@ECHO OFF

START firedump.exe stop
ECHO Stopping firedump Service
TIMEOUT /T 2

:LOOP
TASKLIST  firedump.exe >nul 2>&1
IF ERRORLEVEL 1 (
  GOTO CONTINUE
) ELSE (
  REM ECHO firedump.exe stop is still running
  SLEEP 5
  GOTO LOOP
)

:CONTINUE

start firedump.exe uninstall
ECHO Uninstalling firedump Service
TIMEOUT /T 7
