REM RUN AS ADMINISTATOR else the service cant be installed

cd %~dp0

@ECHO OFF
 
TASKKILL /F /IM firedump.exe

CALL firedump.exe install
ECHO installing firedump service

CALL firedump.exe start

ECHO Starting firedump service
TIMEOUT /T 2
