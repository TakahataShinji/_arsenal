@echo off
rem - - - - - - - - - - - - - - - - - - - - - - - -
rem 
rem リストア(MySQL)
rem 
rem - - - - - - - - - - - - - - - - - - - - - - - -

echo データベースのリストアを行います。

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
rem blaz-official
rem - - - - - - - - - - - - - - - - - - - - - - - -

set PRT="4002"
set FIL="blaz-official.dump"

rem リストア実行
mysql -u %USR% -p%PWD% -h %HST% %DBN% -P %PRT% < %DIR%%FIL%

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem bridge-or-books-official
rem - - - - - - - - - - - - - - - - - - - - - - - -

set PRT="4006"
set FIL="bridge-or-books-official.dump"

rem リストア実行
mysql -u %USR% -p%PWD% -h %HST% %DBN% -P %PRT% < %DIR%%FIL%

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem keiryoteckotsu-official
rem - - - - - - - - - - - - - - - - - - - - - - - -

set PRT="4010"
set FIL="keiryoteckotsu-official.dump"

rem リストア実行
mysql -u %USR% -p%PWD% -h %HST% %DBN% -P %PRT% < %DIR%%FIL%

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem 正常終了
rem - - - - - - - - - - - - - - - - - - - - - - - -

:END

echo リストア完了しました。

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

