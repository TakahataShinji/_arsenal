// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
//
// FileOperate
//
// [static]ファイルの操作
//
// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace Util
{
    static class FileOperate
    {
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public メソッド (static)
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイルの有無を確認する
        // -------+-----------------------------------------------------
        // 引数   | String path : [I]検査対象ファイル名
        // -------+-----------------------------------------------------
        // 戻り値 | bool : ファイルの有無
        //        |        true  - 指定されたファイルが存在する
        //        |        false - 指定されたファイルが存在しない
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool FileExists(String path)
        {
            return File.Exists(path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ディレクトリの有無を確認する
        // -------+-----------------------------------------------------
        // 引数   | String path : [I]検査対象ディレクトリ名
        // -------+-----------------------------------------------------
        // 戻り値 | bool : ディレクトリの有無
        //        |        true  - 指定されたディレクトリが存在する
        //        |        false - 指定されたディレクトリが存在しない
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool DirectoryExists(String path)
        {
            return Directory.Exists(path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイルの拡張子を取得する
        // -------+-----------------------------------------------------
        // 引数   | String path : [I]検査対象ファイル名
        // -------+-----------------------------------------------------
        // 戻り値 | String : ファイルの拡張子
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static String GetFileExtension(String path)
        {
            return (new FileInfo(path)).Extension;
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイルの拡張子を変更する
        // -------+-----------------------------------------------------
        // 引数   | String path : [I]検査対象ファイル名
        //        |        ext  : [I]変更後の拡張子
        // -------+-----------------------------------------------------
        // 戻り値 | String : 変更後のファイル名
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static String ConvFileExtension(String path, String ext)
        {
            try
            {
                // '.'の前までを抽出
                String name = path.Substring(0, path.IndexOf('.'));

                // 変更後拡張子'.'より後を抽出
                if (ext[0] == '.')
                {
                    ext = ext.Substring(1);
                }

                // ファイル名を変更
                name += '.' + ext;
                File.Move(path, name);

                return name;
            }
            catch
            {
                throw new Exception("ConvFileExtension");
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイルをコピーする
        // -------+-----------------------------------------------------
        // 引数   | String src : [I]コピー元ファイル名
        //        | String dst : [I]コピー先ファイル名
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // -------+-----------------------------------------------------
        // 同名のファイルがすでに存在する場合は上書きする
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void CopyFile(String src, String dst)
        {
            try
            {
                File.Copy(src, dst, true);
            }
            catch
            {
                throw new Exception("CopyFile");
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイルを指定したディレクトリにコピーする
        // -------+-----------------------------------------------------
        // 引数   | String src : [I]コピー元ファイル名
        //        | String dst : [I]コピー先ディレクトリ
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // -------+-----------------------------------------------------
        // 同名のファイルがすでに存在する場合は上書きする
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void CopyFileToDir(String src, String dst)
        {
            try
            {
                dst += @"\" + (new FileInfo(src)).Name;
                File.Copy(src, dst, true);
            }
            catch
            {
                throw new Exception("CopyFileToDir");
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイルを移動する
        // -------+-----------------------------------------------------
        // 引数   | String src : [I]移動元ファイル名
        //        | String dst : [I]移動先ファイル名
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void MoveFile(String src, String dst)
        {
            try
            {
                File.Move(src, dst);
            }
            catch
            {
                throw new Exception("MoveFile");
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイルを指定したディレクトリに移動する
        // -------+-----------------------------------------------------
        // 引数   | String src : [I]移動元ファイル名
        //        | String dst : [I]移動先ディレクトリ
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void MoveFileToDir(String src, String dst)
        {
            try
            {
                dst += @"\" + (new FileInfo(src)).Name;
                File.Move(src, dst);
            }
            catch
            {
                throw new Exception("MoveFileToDir");
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイルを削除する
        // -------+-----------------------------------------------------
        // 引数   | String path : [I]削除対象ファイル名
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void DeleteFile(String path)
        {
            try
            {
                File.Delete(path);
            }
            catch
            {
                throw new Exception("DeleteFile");
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイルのタイムスタンプを更新する
        // -------+-----------------------------------------------------
        // 引数   | String path : [I]対象ファイル名
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // -------+-----------------------------------------------------
        // 作成日時・更新日時・最終アクセス日時を現在日時に設定
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void UpdateFileTimeStamp(String path)
        {
            try
            {
                FileInfo fi = new FileInfo(path);
                fi.CreationTime = fi.LastWriteTime = fi.LastAccessTime = DateTime.Now;
            }
            catch
            {
                throw new Exception("UpdateFileTimeStamp");
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイルのサイズ(バイト単位)を取得する
        // -------+-----------------------------------------------------
        // 引数   | String path : [I]対象ファイル名
        // -------+-----------------------------------------------------
        // 戻り値 | Int64 : ファイルサイズ[バイト]
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static Int64 GetFileSize(String path)
        {
            try
            {
                return (new FileInfo(path)).Length;
            }
            catch
            {
                throw new Exception("GetFileSize");
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // カレントディレクトリを取得
        // -------+-----------------------------------------------------
        // 引数   | なし
        // -------+-----------------------------------------------------
        // 戻り値 | String - カレントディレクトリのパス
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static String GetCurrentDir()
        {
            try
            {
                return Directory.GetCurrentDirectory();
            }
            catch
            {
                throw new Exception("GetCurrentDir");
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // カレントディレクトリを変更
        // -------+-----------------------------------------------------
        // 引数   | String path : [I]変更先のディレクトリ
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void SetCurrentDir(String path)
        {
            try
            {
                Directory.SetCurrentDirectory(path);
            }
            catch
            {
                throw new Exception("SetCurrentDir");
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 指定されたディレクトリの下位ディレクトリを再帰的に取得する
        // -------+-----------------------------------------------------
        // 引数   | String path           : [I]対象ディレクトリ
        //        | List<String>list_Dirs : [O]path のサブディレクトリ一覧
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void GetSubDirectories(String path, List<String>list_Dirs)
        {
            try
            {
                // path に含まれるサブディレクトリをスキャン
                foreach (String subDir in Directory.GetDirectories(path))
                {
                    // サブディレクトリをリストに追加
                    list_Dirs.Add(subDir);

                    // サブディレクトリに含まれるディレクトリを再帰的に取得
                    GetSubDirectories(subDir, list_Dirs);
                }
            }
            catch
            {
                throw new Exception("GetSubDirectories");
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ディレクトリ構造を再帰的にコピーする
        // -------+-----------------------------------------------------
        // 引数   | String src : [I]コピー元ルートディレクトリ
        //        | String dst : [I]コピー先ルートディレクトリ
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void CopyDirectory(String srcDir, String dstDir)
        {
            try
            {
                // コピー先ルートディレクトリが存在しない場合は作成
                if (!(Directory.Exists(dstDir)))
                {
                    Directory.CreateDirectory(dstDir);
                }

                // コピー元ルートディレクトリに含まれるサブディレクトリをスキャン
                foreach (String subDir_Src in Directory.GetDirectories(srcDir))
                {
                    // コピー先ディレクトリのパスを取得
                    // (コピー先ディレクトリパスのルート部を置換)
                    String subDir_Dst = subDir_Src.Replace(srcDir, dstDir);

                    // コピー先ディレクトリが既に存在する場合はタイムスタンプ更新
                    if (Directory.Exists(subDir_Dst))
                    {
                        UpdateDirectoryTimeStamp(subDir_Dst);
                    }
                    // コピー先ディレクトリが存在しない場合は新たに作成
                    else
                    { 
                        Directory.CreateDirectory(subDir_Dst);
                    }

                    // サブディレクトリの下位構造を再帰的にコピー
                    CopyDirectory(subDir_Src, subDir_Dst);
                }
            }
            catch
            {
                throw new Exception("CopyDirectory");
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ディレクトリを移動する
        // -------+-----------------------------------------------------
        // 引数   | String src : [I]移動元ディレクトリ
        //        | String dst : [I]移動先ディレクトリ
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void MoveDirectory(String src, String dst)
        {
            try
            {
                Directory.Move(src, dst);
            }
            catch
            {
                throw new Exception("MoveDirectory");
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ディレクトリを削除する
        // -------+-----------------------------------------------------
        // 引数   | String path : [I]削除対象ディレクトリ
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void DeleteDirectory(String path)
        {
            try
            {
                Directory.Delete(path);
            }
            catch
            {
                throw new Exception("DeleteDirectory");
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ディレクトリのタイムスタンプを更新する
        // -------+-----------------------------------------------------
        // 引数   | String path : [I]対象ディレクトリ名
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // -------+-----------------------------------------------------
        // 作成日時・更新日時・最終アクセス日時を現在日時に設定
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void UpdateDirectoryTimeStamp(String path)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(path);
                di.CreationTime = di.LastWriteTime = di.LastAccessTime = DateTime.Now;
            }
            catch
            {
                throw new Exception("UpdateDirectoryTimeStamp");
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ディレクトリのタイムスタンプを更新する
        // (サブディレクトリを再帰的に走査)
        // -------+-----------------------------------------------------
        // 引数   | String path : [I]対象ディレクトリ名
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // -------+-----------------------------------------------------
        // 作成日時・更新日時・最終アクセス日時を現在日時に設定
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void UpdateDirectoryTimeStampRecursively(String path)
        {
            try
            {
                // 自身のタイムスタンプを更新
                UpdateDirectoryTimeStamp(path);

                // 直下にあるファイルのタイムスタンプを更新
                foreach (String file in GetFiles(path))
                {
                    UpdateFileTimeStamp(file);
                }

                // サブディレクトリを再帰的に走査
                foreach (String subDir in Directory.GetDirectories(path))
                {
                    UpdateDirectoryTimeStampRecursively(subDir);
                }
            }
            catch
            {
                throw new Exception("UpdateDirectoryTimeStampRecursively");
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ディレクトリのサイズ(バイト単位)を取得する
        // -------+-----------------------------------------------------
        // 引数   | DirectoryInfo di : [I]対象ディレクトリのディレクトリ情報
        //        | bool uncount     : [I]ルートディレクトリ直下のファイルを除外するか
        //        |                       デフォルト - false
        // -------+-----------------------------------------------------
        // 戻り値 | Int64 : ディレクトリサイズ[バイト]
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static Int64 GetDirectorySize(DirectoryInfo di, bool uncount = false)
        {
            Int64 size = 0;     //< 返却するサイズ

            try
            {
                // (除外設定なしの場合)当該ディレクトリに含まれるファイルの合計サイズを加算
                if (!uncount)
                {
                    foreach (FileInfo fi in di.GetFiles())
                    {
                        size += fi.Length;
                    }
                }

                // サブディレクトリの合計サイズを加算(再帰)
                foreach (DirectoryInfo di_Sub in di.GetDirectories())
                {
                    size += GetDirectorySize(di_Sub);
                }
            }
            catch
            {
                throw new Exception("GetDirectorySize");
            }

            return size;
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ディレクトリのサイズ(バイト単位)を取得する
        // -------+-----------------------------------------------------
        // 引数   | String path  : [I]対象ディレクトリのパス
        //        | bool uncount : [I]ルートディレクトリ直下のファイルを除外するか
        //        |                   デフォルト - false
        // -------+-----------------------------------------------------
        // 戻り値 | Int64 : ディレクトリサイズ[バイト]
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static Int64 GetDirectorySize(String path, bool uncount = false)
        {
            try
            {
                return GetDirectorySize(new DirectoryInfo(path), uncount);
            }
            catch
            {
                throw new Exception("GetDirectorySize");
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ディレクトリに含まれるファイル数を取得する
        // -------+-----------------------------------------------------
        // 引数   | String path  : [I]対象ディレクトリのパス
        //        | bool uncount : [I]ルートディレクトリ直下のファイルを除外するか
        //        |                   デフォルト - false
        // -------+-----------------------------------------------------
        // 戻り値 | Int64 : ファイル数
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static Int64 GetNumberOfFiles(String path, bool uncount = false)
        {
            Int64 num = 0;

            try
            {
                // (除外設定なしの場合) path に含まれるファイル数を加算
                if (!uncount)
                {
                    num += Directory.GetFiles(path).Length;
                }

                // サブディレクトリに含まれるファイル数を加算(再帰)
                foreach (String dir in Directory.GetDirectories(path))
                {
                    num += GetNumberOfFiles(dir);
                }
            }
            catch
            {
                throw new Exception("GetNumberOfFiles");
            }

            return num;
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ディレクトリに含まれるファイルの一覧を取得する
        // -------+-----------------------------------------------------
        // 引数   | String path : [I]対象ディレクトリ
        // -------+-----------------------------------------------------
        // 戻り値 | String[] : ファイル一覧
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static String[] GetFiles(String path)
        {
            try
            {
                return Directory.GetFiles(path);
            }
            catch
            {
                throw new Exception("GetFiles");
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 下位ディレクトリに含まれるファイルの一覧を再帰的に取得する
        // -------+-----------------------------------------------------
        // 引数   | String path            : [I]対象ディレクトリ
        //        | List<String>list_Files : [O]path 以下に含まれるファイル一覧
        //        | bool uncount           : [I]ルートディレクトリ直下のファイルを除外するか
        //        |                             デフォルト - false
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void GetFilesRecursively(String path, List<String> list_Files, bool uncount = false)
        {
            try
            {
                // (除外設定なしの場合) path に含まれるファイルをリストに追加
                if (!uncount)
                {
                    list_Files.AddRange(GetFiles(path));
                }

                // サブディレクトリに含まれるファイルを追加(再帰)
                foreach (String dir in Directory.GetDirectories(path))
                {
                    GetFilesRecursively(dir, list_Files);
                }
            }
            catch
            {
                throw new Exception("GetFiles");
            }
        }

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
