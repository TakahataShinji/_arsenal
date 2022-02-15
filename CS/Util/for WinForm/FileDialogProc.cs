using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace Util
{
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    /// <summary>
    /// [static] ファイル・フォルダ選択ダイアログの操作
    /// </summary>
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    static class FileDialogProc
    {
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public メソッド (static)
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ファイル選択ダイアログを開く
        /// </summary>
        /// 
        /// <param name="fileName"> [I]初期ファイル名<br/>
        ///                         [O]選択されたファイル名</param>
        /// <param name="initDir">  [I]初期ディレクトリ</param>
        /// <param name="title">    [I]ダイアログの表題</param>
        /// <param name="filter">   [I]フィルタ(ファイルの種類)</param>
        /// <param name="filterIdx">[I]初期選択フィルタ(1起算)</param>
        /// <returns>処理成否<br/>
        ///          true  - 成功<br/>
        ///          false - 失敗</returns>
        /// <remarks>フィルタは "(任意のキャプション)|*.(拡張子)" で表現<br/>
        /// 複数のフィルタパターンを設定する場合は ";" で連結<br/>
        /// (例 "テキストファイル|*.txt;XMLファイル|*.xml" )</remarks>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool ShowOpenFileDialog(ref string fileName,
                                                  string initDir = "",
                                                  string title = "ファイルを開く",
                                                  string filter = "すべてのファイル(*.*)|*.*",
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
                ofd.FilterIndex = filterIdx;            //< 初期選択フィルタ

                // 「OK」が押された場合、ファイル名を更新
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] フォルダ選択ダイアログを開く
        /// </summary>
        /// 
        /// <param name="path"> [I]初期フォルダ<br/>
        ///                     [O]選択されたフォルダ</param>
        /// <param name="title">[I]ダイアログの表題</param>
        /// <returns>処理成否<br/>
        ///          true  - 成功<br/>
        ///          false - 失敗</returns>
        /// <remarks>ルートディレクトリはデスクトップ</remarks>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool ShowFolderBrowserDialog(ref string path, string title = "フォルダを開く")
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
                return true;
            }
            catch
            {
                return false;
            }
        }

    }       // class FileOperate
}       // namespace Util
