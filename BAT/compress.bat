@echo off
rem 
rem �@�\�݌v�����k�o�b�`
rem 

rem ����̔Ő�
set VRS=08.19.00

rem �m�F����
echo.
echo ����̔Ő��� %VRS% �ł��B
echo.
echo ���k�t�@�C�����쐬���܂��B
echo.
set /p ANS=��낵���ł����H(y/n)
if not %ANS%==y goto ABORT

rem ���k���{
call compress_core.bat %VRS%

echo.
echo �t�@�C�����쐬���܂����B
goto END

rem ���f
:ABORT
echo.
echo �L�����Z�����܂����B

rem �I��
:END
echo.
echo �I�����܂��B
pause
