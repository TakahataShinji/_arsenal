@echo off
rem - - - - - - - - - - - - - - - - - - - - - - - -
rem 
rem Release �̕ύX�� Develop �Ƀ}�[�W
rem 
rem - - - - - - - - - - - - - - - - - - - - - - - -

rem �h���C�u�؂�ւ�
M:

echo Release �̕ύX�� Develop �Ƀ}�[�W���܂��B

rem ���r�W�����w��
set /P REV_START="�O��}�[�W�������r�W���� : "

echo ���r�W���� %REV_START% ����ŐV���r�W�����܂ł̕ύX���}�[�W���܂��B

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
cd "M:\03_pj\WordPress\Develop\blaz-official\app\public"

rem svn update ���s
svn update

rem svn merge ���s
svn merge -r %REV_START%:HEAD "file:///M:/03_pj/_SVN_Rep/Release/blaz-official"

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem bridge-or-books-official
rem - - - - - - - - - - - - - - - - - - - - - - - -

rem �f�B���N�g���ړ�
cd "M:\03_pj\WordPress\Develop\bridge-or-books-official\app\public"

rem svn update ���s
svn update

rem svn merge ���s
svn merge -r %REV_START%:HEAD "file:///M:/03_pj/_SVN_Rep/Release/bridge-or-books-official"

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem keiryoteckotsu-official
rem - - - - - - - - - - - - - - - - - - - - - - - -

rem �f�B���N�g���ړ�
cd "M:\03_pj\WordPress\Develop\keiryoteckotsu-official\app\public"

rem svn update ���s
svn update

rem svn merge ���s
svn merge -r %REV_START%:HEAD "file:///M:/03_pj/_SVN_Rep/Release/keiryoteckotsu-official"

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem ����I��
rem - - - - - - - - - - - - - - - - - - - - - - - -

:END

echo �}�[�W�������܂����B

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

