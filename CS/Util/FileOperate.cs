using System;
using System.Collections.Generic;
using System.IO;

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
                try
                {
                    return Directory.GetCurrentDirectory();
                }
                catch
                {
                    return String.Empty;
                }
            }
            // カレントディレクトリの設定
            set
            {
                try
                {
                    Directory.SetCurrentDirectory(value);
                }
                catch
                {
                    // 何もしない
                }
            }
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// public メソッド (static)
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] パスの属性を取得する
        /// </summary>
        /// <param name="path">[I]検査対象パス</param>
        /// <returns>パスの属性<br/>
        ///          E_Attributes.FILE      - ファイル<br/>
        ///          E_Attributes.DIRECTORY - ディレクトリ<br/>
        ///          E_Attributes.NONE      - 無し(不明または存在しない)</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static E_Attributes GetAttributes(string path)
        {
            try
            {
                // ディレクトリフラグが存在すればディレクトリ、
                // それ以外はファイルと見なす
                return
                File.GetAttributes(path).HasFlag(FileAttributes.Directory) ?
                E_Attributes.DIRECTORY : E_Attributes.FILE;
            }
            // 例外発生時
            catch
            {
                // 属性無し
                return E_Attributes.NONE;
            }
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
            try
            {
                return Path.GetFullPath(path);
            }
            catch
            {
                return String.Empty;
            }
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
            try
            {
                return (new FileInfo(path)).Extension;
            }
            catch
            {
                return String.Empty;
            }
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ファイルの拡張子を変更する
        /// </summary>
        /// <param name="path">[I]変更前のファイルパス</param>
        /// <param name="ext">[I]変更後の拡張子</param>
        /// <returns>処理結果<br/>
        ///          true  - 成功<br/>
        ///          false - 失敗</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool ChangeFileExtension(string path, string ext)
        {
            try
            {
                // (ext が "." を含む場合)"."を取り除く
                ext = ext.Replace(".", "");

                // ファイル名を変更
                string newName = path.Remove(path.LastIndexOf('.'));
                newName += '.' + ext;
                File.Move(path, newName);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ディレクトリに含まれるファイルの一覧を取得する
        /// </summary>
        /// <param name="path">         [I]対象ディレクトリ</param>
        ///                                null の場合はカレントディレクトリ
        /// <param name="recursive">    [I]サブフォルダを含めるか<br/>
        ///                                true  - 含める<br/>
        ///                                false - 含めない</param>
        /// <param name="pattern">      [I]ファイルパターン<br/>
        ///                                null の場合はすべてのファイル</param>
        /// <param name="ignoreItself"> [I]自身の直下のファイルを無視するか<br/>
        ///                                true  - 無視する<br/>
        ///                                false - 無視しない</param>
        /// <returns>取得したファイル一覧</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string[]? GetFiles(string? path = null,
                                         bool recursive = false,
                                         string? pattern = null,
                                         bool ignoreItself = false)
        {
            try
            {
                var ret = new List<string>();
                GetFiles_Core(path ?? CurrentDir, ref ret, pattern, recursive, ignoreItself);
                return ret.ToArray();
            }
            catch
            {
                return null;
            }
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ディレクトリに含まれるファイル数を取得する
        /// </summary>
        /// <param name="path">         [I]対象ディレクトリ</param>
        ///                                null の場合はカレントディレクトリ
        /// <param name="recursive">    [I]サブフォルダを含めるか<br/>
        ///                                true  - 含める<br/>
        ///                                false - 含めない</param>
        /// <param name="pattern">      [I]ファイルパターン<br/>
        ///                                null の場合はすべてのファイル</param>
        /// <param name="ignoreItself"> [I]自身の直下のファイルを無視するか<br/>
        ///                                true  - 無視する<br/>
        ///                                false - 無視しない</param>
        /// <returns>ファイル総数<br/>
        ///          失敗時は 0</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static long GetNumberOfFiles(string? path = null,
                                            bool recursive = false,
                                            string? pattern = null,
                                            bool ignoreItself = false)
        {
            // GetFiles() != null ⇒ GetFiles().Length
            // GetFiles() == null ⇒ 0
            return GetFiles(path, recursive, pattern, ignoreItself)?.Length ?? 0;
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] 指定されたディレクトリの下位ディレクトリを再帰的に取得する
        /// </summary>
        /// <param name="path">[I]ルートディレクトリ</param>
        /// <returns>path のサブディレクトリ一覧<br/>
        ///          失敗時は null</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string[]? GetSubDirectories(string path)
        {
            try
            {
                var ret = new List<string>();
                GetSubDirectories_Core(path, ref ret);
                return ret.ToArray();
            }
            catch
            {
                return null;
            }
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
        /// <returns>処理結果<br/>
        ///          true  - 成功<br/>
        ///          false - 失敗</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool CopyFile(string src, string dst, bool ow = false)
        {
            try
            {
                // dst がディレクトリの場合
                if (GetAttributes(dst) == E_Attributes.DIRECTORY)
                {
                    dst += @"\" + (new FileInfo(src)).Name;
                }

                File.Copy(src, dst, ow);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ディレクトリ構造を再帰的にコピーする
        /// </summary>
        /// <param name="srcDir">[I]コピー元ルートディレクトリ</param>
        /// <param name="dstDir">[I]コピー先ルートディレクトリ</param>
        /// <returns>処理結果<br/>
        ///          true  - 成功<br/>
        ///          false - 失敗</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool CopyDirectory(string srcDir, string dstDir)
        {
            try
            {
                CopyDirectory_Core(srcDir, dstDir);
                return true;
            }
            catch
            {
                return false;
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
        /// <returns>処理結果<br/>
        ///          true  - 成功<br/>
        ///          false - 失敗</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool MoveFile(string src, string dst, bool ow = false)
        {
            try
            {
                // dst がディレクトリの場合
                if (GetAttributes(dst) == E_Attributes.DIRECTORY)
                {
                    dst += @"\" + (new FileInfo(src)).Name;
                }

                File.Move(src, dst, ow);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ディレクトリを移動する
        /// </summary>
        /// <param name="src">[I]移動元ディレクトリ</param>
        /// <param name="dst">[I]移動先ディレクトリ</param>
        /// <returns>処理結果<br/>
        ///          true  - 成功<br/>
        ///          false - 失敗</returns>
        // -------+-----------------------------------------------------
        // 引数   | string src : [I]移動元ディレクトリ
        //        | string dst : [I]移動先ディレクトリ
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | Exception
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool MoveDirectory(string src, string dst)
        {
            try
            {
                Directory.Move(src, dst);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ファイル・ディレクトリを削除する
        /// </summary>
        /// <param name="path">[I]削除対象ファイル・ディレクトリ</param>
        /// <returns>処理結果<br/>
        ///          true  - 成功<br/>
        ///          false - 失敗</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool Delete(string path)
        {
            try
            {
                switch (GetAttributes(path))
                {
                    // ファイル
                    case E_Attributes.FILE:
                        File.Delete(path);
                        break;

                    // ディレクトリ
                    case E_Attributes.DIRECTORY:
                        Directory.Delete(path);
                        break;

                    default:
                        return false;
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
        /// [static] ファイル・ディレクトリのサイズ(バイト単位)を取得する
        /// </summary>
        /// <param name="path">[I]対象ファイル・ディレクトリ</param>
        /// <param name="ignoreItself">(path がディレクトリの場合)<br/>
        ///                            [I]自身の直下のファイルを無視するか<br/>
        ///                               true  - 除外する(サブディレクトリ以下のファイルのみを計上)<br/>
        ///                               false - 除外しない(自身とサブディレクトリ以下のファイルを計上)<br/>
        ///                                       (デフォルト)</param>
        /// <returns>ファイル・ディレクトリのサイズ<br/>
        ///          失敗時は C_INVALIDSIZE</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static long GetSize(string path, bool ignoreItself = false)
        {
            try
            {
                switch (GetAttributes(path))
                {
                    case E_Attributes.FILE:
                        return (new FileInfo(path)).Length;

                    case E_Attributes.DIRECTORY:
                        return GetDirectorySize_Core(new DirectoryInfo(path), ignoreItself);
                }

                return C_INVALIDSIZE;
            }
            catch
            {
                return C_INVALIDSIZE;
            }
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ファイル・ディレクトリのタイムスタンプを更新する
        /// </summary>
        /// <param name="path">[I]対象ファイル・ディレクトリ</param>
        /// <param name="dt">[I]更新後のタイムスタンプ</param>
        /// <returns>処理結果<br/>
        ///          true  - 成功<br/>
        ///          false - 失敗</returns>
        /// <remarks>作成日時・更新日時・最終アクセス日時を現在日時に設定</remarks>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool UpdateTimeStamp(string path,
                                           DateTime dt,
                                           string? pattern = null,
                                           bool recursive = false,
                                           bool ignoreItself = false)
        {
            try
            {
                // パスの属性によって切り分け
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
                        // 再帰設定なし ⇒ 自身のみ更新して抜ける
                        if (!recursive)
                        {
                            return true;
                        }
                        break;

                    // それ以外(対象不在) ⇒ 例外
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
                GetFiles_Core(path, ref list_Files, pattern, true, ignoreItself);
                // ファイルのタイムスタンプ更新
                foreach (var item in list_Files)
                {
                    UpdateFileTimeStamp_Core(item, dt);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // private メソッド (static)
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ディレクトリのサイズ(バイト単位)を取得する
        /// </summary>
        /// <param name="di">[I]対象のディレクトリ情報</param>
        /// <param name="ignoreItself">[I]自身の直下のファイルを無視するか<br/>
        ///                               true  - 除外する(サブディレクトリ以下のファイルのみを計上)<br/>
        ///                               false - 除外しない(自身とサブディレクトリ以下のファイルを計上)<br/>
        ///                                       (デフォルト)</param>
        /// <returns>ファイル・ディレクトリのサイズ<br/>
        ///          失敗時は C_INVALIDSIZE</returns>
        /// <remarks>サブディレクトリを再帰的に走査する</remarks>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        private static long GetDirectorySize_Core(DirectoryInfo di, bool ignoreItself = false)
        {
            long size = 0;     //< 返却するサイズ

            try
            {
                // (除外設定なしの場合)自身に含まれるファイルの合計サイズを加算
                if (!ignoreItself)
                {
                    foreach (FileInfo fi in di.GetFiles())
                    {
                        size += fi.Length;
                    }
                }

                // サブディレクトリの合計サイズを加算(再帰)
                foreach (DirectoryInfo di_Sub in di.GetDirectories())
                {
                    size += GetDirectorySize_Core(di_Sub);
                }
            }
            catch
            {
                throw new Exception("GetDirectorySize_Core");
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
        ///                                null の場合はすべてのファイル</param>
        /// <param name="recursive">    [I]サブフォルダを含めるか<br/>
        ///                                true  - 含める<br/>
        ///                                false - 含めない</param>
        /// <param name="ignoreItself"> [I]自身の直下のファイルを無視するか<br/>
        ///                                true  - 無視する<br/>
        ///                                false - 無視しない</param>
        /// <exception cref="Exception"></exception>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        private static void GetFiles_Core(string path,
                                          ref List<string> list_Files,
                                          string? pattern = null,
                                          bool recursive = false,
                                          bool ignoreItself = false)
        {
            // 再帰設定なし ⇒ 当該ディレクトリ以下のファイルのみをリストに追加して抜ける
            if (!recursive)
            {
                list_Files.AddRange(GetFiles_Core_ItselfOnly(path, pattern));
                return;
            }

            // 除外設定なし ⇒ 当該ディレクトリ以下のファイルをリストに追加
            if (!ignoreItself)
            {
                list_Files.AddRange(GetFiles_Core_ItselfOnly(path, pattern));
            }

            // サブディレクトリに含まれるファイルを追加(再帰)
            foreach (string dir in Directory.GetDirectories(path))
            {
                GetFiles_Core(dir, ref list_Files, pattern, true, false);
            }
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] ディレクトリに含まれるファイルの一覧を取得する<br/>
        ///          (当該ディレクトリのみ)
        /// </summary>
        /// <param name="path">[I]対象ディレクトリ</param>
        /// <param name="pattern">[I]ファイルパターン<br/>
        ///                          null の場合はすべてのファイル</param>
        /// <returns>ファイル一覧</returns>
        /// <exception cref="Exception"></exception>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        private static string[] GetFiles_Core_ItselfOnly(string path, string? pattern = null)
        {
            return String.IsNullOrEmpty(pattern) ?
                Directory.GetFiles(path) :
                Directory.GetFiles(path, pattern);
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
        /// [static] ディレクトリ構造を再帰的にコピーする
        /// </summary>
        /// <param name="srcDir">[I]コピー元ルートディレクトリ</param>
        /// <param name="dstDir">[I]コピー先ルートディレクトリ</param>
        /// <exception cref="Exception"></exception>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        private static void CopyDirectory_Core(string srcDir, string dstDir)
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
                CopyDirectory_Core(subDir_Src, subDir_Dst);
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
