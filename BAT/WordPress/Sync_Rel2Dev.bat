@echo off
rem - - - - - - - - - - - - - - - - - - - - - - - -
rem 
rem Release の変更を Develop にマージ
rem 
rem - - - - - - - - - - - - - - - - - - - - - - - -

rem ドライブ切り替え
M:

echo Release の変更を Develop にマージします。

rem リビジョン指定
set /P REV_START="前回マージしたリビジョン : "

echo リビジョン %REV_START% から最新リビジョンまでの変更をマージします。

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
cd "M:\03_pj\WordPress\Develop\blaz-official\app\public"

rem svn update 実行
svn update

rem svn merge 実行
svn merge -r %REV_START%:HEAD "file:///M:/03_pj/_SVN_Rep/Release/blaz-official"

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem bridge-or-books-official
rem - - - - - - - - - - - - - - - - - - - - - - - -

rem ディレクトリ移動
cd "M:\03_pj\WordPress\Develop\bridge-or-books-official\app\public"

rem svn update 実行
svn update

rem svn merge 実行
svn merge -r %REV_START%:HEAD "file:///M:/03_pj/_SVN_Rep/Release/bridge-or-books-official"

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem keiryoteckotsu-official
rem - - - - - - - - - - - - - - - - - - - - - - - -

rem ディレクトリ移動
cd "M:\03_pj\WordPress\Develop\keiryoteckotsu-official\app\public"

rem svn update 実行
svn update

rem svn merge 実行
svn merge -r %REV_START%:HEAD "file:///M:/03_pj/_SVN_Rep/Release/keiryoteckotsu-official"

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem 正常終了
rem - - - - - - - - - - - - - - - - - - - - - - - -

:END

echo マージ完了しました。

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

