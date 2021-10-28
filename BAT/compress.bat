@echo off
rem 
rem 機能設計書圧縮バッチ
rem 

rem 今回の版数
set VRS=08.19.00

rem 確認入力
echo.
echo 今回の版数は %VRS% です。
echo.
echo 圧縮ファイルを作成します。
echo.
set /p ANS=よろしいですか？(y/n)
if not %ANS%==y goto ABORT

rem 圧縮実施
call compress_core.bat %VRS%

echo.
echo ファイルを作成しました。
goto END

rem 中断
:ABORT
echo.
echo キャンセルしました。

rem 終了
:END
echo.
echo 終了します。
pause
