rem 
rem DNS設定を AWS Workspaces 向けに切り替える
rem (対象の接続は変数 interface_name に設定する)
rem 

rem 管理者権限で起動されたかを確認、
rem 管理者でなければ、管理者として当該バッチを開きなおす
cd /d %~dp0
for /f "tokens=3 delims=\ " %%i in ('whoami /groups^|find "Mandatory"') do set LEVEL=%%i
if NOT "%LEVEL%"=="High" (
@powershell -NoProfile -ExecutionPolicy unrestricted -Command "Start-Process %~f0 -Verb runas"
exit
)

rem ここから主処理

set interface_name=Wi-Fi
rem set interface_name=イーサネット
set dns_server1=10.40.44.125
set dns_server2=10.40.44.120

netsh interface ipv4 set dns name="%interface_name%" source=static addr="%dns_server1%" register=non validate=no
netsh interface ipv4 add dns name="%interface_name%" addr="%dns_server2%" index=2 validate=no

pause
