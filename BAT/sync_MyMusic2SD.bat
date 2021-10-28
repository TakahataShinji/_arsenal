@echo off
rem - - - - - - - - - - - - - - - - - - - - - - - -
rem 
rem 音楽ファイルをPCからSDにコピー
rem 
rem - - - - - - - - - - - - - - - - - - - - - - - -

rem Musicフォルダを削除
rem rd /s /q V:\AV\Music

rem フォルダをコピー
robocopy D:\My_Music V:\AV\Music /MIR