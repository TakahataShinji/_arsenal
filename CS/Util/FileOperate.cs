using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Util
{
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    /// <summary>
    /// [static]ファイルの操作 
    /// </summary>
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    static class FileOperate
    {
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// public 定数
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        ///<summary>
        /// パスの属性
        ///</summary>
        public enum E_Attributes
        {
            FILE,       //< ファイル
            DIRECTORY,  //< ディレクトリ
            NONE,       //< 無し(不明)
        }

        /// <summary>不正なサイズ</summary>
        public static readonly long C_INVALIDSIZE = -1;

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// public プロパティ (static)
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// <summary>カレントディレクトリ</summary>
        public static string CurrentDir
        {
            // カレントディレクトリの取得
            get
            {
                return Directory.GetCurrentDirectory();
            }
            // カレントディレクトリの設定
            set
            {
                Directory.SetCurrentDirectory(value);
            }
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// public メソッド (static)
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// 実行中アセンブリのパスを取得する
        /// </summary>
        /// <returns>実行中アセンブリのパス</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string GetExecutingPath()
        {
            return Assembly.GetExecutingAssembly().Location;
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// 実行中アセンブリの親ディレクトリを取得する
        /// </summary>
        /// <returns>実行中アセンブリのパス</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string? GetExecutingDir()
        {
            return new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] パスの属性を取得する
        /// </summary>
        /// <param name="path">[I]検査対象パス</param>
        /// <returns>パスの属性<br/>
        ///          E_Attributes.FILE      - ファイル<br/>
        ///          E_Attributes.DIRECTORY - ディレクトリ</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static E_Attributes GetAttributes(string path)
        {
            // ディレクトリフラグが存在すればディレクトリ、
            // それ以外はファイルと見なす
            return
            File.GetAttributes(path).HasFlag(FileAttributes.Directory) ?
            E_Attributes.DIRECTORY : E_Attributes.FILE;
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ファイルの有無を確認する
        /// </summary>
        /// <param name="path">[I]検査対象ファイル名</param>
        /// <returns>ファイルの有無<br/>
        ///          true  - 指定されたファイルが存在する<br/>
        ///          false - 指定されたファイルが存在しない</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool FileExists(string path)
        {
            return File.Exists(path);
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ディレクトリの有無を確認する
        /// </summary>
        /// <param name="path">[I]検査対象ディレクトリ名</param>
        /// <returns>ディレクトリの有無<br/>
        ///          true  - 指定されたディレクトリが存在する<br/>
        ///          false - 指定されたディレクトリが存在しない</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ファイルまたはディレクトリの有無を確認する
        /// </summary>
        /// <param name="path">[I]検査対象パス</param>
        /// <returns>ファイル・ディレクトリの有無<br/>
        ///          true  - 指定されたファイル・ディレクトリが存在する<br/>
        ///          false - 指定されたファイル・ディレクトリが存在しない</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool Exists(string path)
        {
            // 属性が取得できる ⇒ ファイルまたはディレクトリが存在すると見なす
            return GetAttributes(path) != E_Attributes.NONE;
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] パスを除いたファイル・ディレクトリ名を取得する
        /// </summary>
        /// <param name="path">[I]検査対象パス</param>
        /// <returns>パスを除いたファイル・ディレクトリ名<br/>
        ///          対象が存在しない場合は空文字列</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string GetRawName(string path)
        {
            switch (GetAttributes(path))
            {
                // ファイル
                case E_Attributes.FILE:
                    return (new FileInfo(path)).Name;

                // ディレクトリ
                case E_Attributes.DIRECTORY:
                    return (new DirectoryInfo(path)).Name;
            }

            return String.Empty;
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] 相対パスを絶対パスに変換する
        /// </summary>
        /// <param name="path">[I]検査対象パス</param>
        /// <returns>絶対パス<br/>
        ///          対象が存在しない場合は空文字列</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string GetAbsolutePath(string path)
        {
            return Path.GetFullPath(path);
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ファイルの拡張子を取得する
        /// </summary>
        /// <param name="path">[I]検査対象パス</param>
        /// <returns>ファイルの拡張子<br/>
        ///          対象が存在しない場合は空文字列</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string GetFileExtension(string path)
        {
            return (new FileInfo(path)).Extension;
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ファイルの拡張子を変更する
        /// </summary>
        /// <param name="path">[I]変更前のファイルパス</param>
        /// <param name="ext">[I]変更後の拡張子</param>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void ChangeFileExtension(string path, string ext)
        {
            // (ext が "." を含む場合)"."を取り除く
            ext = ext.Replace(".", "");

            // ファイル名を変更
            string newName = path.Remove(path.LastIndexOf('.'));
            newName += '.' + ext;
            File.Move(path, newName);
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ディレクトリに含まれるファイルの一覧を取得する
        /// </summary>
        /// <param name="path">         [I]対象ディレクトリ</param>
        ///                                空の場合はカレントディレクトリ
        /// <param name="recursive">    [I]サブフォルダを含めるか<br/>
        ///                                true  - 含める<br/>
        ///                                false - 含めない</param>
        /// <param name="pattern">      [I]ファイルパターン<br/>
        ///                                空の場合はすべてのファイル</param>
        /// <returns>取得したファイル一覧</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static List<string> GetFiles(string path = "",
                                         bool recursive = false,
                                         string pattern = "")
        {
            var ret = new List<string>();
            if (String.IsNullOrEmpty(path))
            {
                path = CurrentDir;
            }
            GetFiles_Core(path, ref ret, pattern, recursive);
            return ret;
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ディレクトリに含まれるファイル数を取得する
        /// </summary>
        /// <param name="path">         [I]対象ディレクトリ</param>
        ///                                空の場合はカレントディレクトリ
        /// <param name="recursive">    [I]サブフォルダを含めるか<br/>
        ///                                true  - 含める<br/>
        ///                                false - 含めない</param>
        /// <param name="pattern">      [I]ファイルパターン<br/>
        ///                                空の場合はすべてのファイル</param>
        /// <returns>ファイル総数<br/>
        ///          失敗時は 0</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static long GetNumberOfFiles(string path = "",
                                            bool recursive = false,
                                            string pattern = "")
        {
            // GetFiles() != null ⇒ GetFiles().Length
            // GetFiles() == null ⇒ 0
            return GetFiles(path, recursive, pattern)?.Count ?? 0;
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] 指定されたディレクトリの下位ディレクトリを再帰的に取得する
        /// </summary>
        /// <param name="path">[I]ルートディレクトリ</param>
        /// <returns>path のサブディレクトリ一覧</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static List<string> GetSubDirectories(string path)
        {
            var ret = new List<string>();
            GetSubDirectories_Core(path, ref ret);
            return ret;
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ファイルをコピーする
        /// </summary>
        /// <param name="src">[I]コピー元ファイル名</param>
        /// <param name="dst">[I]コピー先ファイル名 または<br/>
        ///                      コピー先ディレクトリ</param>
        /// <param name="ow"> [I]同名のファイルが存在する場合に上書きするか<br/>
        ///                      true  - 上書きする<br/>
        ///                      false - 上書きしない(デフォルト)</param>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void CopyFile(string src, string dst, bool ow = false)
        {
            // dst がディレクトリの場合
            if (GetAttributes(dst) == E_Attributes.DIRECTORY)
            {
                dst += @"\" + (new FileInfo(src)).Name;
            }

            File.Copy(src, dst, ow);
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ディレクトリ構造を再帰的にコピーする
        /// </summary>
        /// <param name="srcDir">[I]コピー元ルートディレクトリ</param>
        /// <param name="dstDir">[I]コピー先ルートディレクトリ</param>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void CopyDirectory(string srcDir, string dstDir)
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
                    UpdateDirectoryTimeStamp_Core(subDir_Dst, DateTime.Now);
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

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ファイルを移動する
        /// </summary>
        /// <param name="src">[I]移動元ファイル名</param>
        /// <param name="dst">[I]移動先ファイル名 または<br/>
        ///                      移動先ディレクトリ</param>
        /// <param name="ow"> [I]同名のファイルが存在する場合に上書きするか<br/>
        ///                      true  - 上書きする<br/>
        ///                      false - 上書きしない(デフォルト)</param>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void MoveFile(string src, string dst, bool ow = false)
        {
            // dst がディレクトリの場合
            if (GetAttributes(dst) == E_Attributes.DIRECTORY)
            {
                dst += @"\" + (new FileInfo(src)).Name;
            }

            File.Move(src, dst, ow);
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ディレクトリを移動する
        /// </summary>
        /// <param name="src">[I]移動元ディレクトリ</param>
        /// <param name="dst">[I]移動先ディレクトリ</param>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void MoveDirectory(string src, string dst)
        {
            Directory.Move(src, dst);
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ファイル・ディレクトリを削除する
        /// </summary>
        /// <param name="path">[I]削除対象ファイル・ディレクトリ</param>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Delete(string path)
        {
            switch (GetAttributes(path))
            {
                // ファイル
                case E_Attributes.FILE:
                    File.Delete(path);
                    return;

                // ディレクトリ
                case E_Attributes.DIRECTORY:
                    Directory.Delete(path);
                    return;
            }
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ファイル・ディレクトリのサイズ(バイト単位)を取得する
        /// </summary>
        /// <param name="path">[I]対象ファイル・ディレクトリ</param>
        /// <returns>ファイル・ディレクトリのサイズ<br/>
        ///          失敗時は C_INVALIDSIZE</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static long GetSize(string path)
        {
            switch (GetAttributes(path))
            {
                case E_Attributes.FILE:
                    return (new FileInfo(path)).Length;

                case E_Attributes.DIRECTORY:
                    return GetDirectorySize_Core(new DirectoryInfo(path));
            }

            return C_INVALIDSIZE;
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ファイル・ディレクトリのタイムスタンプを更新する
        /// </summary>
        /// <param name="path">[I]対象ファイル・ディレクトリ</param>
        /// <param name="dt">[I]更新後のタイムスタンプ</param>
        /// <param name="pattern">[I]対象とするファイルのパターン
        ///                          空の場合はすべてのファイル</param>
        /// <param name="recursive">[I]サブディレクトリを再帰的に走査するかどうか</param>                         
        ///                            true  - 再帰的に走査する
        ///                            false - 自身のみを対象とする
        /// <returns>処理結果<br/>
        ///          true  - 成功<br/>
        ///          false - 失敗</returns>
        /// <remarks>作成日時・更新日時・最終アクセス日時を現在日時に設定</remarks>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool UpdateTimeStamp(string path,
                                           DateTime dt,
                                           string pattern = "",
                                           bool recursive = false)
        {
            // 指定されたパス自身に対する処理
            switch (GetAttributes(path))
            {
                // ファイル
                case E_Attributes.FILE:
                    // タイムスタンプ更新
                    UpdateFileTimeStamp_Core(path, dt);
                    return true;

                // ディレクトリ
                case E_Attributes.DIRECTORY:
                    // タイムスタンプ更新
                    UpdateDirectoryTimeStamp_Core(path, dt);
                    // 再帰設定なし ⇒ ここで終了
                    if (!recursive)
                    {
                        return true;
                    }
                    break;

                // それ以外(対象不在) ⇒ 失敗
                default:
                    return false;
            }

            // サブディレクトリの一覧取得
            var list_Dirs = new List<string>();
            GetSubDirectories_Core(path, ref list_Dirs);
            // サブディレクトリのタイムスタンプ更新
            foreach (var item in list_Dirs)
            {
                UpdateDirectoryTimeStamp_Core(item, dt);
            }

            // ファイルの一覧取得
            var list_Files = new List<string>();
            GetFiles_Core(path, ref list_Files, pattern, true);
            // ファイルのタイムスタンプ更新
            foreach (var item in list_Files)
            {
                UpdateFileTimeStamp_Core(item, dt);
            }

            return true;

        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// private メソッド (static)
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ディレクトリのサイズ(バイト単位)を取得する
        /// </summary>
        /// <param name="di">[I]対象のディレクトリ情報</param>
        /// <returns>ファイル・ディレクトリのサイズ<br/>
        ///          失敗時は C_INVALIDSIZE</returns>
        /// <remarks>サブディレクトリを再帰的に走査する</remarks>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        private static long GetDirectorySize_Core(DirectoryInfo di)
        {
            long size = 0;     //< 返却するサイズ

            // サブディレクトリの合計サイズを加算(再帰)
            foreach (DirectoryInfo di_Sub in di.GetDirectories())
            {
                size += GetDirectorySize_Core(di_Sub);
            }

            return size;
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ディレクトリに含まれるファイルの一覧を取得する
        /// </summary>
        /// <param name="path">         [I]対象ディレクトリ</param>
        /// <param name="list_Files">   [I/O]取得したファイルの一覧</param>
        /// <param name="pattern">      [I]ファイルパターン<br/>
        ///                                空の場合はすべてのファイル</param>
        /// <param name="recursive">    [I]サブフォルダを含めるか<br/>
        ///                                true  - 含める<br/>
        ///                                false - 含めない</param>
        /// <exception cref="Exception"></exception>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        private static void GetFiles_Core(string path,
                                          ref List<string> list_Files,
                                          string pattern = "",
                                          bool recursive = false)
        {
            // 再帰設定なし ⇒ 当該ディレクトリ以下のファイルのみをリストに追加して抜ける
            if (!recursive)
            {
                list_Files.AddRange(GetFiles_Core_ItselfOnly(path, pattern));
                return;
            }

            // サブディレクトリを取得
            var dirs = Directory.GetDirectories(path);

            // サブディレクトリが存在する場合
            if (dirs?.Length > 0)
            {
                // サブディレクトリに含まれるファイルを追加(再帰)
                foreach (string dir in dirs)
                {
                    GetFiles_Core(dir, ref list_Files, pattern, true);
                }
            }
            // サブディレクトリが存在しない場合
            else
            {
                // 当該ディレクトリ以下のファイルのみをリストに追加
                list_Files.AddRange(GetFiles_Core_ItselfOnly(path, pattern));
            }
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ディレクトリに含まれるファイルの一覧を取得する<br/>
        ///          (当該ディレクトリのみ)
        /// </summary>
        /// <param name="path">[I]対象ディレクトリ</param>
        /// <param name="pattern">[I]ファイルパターン<br/>
        ///                          空の場合はすべてのファイル</param>
        /// <returns>ファイル一覧</returns>
        /// <exception cref="Exception"></exception>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        private static List<string> GetFiles_Core_ItselfOnly(string path, string pattern = "")
        {
            var ret = String.IsNullOrEmpty(pattern) ?
                Directory.GetFiles(path) :
                Directory.GetFiles(path, pattern);
            return new List<string>(ret);
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] 指定されたディレクトリの下位ディレクトリを再帰的に取得する
        /// </summary>
        /// <param name="path">[I]ルートディレクトリ</param>
        /// <param name="list_Dirs">[I/O]path のサブディレクトリ一覧</param>
        /// <returns>処理結果<br/>
        ///          true  - 成功<br/>
        ///          false - 失敗</returns>
        /// <remarks>引数として渡された list_Dirs の末尾に追記する</remarks>
        /// <exception cref="Exception"></exception>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        private static void GetSubDirectories_Core(string path, ref List<string> list_Dirs)
        {
            // path に含まれるサブディレクトリをスキャン
            foreach (string subDir in Directory.GetDirectories(path))
            {
                // サブディレクトリをリストに追加
                list_Dirs.Add(subDir);

                // サブディレクトリに含まれるディレクトリを再帰的に取得
                GetSubDirectories_Core(subDir, ref list_Dirs);
            }
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ファイルのタイムスタンプを更新する
        /// </summary>
        /// <param name="path">[I]対象ファイル</param>
        /// <param name="dt">[I]更新後のタイムスタンプ</param>
        /// <returns>処理結果<br/>
        ///          true  - 成功<br/>
        ///          false - 失敗</returns>
        /// <remarks>作成日時・更新日時・最終アクセス日時を現在日時に設定</remarks>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        private static void UpdateFileTimeStamp_Core(string path, DateTime dt)
        {
            FileInfo fi = new FileInfo(path);
            fi.CreationTime = fi.LastWriteTime = fi.LastAccessTime = dt;
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ディレクトリのタイムスタンプを更新する
        /// </summary>
        /// <param name="path">[I]対象ディレクトリ</param>
        /// <param name="dt">[I]更新後のタイムスタンプ</param>
        /// <returns>処理結果<br/>
        ///          true  - 成功<br/>
        ///          false - 失敗</returns>
        /// <remarks>作成日時・更新日時・最終アクセス日時を現在日時に設定</remarks>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        private static void UpdateDirectoryTimeStamp_Core(string path, DateTime dt)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            di.CreationTime = di.LastWriteTime = di.LastAccessTime = dt;
        }

    }       // class FileOperate
}       // namespace Util
