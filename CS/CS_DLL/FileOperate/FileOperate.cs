// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
//
// FileOperate
//
// ファイル操作
//
// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace Util
{
    public class FileOperate
    {
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 定数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public関数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイル選択ダイアログ表示
        // -------------------------------------------------------------
        // 引数   | string initPath : 初期パス
        //        | string title    : タイトル(デフォルト値あり)
        //        | string filter   : ファイルフィルタ(デフォルト値あり)
        //        | int filterIdx   : フィルタインデクス(デフォルト値あり)
        //        |                   (初めに選択されるファイルフィルタ
        //        |                    先頭は 1 )
        //        | string defFile  : デフォルトのファイル名
        // -------------------------------------------------------------
        // 戻り値 | string - 選択されたファイルパス
        // -------------------------------------------------------------
        // フィルタの指定方法 :
        //   "フィルタ概要|パターン" 形式で指定
        //   例) "HTMLファイル(*.html)|*.html"
        //
        //   ・一つのフィルタに複数のパターンを設定する場合はセミコロンで連結
        //     例) "HTMLファイル(*.html;*.htm)|*.html;*.htm"
        //
        //   ・複数のフィルタを設定する場合はパイプで連結
        //     例) "HTMLファイル(*.html;*.htm)|*.html;*.htm|すべてのファイル(*.*)|(*.*)"
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string ShowOpenFileDlg(string initPath,
                                             string title = "ファイルの選択",
                                             string filter = "すべてのファイル(*.*)|*.*",
                                             int filterIdx = 1,
                                             string defFile = "")
        {
            string ret = "";

            // FolderBrowserDialogインスタンス作成
            OpenFileDialog dlg = new OpenFileDialog();

            // ダイアログの設定
            dlg.InitialDirectory = initPath;    //< 初期パス
            dlg.Title            = title;       //< ダイアログタイトル
            dlg.Filter           = filter;      //< フィルタ
            dlg.FilterIndex      = filterIdx;   //< フィルタインデクス
            dlg.FileName         = defFile;     //< デフォルトのファイル名

            // ダイアログを開く
            // (「OK」がクリックされた場合のみ選択されたファイルを返す)
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ret = dlg.FileName;
            }

            return ret;
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // フォルダ選択ダイアログ表示
        // -------------------------------------------------------------
        // 引数   | string defPath : 初期パス
        //        | string title   : タイトル(デフォルト値あり)
        // -------------------------------------------------------------
        // 戻り値 | string - 選択されたフォルダパス
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string ShowFolderBlowser(string defPath, string title = "フォルダの選択")
        {
            string ret = defPath;

            // FolderBrowserDialogインスタンス作成
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            // ダイアログの設定
            // (「新しいフォルダ」作成可能)
            dlg.Description         = title;        //< タイトル
            dlg.SelectedPath        = defPath;      //< 初期パス
            dlg.ShowNewFolderButton = true;         //< 「新しいフォルダ」ボタンを表示する

            // ダイアログを開く
            // (「OK」がクリックされた場合のみ選択されたフォルダを返す)
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ret = dlg.SelectedPath;
            }

            return ret;
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // カレントディレクトリを取得
        // -------------------------------------------------------------
        // 引数   | なし
        // -------------------------------------------------------------
        // 戻り値 | string - カレントディレクトリのパス
        // -------------------------------------------------------------
        // 例外   | System.NotSupportedException
        //        | System.UnauthorizedAccessException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string GetCurrentDir()
        {
            return Directory.GetCurrentDirectory();
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // カレントディレクトリを変更
        // -------------------------------------------------------------
        // 引数   | string path : 変更先のディレクトリ
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | DirectoryNotFoundException
        //        | FileNotFoundException
        //        | IOException
        //        | PathTooLongException
        //        | System.ArgumentException
        //        | System.ArgumentNullException
        //        | System.Security.SecurityException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void SetCurrentDir(string path)
        {
            Directory.SetCurrentDirectory(path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイルの有無を確認
        // -------------------------------------------------------------
        // 引数   | string path : 対象のファイルパス
        // -------------------------------------------------------------
        // 戻り値 | bool - ファイルの有無
        //        |        true  : 指定されたファイルが存在する
        //        |        false : 指定されたファイルが存在しない
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool FileExists(string path)
        {
            return File.Exists(path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // フォルダ(ディレクトリ)の有無を確認
        // -------------------------------------------------------------
        // 引数   | string path : 対象のフォルダパス
        // -------------------------------------------------------------
        // 戻り値 | bool - フォルダの有無
        //        |        true  : 指定されたフォルダが存在する
        //        |        false : 指定されたフォルダが存在しない
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool FolderExists(string path)
        {
            return Directory.Exists(path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイルをコピー
        // -------------------------------------------------------------
        // 引数   | string srcPath : コピー元のパス(ファイル名)
        //        | string dstPath : コピー先のパス(ファイル名)
        //        | bool ow        : コピー先の同名ファイルを上書きするか
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | DirectoryNotFoundException
        //        | FileNotFoundException
        //        | IOException
        //        | NotSupportedException
        //        | PathTooLongException
        //        | System.ArgumentException
        //        | System.ArgumentNullException
        //        | UnauthorizedAccessException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void CopyFile(string srcPath, string dstPath, bool ow = false)
        {
            // コピー実行
            File.Copy(srcPath, dstPath, ow);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイルを移動
        // -------------------------------------------------------------
        // 引数   | string srcPath : 移動元のパス(ファイル名)
        //        | string dstPath : 移動先のパス(ファイル名)
        //        | bool ow        : 移動先の同名ファイルを上書きするか
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | DirectoryNotFoundException
        //        | IOException
        //        | NotSupportedException
        //        | PathTooLongException
        //        | System.ArgumentException
        //        | System.ArgumentNullException
        //        | UnauthorizedAccessException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void MoveFile(string srcPath, string dstPath, bool ow = false)
        {
            // 移動先に同名のファイルが存在する場合
            if (File.Exists(dstPath))
            {
                // 上書きを行う場合、すでにあるファイルを削除
                if (ow)
                {
                    File.Delete(dstPath);
                }
                // 上書きを行わない場合は抜ける
                else
                {
                    return;
                }
            }

            // コピー実行
            File.Move(srcPath, dstPath);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイルを削除
        // -------------------------------------------------------------
        // 引数   | string path : 対象のファイルパス
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | DirectoryNotFoundException
        //        | IOException
        //        | NotSupportedException
        //        | PathTooLongException
        //        | System.ArgumentException
        //        | System.ArgumentNullException
        //        | UnauthorizedAccessException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // フォルダ(ディレクトリ)を移動
        // -------------------------------------------------------------
        // 引数   | string srcPath : 移動元のパス
        //        | string dstPath : 移動先のパス
        //        | bool ow        : 移動先の同名フォルダを上書きするか
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | DirectoryNotFoundException
        //        | IOException
        //        | PathTooLongException
        //        | System.ArgumentException
        //        | System.ArgumentNullException
        //        | UnauthorizedAccessException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void MoveFolder(string srcPath, string dstPath, bool ow = false)
        {
            // 移動先に同名のフォルダが存在する場合
            if (Directory.Exists(dstPath))
            {
                // 上書きを行う場合、すでにあるフォルダを削除
                if (ow)
                {
                    Directory.Delete(dstPath);
                }
                // 上書きを行わない場合は抜ける
                else
                {
                    return;
                }
            }

            // コピー実行
            Directory.Move(srcPath, dstPath);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // フォルダ(ディレクトリ)を削除
        // -------------------------------------------------------------
        // 引数   | string path : 対象のフォルダパス
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | DirectoryNotFoundException
        //        | IOException
        //        | PathTooLongException
        //        | System.ArgumentException
        //        | System.ArgumentNullException
        //        | UnauthorizedAccessException
        // -------------------------------------------------------------
        // 中身のあるフォルダも強制的に削除する
        // (サブフォルダ、およびファイルを再帰的に削除)
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void DeleteFolder(string path)
        {
            // 対象のフォルダが存在する場合のみ削除
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // エクスプローラを開く
        // -------------------------------------------------------------
        // 引数   | string path : 対象のフォルダパス
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | InvalidOperationException
        //        | ObjectDisposedException
        //        | PlatformNotSupportedException
        //        | System.ComponentModel.Win32Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void OpenExplorer(string path)
        {
            Process.Start("explorer.exe", path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // コマンドプロンプトを開く
        // -------------------------------------------------------------
        // 引数   | string path : 初期パス
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | InvalidOperationException
        //        | ObjectDisposedException
        //        | PlatformNotSupportedException
        //        | System.ComponentModel.Win32Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void OpenCmd(string path)
        {
            Process.Start("cmd.exe", "/k cd " + path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // リムーバブルメディアを安全に取り外す
        // (ボリュームのマウント解除)
        // -------------------------------------------------------------
        // 引数   | string path : 初期パス
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | InvalidOperationException
        //        | ObjectDisposedException
        //        | PlatformNotSupportedException
        //        | System.ComponentModel.Win32Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool Dismount_Volume()
        {
            DriveInfo driveInfo = new DriveInfo("V");

            if (null == driveInfo)
            {
                throw new DirectoryNotFoundException();
            }

            _Win32ApiWrapper.DeviceIoControl()

            return true;
        }

    }       // public class FileOperate

}       // namespace Util
