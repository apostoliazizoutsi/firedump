REM RUN AS ADMINISTATOR else the service cant be installed
set abspath=%~dp0
set exec=firedump.exe
set autaki="
set abspath=%autaki%%abspath%

set fullpath=%abspath%%exec%
set fullpath=%fullpath%%autaki%

@ECHO OFF
 
TASKKILL /F /IM %fullpath%

CALL %fullpath% stop
ECHO installing %fullpath% service

CALL %fullpath% uninstall

ECHO Starting firedump service
TIMEOUT /T 2

