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

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem blaz-official
rem - - - - - - - - - - - - - - - - - - - - - - - -

set USR="b9176a7a1cf279"
set PWD="6c5175b6"
set HST="us-cdbr-iron-east-05.cleardb.net"
set DBN="heroku_9fc7af5a977e477"
set FIL="blaz-official.dump"

rem ダンプ実行
mysqldump -u %USR% -p%PWD% -h %HST% %DBN% > %DIR%%FIL%

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem bridge-or-books-official
rem - - - - - - - - - - - - - - - - - - - - - - - -

set USR="b5645f6877c3f8"
set PWD="1de1849c"
set HST="us-cdbr-iron-east-05.cleardb.net"
set DBN="heroku_f1c218387c6cdf1"
set FIL="bridge-or-books-official.dump"

rem ダンプ実行
mysqldump -u %USR% -p%PWD% -h %HST% %DBN% > %DIR%%FIL%

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem keiryoteckotsu-official
rem - - - - - - - - - - - - - - - - - - - - - - - -

set USR="b2bec5ba64c092"
set PWD="988256a4"
set HST="us-cdbr-iron-east-05.cleardb.net"
set DBN="heroku_8125ebdae96a3a7"
set FIL="keiryoteckotsu-official.dump"

rem ダンプ実行
mysqldump -u %USR% -p%PWD% -h %HST% %DBN% > %DIR%%FIL%

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

