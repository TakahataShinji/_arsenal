rem 
rem DNS�ݒ�� AWS Workspaces �����ɐ؂�ւ���
rem (�Ώۂ̐ڑ��͕ϐ� interface_name �ɐݒ肷��)
rem 

rem �Ǘ��Ҍ����ŋN�����ꂽ�����m�F�A
rem �Ǘ��҂łȂ���΁A�Ǘ��҂Ƃ��ē��Y�o�b�`���J���Ȃ���
cd /d %~dp0
for /f "tokens=3 delims=\ " %%i in ('whoami /groups^|find "Mandatory"') do set LEVEL=%%i
if NOT "%LEVEL%"=="High" (
@powershell -NoProfile -ExecutionPolicy unrestricted -Command "Start-Process %~f0 -Verb runas"
exit
)

rem ��������又��

set interface_name=Wi-Fi
rem set interface_name=�C�[�T�l�b�g
set dns_server1=10.40.44.125
set dns_server2=10.40.44.120

netsh interface ipv4 set dns name="%interface_name%" source=static addr="%dns_server1%" register=non validate=no
netsh interface ipv4 add dns name="%interface_name%" addr="%dns_server2%" index=2 validate=no

pause
