@echo off
rem - - - - - - - - - - - - - - - - - - - - - - - -
rem 
rem デプロイ( Heroku に Push )
rem 
rem - - - - - - - - - - - - - - - - - - - - - - - -

rem ドライブ切り替え
M:

echo デプロイを行います。

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

rem ディレクトリ移動
cd "M:\03_pj\WordPress\Release\blaz-official"

rem git add 実行
git add .

rem git commit 実行
git commit -am "Commit Message"

rem git push 実行
git push heroku master

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem bridge-or-books-official
rem - - - - - - - - - - - - - - - - - - - - - - - -

rem ディレクトリ移動
cd "M:\03_pj\WordPress\Release\bridge-or-books-official"

rem git add 実行
git add .

rem git commit 実行
git commit -am "Commit Message"

rem git push 実行
git push heroku master

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem keiryoteckotsu-official
rem - - - - - - - - - - - - - - - - - - - - - - - -

rem ディレクトリ移動
cd "M:\03_pj\WordPress\Release\keiryoteckotsu-official"

rem git add 実行
git add .

rem git commit 実行
git commit -am "Commit Message"

rem git push 実行
git push heroku master

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem 正常終了
rem - - - - - - - - - - - - - - - - - - - - - - - -

:END

echo デプロイ完了しました。

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

