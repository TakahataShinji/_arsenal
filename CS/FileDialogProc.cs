// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
//
// FileDialogProc
//
// [static]ファイル・フォルダ選択ダイアログの操作
//
// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace Util
{
    static class FileDialogProc
    {
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public メソッド (static)
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイル選択ダイアログを開く
        // -------+-----------------------------------------------------
        // 引数   | String fileName : [I]初期ファイル名
        //        |                   [O]選択されたファイル名
        //        | String initDir  : [I]初期ディレクトリ
        //        |                      デフォルト - "" 
        //        | String title    : [I]ダイアログの表題
        //        |                      デフォルト - "ファイルを開く"
        //        | String filter   : [I]フィルタ(ファイルの種類)
        //        |                      デフォルト - "すべてのファイル(*.*)|*.*"
        //        | int filterIdx   : [I]初期選択フィルタ
        //        |                      デフォルト - 1(番目)(0起算ではない点に注意)
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // -------+-----------------------------------------------------
        // フィルタは "(任意のキャプション)|*.(拡張子)" で表現
        // 複数のフィルタパターンを設定する場合は ";" で連結
        // (例 "テキストファイル|*.txt;XMLファイル|*.xml" )
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void ShowOpenFileDialog(ref String fileName,
                                                  String initDir = "",
                                                  String title = "ファイルを開く",
                                                  String filter = "すべてのファイル(*.*)|*.*",
                                                  int filterIdx = 1)
        {
            try
            {
                // ダイアログオブジェクト生成
                OpenFileDialog ofd = new OpenFileDialog();

                // パラメータ設定
                ofd.FileName = fileName;                //< 初期ファイル名
                ofd.InitialDirectory = initDir;         //< 初期ディレクトリ
                ofd.Title = title;                      //< ダイアログの表題
                ofd.Filter = filter;                    //< フィルタ

                // 「OK」が押された場合、ファイル名を更新
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                }
            }
            catch
            {
                throw new Exception("ShowOpenFileDialog");
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // フォルダ選択ダイアログを開く
        // -------+-----------------------------------------------------
        // 引数   | String path    : [I]初期フォルダ名
        //        |                  [O]選択されたフォルダ名
        //        | String title   : [I]ダイアログの表題
        //        |                     デフォルト - "フォルダを開く"
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // -------+-----------------------------------------------------
        // ルートディレクトリはデスクトップ
        // 新しいフォルダ作成可能
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void ShowFolderBrowserDialog(ref String path, String title = "フォルダを開く")
        {
            try
            {
                // ダイアログオブジェクト生成
                FolderBrowserDialog fbd = new FolderBrowserDialog();

                // パラメータ設定
                fbd.RootFolder = Environment.SpecialFolder.Desktop;     //< ルートディレクトリ : デスクトップ
                fbd.SelectedPath = path;                                //< 初期ディレクトリ
                fbd.Description = title;                                //< ダイアログの表題

                // 「OK」が押された場合、フォルダ名を更新
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    path = fbd.SelectedPath;
                }
            }
            catch
            {
                throw new Exception("ShowFolderBrowserDialog");
            }
        }

    }       // class FileOperate
}       // namespace Util
