using Microsoft.WindowsAPICodePack.Dialogs;

namespace Util
{
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    /// <summary>
    /// [static] ファイル・フォルダ選択ダイアログの操作
    /// </summary>
    /// WindowsAPICodePack-Core
    /// WindowsAPICodePack-Shell
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    static class FileDialogProc
    {
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// public メソッド
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ファイル選択ダイアログを開く
        /// </summary>
        /// <param name="defaultFileName"> 初期ファイル名</param>
        /// <param name="initDir">         初期ディレクトリ</param>
        /// <param name="title">           ダイアログの表題</param>
        /// <param name="filters">         フィルタ(ファイルの種類)<br/>
        ///                                dispName   : フィルタの表示名<br/>
        ///                                extensions : 拡張子(複数指定可)</param>
        /// <returns>選択されたファイル名<br/>
        ///          キャンセル・失敗時はnull</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string? ShowOpenFileDialog(string defaultFileName = "",
                                                 string initDir = "",
                                                 string title = "ファイルを開く",
                                                 (string dispName, string[] extensions)[]? filters = null)
        {
            try
            {
                var dialog = new CommonOpenFileDialog(title);

                dialog.DefaultFileName = defaultFileName;
                dialog.InitialDirectory = initDir;

                // フィルタ設定
                if (filters != null)
                {
                    foreach (var f in filters)
                    {
                        var st_f = new CommonFileDialogFilter();

                        st_f.DisplayName = f.dispName;
                        foreach (var e in f.extensions)
                        {
                            st_f.Extensions.Add(e);
                        }

                        dialog.Filters.Add(st_f);
                    }
                }

                // ダイアログを開く
                // 「OK」が押された場合、選択されたファイル名を返す
                // それ以外は null を返す
                return (dialog.ShowDialog() == CommonFileDialogResult.Ok) ? dialog.FileName : null;
            }
            catch
            {
                return null;
            }
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ファイル保存ダイアログを開く
        /// </summary>
        /// <param name="defaultFileName"> 初期ファイル名</param>
        /// <param name="initDir">         初期ディレクトリ</param>
        /// <param name="title">           ダイアログの表題</param>
        /// <param name="filters">         フィルタ(ファイルの種類)<br/>
        ///                                dispName   : フィルタの表示名<br/>
        ///                                extensions : 拡張子(複数指定可)</param>
        /// <returns>保存したファイル名<br/>
        ///          キャンセル・失敗時はnull</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string? ShowSaveFileDialog(string defaultFileName = "",
                                                 string initDir = "",
                                                 string title = "名前を付けて保存",
                                                 (string dispName, string[] extensions)[]? filters = null)
        {
            try
            {
                var dialog = new CommonSaveFileDialog(title);

                dialog.DefaultFileName = defaultFileName;
                dialog.InitialDirectory = initDir;

                // フィルタ設定
                if (filters != null)
                {
                    foreach (var f in filters)
                    {
                        var st_f = new CommonFileDialogFilter();

                        st_f.DisplayName = f.dispName;
                        foreach (var e in f.extensions)
                        {
                            st_f.Extensions.Add(e);
                        }

                        dialog.Filters.Add(st_f);
                    }
                }

                // ダイアログを開く
                // 「OK」が押された場合、選択されたファイル名を返す
                // それ以外は null を返す
                return (dialog.ShowDialog() == CommonFileDialogResult.Ok) ? dialog.FileName : null;
            }
            catch
            {
                return null;
            }
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] フォルダ選択ダイアログを開く
        /// </summary>
        /// <param name="initDir">         初期ディレクトリ</param>
        /// <param name="title">           ダイアログの表題</param>
        /// <returns>選択されたフォルダ<br/>
        ///          キャンセル・失敗時はnull</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string? ShowFolderBrowserDialog(string initDir = "",
                                                      string title = "フォルダを開く")
        {
            try
            {
                var dialog = new CommonOpenFileDialog(title);

                dialog.IsFolderPicker = true;
                dialog.InitialDirectory = initDir;

                // ダイアログを開く
                // 「OK」が押された場合、選択されたファイル名を返す
                // それ以外は null を返す
                return (dialog.ShowDialog() == CommonFileDialogResult.Ok) ? dialog.FileName : null;
            }
            catch
            {
                return null;
            }
        }

    }       // class FileOperate
}       // namespace Util
