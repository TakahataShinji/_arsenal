@echo off
rem - - - - - - - - - - - - - - - - - - - - - - - -
rem 
rem ���X�g�A(MySQL)
rem 
rem - - - - - - - - - - - - - - - - - - - - - - - -

echo �f�[�^�x�[�X�̃��X�g�A���s���܂��B

:RE_ASK

set /P PROMPT="��낵���ł����H(Y/N) : "

if "%PROMPT%"=="n" (
	goto :CANCEL
) else if "%PROMPT%"=="N" (
	goto :CANCEL
) else if "%PROMPT%"=="y" (
	goto :PROCEED
) else if "%PROMPT%"=="Y" (
	goto :PROCEED
) else (
	goto :RE_ASK
)

:PROCEED

set DIR="M:\03_pj\WordPress\SQLdump\"

set USR="root"
set PWD="root"
set HST="localhost"
set DBN="local"

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem blaz-official
rem - - - - - - - - - - - - - - - - - - - - - - - -

set PRT="4002"
set FIL="blaz-official.dump"

rem ���X�g�A���s
mysql -u %USR% -p%PWD% -h %HST% %DBN% -P %PRT% < %DIR%%FIL%

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem bridge-or-books-official
rem - - - - - - - - - - - - - - - - - - - - - - - -

set PRT="4006"
set FIL="bridge-or-books-official.dump"

rem ���X�g�A���s
mysql -u %USR% -p%PWD% -h %HST% %DBN% -P %PRT% < %DIR%%FIL%

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem keiryoteckotsu-official
rem - - - - - - - - - - - - - - - - - - - - - - - -

set PRT="4010"
set FIL="keiryoteckotsu-official.dump"

rem ���X�g�A���s
mysql -u %USR% -p%PWD% -h %HST% %DBN% -P %PRT% < %DIR%%FIL%

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem ����I��
rem - - - - - - - - - - - - - - - - - - - - - - - -

:END

echo ���X�g�A�������܂����B

pause

rem �߂�l : 0
rem ���g�̂ݏI�� /b
exit /b 0

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem �L�����Z���I��
rem - - - - - - - - - - - - - - - - - - - - - - - -

:CANCEL

echo �L�����Z�����܂����B

pause

rem �߂�l : 1
rem ���g�̂ݏI�� /b
exit /b 1

