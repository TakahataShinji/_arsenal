rem sync_sub.bat を管理者権限で実行
powershell.exe -Command Start-Process """%~dp0%syncD2F_sub.bat""" -Verb Runas
