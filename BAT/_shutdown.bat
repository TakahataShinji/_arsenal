@echo off
rem - - - - - - - - - - - - - - - - - - - - - - - -
rem 
rem 指定時間後にシャットダウン
rem 
rem - - - - - - - - - - - - - - - - - - - - - - - -

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem 時間を指定して待ち

_wait

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem シャットダウン

shutdown.exe -s -f

rem 戻り値 : 1
rem 自身のみ終了 /b
exit /b 1

