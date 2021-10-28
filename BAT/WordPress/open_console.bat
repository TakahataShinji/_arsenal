@echo off
rem - - - - - - - - - - - - - - - - - - - - - - - -
rem 
rem コンソール(コマンドプロンプト)を開く
rem 
rem - - - - - - - - - - - - - - - - - - - - - - - -

rem ドライブ切り替え
M:

rem ディレクトリ移動
cd "M:\03_pj\WordPress"

rem マクロ読み込み
doskey /macrofile=d:\_Library\macros.txt

rem コマンドプロンプト起動
cmd.exe
