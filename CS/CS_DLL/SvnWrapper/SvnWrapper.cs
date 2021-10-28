// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
//
// SvnWrapper
//
// SVN操作
//
// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
using System.Diagnostics;

namespace Util
{
    public class SvnWrapper
    {
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public関数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // (TortoiseSVN)更新
        // -------------------------------------------------------------
        // 引数   | string path : 対象パス
        //        | bool   wait : プロセスの終了を待機するか
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | IOException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.SystemException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void TSvn_Update(string path, bool wait = false)
        {
            ExecTSvn("update", path, wait: wait);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // (TortoiseSVN)ログダイアログを開く
        // -------------------------------------------------------------
        // 引数   | string path : 対象パス
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | IOException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.SystemException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void TSvn_ShowLog(string path)
        {
            ExecTSvn("log", path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // (TortoiseSVN)差分を表示する
        // -------------------------------------------------------------
        // 引数   | string path : 対象パス
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | IOException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.SystemException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void TSvn_CheckDiff(string path)
        {
            ExecTSvn("diff", path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // (TortoiseSVN)コミットダイアログを開く
        // -------------------------------------------------------------
        // 引数   | string path : 対象パス
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | IOException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.SystemException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void TSvn_Commit(string path)
        {
            ExecTSvn("commit", path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // (TortoiseSVN)変更の取り消し
        // -------------------------------------------------------------
        // 引数   | string path : 対象パス
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | IOException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.SystemException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void TSvn_Revert(string path)
        {
            ExecTSvn("revert", path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // (TortoiseSVN)クリーンアップ
        // -------------------------------------------------------------
        // 引数   | string path : 対象パス
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | IOException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.SystemException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void TSvn_CleanUp(string path)
        {
            ExecTSvn("cleanup", path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // (SVNコマンドライン)更新
        // -------------------------------------------------------------
        // 引数   | string path : 対象パス
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | IOException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.SystemException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Svn_Update(string path)
        {
            ExecSvn("update " + path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // (SVNコマンドライン)マージ(リビジョンの差分を反映)
        // -------------------------------------------------------------
        // 引数   | string rev_Start : 比較元リビジョン
        //        | string rev_End   : 比較先リビジョン
        //        | string path_Src  : 差分抽出元パス
        //        | string path_WC   : 差分適用先パス
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | IOException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.SystemException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Svn_Merge(string rev_Start, 
                                     string rev_End, 
                                     string path_Src, 
                                     string path_WC)
        {
            // path_Src における
            // リビジョン rev_Start から rev_End までの変更を
            // path_WC に適用する

            string command = "merge -r ";

            command += rev_Start;
            command += ":";
            command += rev_End;

            command += " ";

            command += path_Src;

            command += " ";

            command += path_WC;

            ExecSvn(command);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // (SVNコマンドライン)マージ(上書き)
        // -------------------------------------------------------------
        // 引数   | string path_Src : コピー元パス
        //        | string path_WC  : コピー先パス(作業コピー)
        //        | string rev_Src  : コピー元のリビジョン
        //        |                   (デフォルトはHEAD)
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | IOException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.SystemException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Svn_Merge_Ow(string path_Src,
                                        string path_WC, 
                                        string rev_Src="HEAD")
        {
            // path_WC の最新リビジョン(HEAD)と
            // path_Src の指定リビジョン( rev_Src )の差分を
            // path_WC に適用する
            // (=> path_Src の指定リビジョンで上書きする)

            string command = "merge ";

            command += path_WC;
            command += "@HEAD";

            command += " ";

            command += path_Src;
            command += "@";
            command += rev_Src;

            command += " ";

            command += path_WC;

            ExecSvn(command);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // (SVNコマンドライン)コピー
        // -------------------------------------------------------------
        // 引数   | string path_Src : コピー元パス
        //        | string path_Dst : コピー先パス
        //        | string comment  : コミットメッセージ
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | IOException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.SystemException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Svn_Copy(string path_Src,
                                    string path_Dst,
                                    string comment = "")
        {
            // path_Src を基に path_Dst を作成する

            string command = "copy ";

            command += " ";
            command += path_Src;

            command += " ";
            command += path_Dst;

            // コミットメッセージが指定されている場合は結合する
            if (comment != "")
            {
                command += " -m \"";
                command += comment;
                command += "\"";
            }


            ExecSvn(command);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // (SVNコマンドライン)変更の取り消し
        // -------------------------------------------------------------
        // 引数   | string path : 対象パス(ディレクトリ)
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | IOException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.SystemException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Svn_Revert_Dir(string path)
        {
            // ディレクトリに対する変更を再帰的に取り消す
            ExecSvn("revert --recursive " + path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // private関数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // TortoiseSVNコマンドを発行
        // -------------------------------------------------------------
        // 引数   | string command : コマンド
        //        | string path    : 対象パス
        //        | string options : その他のオプション
        //        | bool   wait    : プロセスの終了を待機するか
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | IOException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.SystemException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        private static void ExecTSvn(string command, string path, string options = "", bool wait = false)
        {
            // コマンド列を構成
            string procphrase = "/command:";
            procphrase += command;

            procphrase += " /path:";
            procphrase += path;

            // (指定されている場合のみ)その他のオプションを連結
            if (options != "")
            {
                procphrase += " ";
                procphrase += options;
            }

            // コマンド発行
            Process p = Process.Start("TortoiseProc.exe", procphrase);

            // 終了まで待機する
            if (wait)
            {
                p.WaitForExit();
                p.Close();
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // (コマンドライン)SVNコマンドを発行
        // -------------------------------------------------------------
        // 引数   | string command : コマンド(オプションを含む)
        // -------------------------------------------------------------
        // 戻り値 | string : コマンドの実行結果(標準出力された文字列)
        // -------------------------------------------------------------
        // 例外   | IOException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.SystemException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        private static string ExecSvn(string command)
        {
            // プロセス生成
            // (標準出力へのリダイレクトを行う)
            Process p = new Process();
            p.StartInfo.CreateNoWindow = true;              //< コンソールウィンドウ : 開かない
            p.StartInfo.RedirectStandardOutput = true;      //< 標準出力のリダイレクト : 行う
            p.StartInfo.UseShellExecute = false;            //< シェル機能 : 使用しない
            p.StartInfo.FileName = "svn.exe";
            p.StartInfo.Arguments = command;
            p.Start();

            // 標準出力を読み取る
            string output = p.StandardOutput.ReadToEnd();

            // 終了まで待機する
            p.WaitForExit();
            p.Close();

            return output;
        }

    }       // public class SvnWrapper

}       // namespace Util
