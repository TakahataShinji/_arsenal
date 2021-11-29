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
        // 引数   | string path : [I]検査対象ファイル名
        // -------+-----------------------------------------------------
        // 戻り値 | bool : ファイルの有無
        //        |        true  - 指定されたファイルが存在する
        //        |        false - 指定されたファイルが存在しない
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool FileExists(string path)
        {
            return File.Exists(path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ディレクトリの有無を確認する
        // -------+-----------------------------------------------------
        // 引数   | string path : [I]検査対象ディレクトリ名
        // -------+-----------------------------------------------------
        // 戻り値 | bool : ディレクトリの有無
        //        |        true  - 指定されたディレクトリが存在する
        //        |        false - 指定されたディレクトリが存在しない
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイルの拡張子を取得する
        // -------+-----------------------------------------------------
        // 引数   | string path : [I]検査対象ファイル名
        // -------+-----------------------------------------------------
        // 戻り値 | string : ファイルの拡張子
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string GetFileExtension(string path)
        {
            return (new FileInfo(path)).Extension;
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // パスを除いたファイル名を取得する
        // -------+-----------------------------------------------------
        // 引数   | string path : [I]検査対象ファイル名
        // -------+-----------------------------------------------------
        // 戻り値 | string : パスを除いたファイル名
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string GetFileRawName(string path)
        {
            return (new FileInfo(path)).Name;
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイルの拡張子を変更する
        // -------+-----------------------------------------------------
        // 引数   | string path : [I]検査対象ファイル名
        //        |        ext  : [I]変更後の拡張子
        // -------+-----------------------------------------------------
        // 戻り値 | string : 変更後のファイル名
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string ConvFileExtension(string path, string ext)
        {
            try
            {
                // '.'の前までを抽出
                string name = path.Substring(0, path.IndexOf('.'));

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
        // 引数   | string src : [I]コピー元ファイル名
        //        | string dst : [I]コピー先ファイル名
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // -------+-----------------------------------------------------
        // 同名のファイルがすでに存在する場合は上書きする
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void CopyFile(string src, string dst)
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
        // 引数   | string src : [I]コピー元ファイル名
        //        | string dst : [I]コピー先ディレクトリ
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // -------+-----------------------------------------------------
        // 同名のファイルがすでに存在する場合は上書きする
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void CopyFileToDir(string src, string dst)
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
        // 引数   | string src : [I]移動元ファイル名
        //        | string dst : [I]移動先ファイル名
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void MoveFile(string src, string dst)
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
        // 引数   | string src : [I]移動元ファイル名
        //        | string dst : [I]移動先ディレクトリ
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void MoveFileToDir(string src, string dst)
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
        // 引数   | string path : [I]削除対象ファイル名
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void DeleteFile(string path)
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
        // 引数   | string path : [I]対象ファイル名
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // -------+-----------------------------------------------------
        // 作成日時・更新日時・最終アクセス日時を現在日時に設定
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void UpdateFileTimeStamp(string path)
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
        // 引数   | string path : [I]対象ファイル名
        // -------+-----------------------------------------------------
        // 戻り値 | Int64 : ファイルサイズ[バイト]
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static Int64 GetFileSize(string path)
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
        // 戻り値 | string - カレントディレクトリのパス
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string GetCurrentDir()
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
        // 引数   | string path : [I]変更先のディレクトリ
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void SetCurrentDir(string path)
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
        // 引数   | string path            : [I]対象ディレクトリ
        //        | List<string> list_Dirs : [I/O]path のサブディレクトリ一覧
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // -------+-----------------------------------------------------
        // 引数として渡された list_Dirs の末尾に追記する
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void GetSubDirectories(string path, ref List<string> list_Dirs)
        {
            try
            {
                // path に含まれるサブディレクトリをスキャン
                foreach (string subDir in Directory.GetDirectories(path))
                {
                    // サブディレクトリをリストに追加
                    list_Dirs.Add(subDir);

                    // サブディレクトリに含まれるディレクトリを再帰的に取得
                    GetSubDirectories(subDir, ref list_Dirs);
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
        // 引数   | string src : [I]コピー元ルートディレクトリ
        //        | string dst : [I]コピー先ルートディレクトリ
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void CopyDirectory(string srcDir, string dstDir)
        {
            try
            {
                // コピー先ルートディレクトリが存在しない場合は作成
                if (!(Directory.Exists(dstDir)))
                {
                    Directory.CreateDirectory(dstDir);
                }

                // コピー元ルートディレクトリに含まれるサブディレクトリをスキャン
                foreach (string subDir_Src in Directory.GetDirectories(srcDir))
                {
                    // コピー先ディレクトリのパスを取得
                    // (コピー先ディレクトリパスのルート部を置換)
                    string subDir_Dst = subDir_Src.Replace(srcDir, dstDir);

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
        // 引数   | string src : [I]移動元ディレクトリ
        //        | string dst : [I]移動先ディレクトリ
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void MoveDirectory(string src, string dst)
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
        // 引数   | string path : [I]削除対象ディレクトリ
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void DeleteDirectory(string path)
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
        // 引数   | string path : [I]対象ディレクトリ名
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // -------+-----------------------------------------------------
        // 作成日時・更新日時・最終アクセス日時を現在日時に設定
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void UpdateDirectoryTimeStamp(string path)
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
        // 引数   | string path : [I]対象ディレクトリ名
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // -------+-----------------------------------------------------
        // 作成日時・更新日時・最終アクセス日時を現在日時に設定
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void UpdateDirectoryTimeStampRecursively(string path)
        {
            try
            {
                // 自身のタイムスタンプを更新
                UpdateDirectoryTimeStamp(path);

                // 直下にあるファイルのタイムスタンプを更新
                foreach (string file in GetFiles(path))
                {
                    UpdateFileTimeStamp(file);
                }

                // サブディレクトリを再帰的に走査
                foreach (string subDir in Directory.GetDirectories(path))
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
        // 引数   | string path  : [I]対象ディレクトリのパス
        //        | bool uncount : [I]ルートディレクトリ直下のファイルを除外するか
        //        |                   デフォルト - false
        // -------+-----------------------------------------------------
        // 戻り値 | Int64 : ディレクトリサイズ[バイト]
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static Int64 GetDirectorySize(string path, bool uncount = false)
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
        // 引数   | string path  : [I]対象ディレクトリのパス
        //        | bool uncount : [I]ルートディレクトリ直下のファイルを除外するか
        //        |                   デフォルト - false
        // -------+-----------------------------------------------------
        // 戻り値 | Int64 : ファイル数
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static Int64 GetNumberOfFiles(string path, bool uncount = false)
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
                foreach (string dir in Directory.GetDirectories(path))
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
        // ディレクトリに含まれるファイルのうち、
        // パターンに合致するものの一覧を取得する
        // -------+-----------------------------------------------------
        // 引数   | string path    : [I]対象ディレクトリ
        //        | string pattern : [I]ファイルパターン
        //        |                     null の場合はすべてのファイル
        // -------+-----------------------------------------------------
        // 戻り値 | string[] : ファイル一覧
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string[] GetFiles(string path, string pattern = "")
        {
            try
            {
                if (pattern == "")
                {
                    return Directory.GetFiles(path);
                }
                return Directory.GetFiles(path, pattern);
            }
            catch
            {
                throw new Exception("GetFiles");
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 下位ディレクトリに含まれるファイルの一覧を再帰的に取得する
        // -------+-----------------------------------------------------
        // 引数   | string path             : [I]対象ディレクトリ
        //        | List<string> list_Files : [I/O]path 以下に含まれるファイル一覧
        //        | bool uncount            : [I]ルートディレクトリ直下のファイルを除外するか
        //        |                             デフォルト - false
        // -------+-----------------------------------------------------
        // 例外   | Exception
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void GetFilesRecursively(string path, 
                                               ref List<string> list_Files, 
                                               bool uncount = false)
        {
            try
            {
                // (除外設定なしの場合) path に含まれるファイルをリストに追加
                if (!uncount)
                {
                    list_Files.AddRange(GetFiles(path));
                }

                // サブディレクトリに含まれるファイルを追加(再帰)
                foreach (string dir in Directory.GetDirectories(path))
                {
                    GetFilesRecursively(dir, ref list_Files);
                }
            }
            catch
            {
                throw new Exception("GetFiles");
            }
        }

    }       // class FileOperate
}       // namespace Util
