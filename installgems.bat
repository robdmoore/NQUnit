@ECHO OFF
cmd /c gem list albacore -v 0.2.5 -i
IF ERRORLEVEL 1 THEN GOTO INSTALL
GOTO :EOF
:INSTALL
cmd /c gem install albacore --version 0.2.5
