rem sync_sub.bat を管理者権限で実行
powershell.exe -Command Start-Process """%~dp0%syncN2Q_sub.bat""" -Verb Runas
