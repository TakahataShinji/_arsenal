@echo off
rem - - - - - - - - - - - - - - - - - - - - - - - -
rem 
rem �f�v���C( Heroku �� Push )
rem 
rem - - - - - - - - - - - - - - - - - - - - - - - -

rem �h���C�u�؂�ւ�
M:

echo �f�v���C���s���܂��B

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

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem blaz-official
rem - - - - - - - - - - - - - - - - - - - - - - - -

rem �f�B���N�g���ړ�
cd "M:\03_pj\WordPress\Release\blaz-official"

rem git add ���s
git add .

rem git commit ���s
git commit -am "Commit Message"

rem git push ���s
git push heroku master

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem bridge-or-books-official
rem - - - - - - - - - - - - - - - - - - - - - - - -

rem �f�B���N�g���ړ�
cd "M:\03_pj\WordPress\Release\bridge-or-books-official"

rem git add ���s
git add .

rem git commit ���s
git commit -am "Commit Message"

rem git push ���s
git push heroku master

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem keiryoteckotsu-official
rem - - - - - - - - - - - - - - - - - - - - - - - -

rem �f�B���N�g���ړ�
cd "M:\03_pj\WordPress\Release\keiryoteckotsu-official"

rem git add ���s
git add .

rem git commit ���s
git commit -am "Commit Message"

rem git push ���s
git push heroku master

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem ����I��
rem - - - - - - - - - - - - - - - - - - - - - - - -

:END

echo �f�v���C�������܂����B

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

