@echo off
rem - - - - - - - - - - - - - - - - - - - - - - - -
rem 
rem �_���v(MySQL)
rem 
rem - - - - - - - - - - - - - - - - - - - - - - - -

echo �f�[�^�x�[�X�̃_���v���s���܂��B

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
rem bridge-or-books-official
rem - - - - - - - - - - - - - - - - - - - - - - - -

set PRT="4006"
set FIL="bridge-or-books-official.dump"

rem �_���v���s
mysqldump -u %USR% -p%PWD% -h %HST% %DBN% -P %PRT% > %DIR%%FIL%

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem ����I��
rem - - - - - - - - - - - - - - - - - - - - - - - -

:END

echo �_���v�������܂����B

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

