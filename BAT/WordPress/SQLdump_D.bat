@echo off
rem - - - - - - - - - - - - - - - - - - - - - - - -
rem 
rem ダンプ(MySQL)
rem 
rem - - - - - - - - - - - - - - - - - - - - - - - -

echo データベースのダンプを行います。

:RE_ASK

set /P PROMPT="よろしいですか？(Y/N) : "

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

set DIR="M:\03_pj\WordPress\SQLdump\"

set USR="root"
set PWD="root"
set HST="localhost"
set DBN="local"

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem bridge-or-books-official
rem - - - - - - - - - - - - - - - - - - - - - - - -

set PRT="4006"
set FIL="bridge-or-books-official.dump"

rem ダンプ実行
mysqldump -u %USR% -p%PWD% -h %HST% %DBN% -P %PRT% > %DIR%%FIL%

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem 正常終了
rem - - - - - - - - - - - - - - - - - - - - - - - -

:END

echo ダンプ完了しました。

pause

rem 戻り値 : 0
rem 自身のみ終了 /b
exit /b 0

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem キャンセル終了
rem - - - - - - - - - - - - - - - - - - - - - - - -

:CANCEL

echo キャンセルしました。

pause

rem 戻り値 : 1
rem 自身のみ終了 /b
exit /b 1

