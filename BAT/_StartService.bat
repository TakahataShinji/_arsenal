@echo off
rem 
rem �T�[�r�X UsbSerialServ �̋N��
rem 

rem �Ǘ��Ҍ����œ��Y�o�b�`�����s
cd /d %~dp0
for /f "tokens=3 delims=\ " %%i in ('whoami /groups^|find "Mandatory"') do set LEVEL=%%i
if NOT "%LEVEL%"=="High" (
@powershell -NoProfile -ExecutionPolicy unrestricted -Command "Start-Process %~f0 -Verb runas"
exit
)

rem �ʏ�����������

rem UsbSerialServ ���N��
sc start UsbSerialServ

rem �I���m�F
pause