@echo off
rem 
rem サービス UsbSerialServ の起動
rem 

rem 管理者権限で当該バッチを実行
cd /d %~dp0
for /f "tokens=3 delims=\ " %%i in ('whoami /groups^|find "Mandatory"') do set LEVEL=%%i
if NOT "%LEVEL%"=="High" (
@powershell -NoProfile -ExecutionPolicy unrestricted -Command "Start-Process %~f0 -Verb runas"
exit
)

rem 個別処理ここから

rem UsbSerialServ を起動
sc start UsbSerialServ

rem 終了確認
pause