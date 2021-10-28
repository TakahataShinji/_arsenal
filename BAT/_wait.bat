@echo off
rem - - - - - - - - - - - - - - - - - - - - - - - -
rem 
rem ウェイトタイマー
rem 
rem - - - - - - - - - - - - - - - - - - - - - - - -

echo タイマーを起動します。
echo 待ち時間[分]を入力してください。
echo - - - - - - - - - - - - - - - - - - - - - - - -

set /P MIN="分数 : "

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem 待ち時間を秒に換算

set /a CNT=%MIN%*60

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem 指定された時間待機

timeout /t %CNT% /nobreak

rem 戻り値 : 1
rem 自身のみ終了 /b
exit /b 1

