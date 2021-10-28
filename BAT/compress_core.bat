@echo off
rem 
rem 機能設計書圧縮バッチ
rem 
rem 引数 : 設計書のバージョン(**.**.**形式)
rem 

rem 設計書のバージョン
set VRS=%1

rem バージョンを******形式に変換('.'を''に置換)
set VRR=%VRS:.=%

rem 圧縮プログラム(Lhaplus)
set PRG="C:\Program Files (x86)\Lhaplus\Lhaplus.exe"

rem ルートディレクトリ
set ROOT="C:\_Takaha-Q\20.Jobs\201608 ドキュメント修正\tags"

rem 各バージョンのディレクトリ
set VDIR=%ROOT%\%VRS%

rem 設計書ファイル名
set DOC="設計書-MCP7(IB)Step2_機能設計書-(J).docx"

rem 設計書フルパス
set FDOC=%VDIR%\%DOC%

rem 一時ファイル名
set TZP="設計書-MCP7(IB)Step2_機能設計書-(J).zip"

rem 一時ファイルフルパス
set FTZP=%VDIR%\%TZP%

rem 最終出力
set FOT="MCP7IB-2-STD;DOC(機能設計書);%VRR%.zip"

rem 圧縮実行
echo.
echo 圧縮しています...
%PRG% /c:zip /o:%VDIR% %FDOC%

rem 一時ファイルをリネーム
echo.
echo 圧縮完了しました。
echo.
echo ファイルを移動しています...
rename %FTZP% %FOT%

rem 最終出力をルートに移動
move %VDIR%\%FOT% %ROOT%\

