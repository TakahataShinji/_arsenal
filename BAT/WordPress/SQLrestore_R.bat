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

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem blaz-official
rem - - - - - - - - - - - - - - - - - - - - - - - -

set USR="b9176a7a1cf279"
set PWD="6c5175b6"
set HST="us-cdbr-iron-east-05.cleardb.net"
set DBN="heroku_9fc7af5a977e477"
set FIL="blaz-official.dump"

rem ���X�g�A���s
mysql -u %USR% -p%PWD% -h %HST% %DBN% < %DIR%%FIL%

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem bridge-or-books-official
rem - - - - - - - - - - - - - - - - - - - - - - - -

set USR="b797c8c336d92b"
set PWD="f46570a7"
set HST="us-cdbr-iron-east-05.cleardb.net"
set DBN="heroku_1795947a7d83811"
set FIL="bridge-or-books-official.dump"

rem ���X�g�A���s
mysql -u %USR% -p%PWD% -h %HST% %DBN% < %DIR%%FIL%

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem keiryoteckotsu-official
rem - - - - - - - - - - - - - - - - - - - - - - - -

set USR="b2bec5ba64c092"
set PWD="988256a4"
set HST="us-cdbr-iron-east-05.cleardb.net"
set DBN="heroku_8125ebdae96a3a7"
set FIL="keiryoteckotsu-official.dump"

rem ���X�g�A���s
mysql -u %USR% -p%PWD% -h %HST% %DBN% < %DIR%%FIL%

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

