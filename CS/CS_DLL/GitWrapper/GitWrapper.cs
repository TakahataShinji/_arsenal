// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
//
// GitWrapper
//
// Git操作
//
// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
using System.IO;
using System.Diagnostics;

namespace Util
{
    public class GitWrapper
    {
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public関数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ローカルリポジトリ作成(init)
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
        // -------------------------------------------------------------
        // カレントディレクトリを対象とする
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Git_Init()
        {
            // Gitコマンド発行
            ExecGit("init");
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ローカルリポジトリ作成(init)(フォルダ指定)
        // -------------------------------------------------------------
        // 引数   | string path : 対象パス
        // -------------------------------------------------------------
        // 例外   | IOException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.SystemException
        // -------------------------------------------------------------
        // 戻り値 | なし
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Git_Init(string path)
        {
            // Gitコマンド発行
            ExecGit("init " + path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイルをステージング(管理下におく)(add)(全ファイル)
        // -------------------------------------------------------------
        // 引数   | なし
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | IOException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.SystemException
        // -------------------------------------------------------------
        // カレントディレクトリを対象とする
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Git_Add()
        {
            // Gitコマンド発行
            ExecGit("add -A");
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイルをステージング(管理下におく)(add)(対象指定)
        // -------------------------------------------------------------
        // 引数   | string file : 対象とするファイル
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | IOException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.SystemException
        // -------------------------------------------------------------
        // カレントディレクトリを対象とする
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Git_Add(string file)
        {
            // Gitコマンド発行
            ExecGit("add " + file);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイルをステージング(管理下におく)(add)(対象指定・複数)
        // -------------------------------------------------------------
        // 引数   | string[] files : 対象とするファイル
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | IOException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.SystemException
        // -------------------------------------------------------------
        // カレントディレクトリを対象とする
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Git_Add(string[] files)
        {
            string command = "add";

            // 指定されたファイル群をシリアライズ
            foreach(string s in files)
            {
                command += " " + s;
            }

            // Gitコマンド発行
            ExecGit(command);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイルをステージング(管理下におく)(add)(フォルダ指定・全ファイル)
        // -------------------------------------------------------------
        // 引数   | string path : 対象のフォルダ
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | DirectoryNotFoundException
        //        | FileNotFoundException
        //        | IOException
        //        | PathTooLongException
        //        | System.ArgumentException
        //        | System.ArgumentNullException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.NotSupportedException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.Security.SecurityException
        //        | System.SystemException
        //        | System.UnauthorizedAccessException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Git_Add_Sd(string path)
        {
            // Gitコマンド発行
            ExecGit("add -A", path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイルをステージング(管理下におく)(add)(フォルダ指定・ファイル指定)
        // -------------------------------------------------------------
        // 引数   | string file : 対象とするファイル
        //        | string path : 対象のフォルダ
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | DirectoryNotFoundException
        //        | FileNotFoundException
        //        | IOException
        //        | PathTooLongException
        //        | System.ArgumentException
        //        | System.ArgumentNullException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.NotSupportedException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.Security.SecurityException
        //        | System.SystemException
        //        | System.UnauthorizedAccessException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Git_Add_Sd(string path, string file)
        {
            // Gitコマンド発行
            ExecGit("add " + file, path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイルをステージング(管理下におく)(add)(フォルダ指定・複数ファイル指定)
        // -------------------------------------------------------------
        // 引数   | string[] files : 対象とするファイル
        //        | string path    : 対象のフォルダ
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | DirectoryNotFoundException
        //        | FileNotFoundException
        //        | IOException
        //        | PathTooLongException
        //        | System.ArgumentException
        //        | System.ArgumentNullException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.NotSupportedException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.Security.SecurityException
        //        | System.SystemException
        //        | System.UnauthorizedAccessException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Git_Add_Sd(string path, string[] files)
        {
            string command = "add";

            // 指定されたファイル群をシリアライズ
            foreach (string s in files)
            {
                command += " " + s;
            }

            // Gitコマンド発行
            ExecGit(command, path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // コミット(commit)
        // -------------------------------------------------------------
        // 引数   | string comment : コミットメッセージ
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | IOException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.SystemException
        // -------------------------------------------------------------
        // カレントディレクトリを対象とする
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Git_Commit(string comment = "default message")
        {
            string command = "commit -am ";

            command += "\"";
            command += comment;
            command += "\"";

            // Gitコマンド発行
            ExecGit(command);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // コミット(commit)(フォルダ指定)
        // -------------------------------------------------------------
        // 引数   | string path    : 対象のフォルダ
        //        | string comment : コミットメッセージ
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | DirectoryNotFoundException
        //        | FileNotFoundException
        //        | IOException
        //        | PathTooLongException
        //        | System.ArgumentException
        //        | System.ArgumentNullException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.NotSupportedException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.Security.SecurityException
        //        | System.SystemException
        //        | System.UnauthorizedAccessException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Git_Commit_Sd(string path, string comment = "default message")
        {
            string command = "commit -am ";

            command += "\"";
            command += comment;
            command += "\"";

            // Gitコマンド発行
            ExecGit(command, path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // プッシュ(push)
        // -------------------------------------------------------------
        // 引数   | string rep    : プッシュする対象のリモートリポジトリ
        //        | string branch : プッシュする対象のブランチ
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | IOException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.SystemException
        // -------------------------------------------------------------
        // カレントディレクトリを対象とする
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Git_Push(string rep, string branch)
        {
            string command = "push ";

            command += rep;
            command += " ";
            command += branch;

            // Gitコマンド発行
            ExecGit(command);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // プッシュ(push)(フォルダ指定)
        // -------------------------------------------------------------
        // 引数   | string rep    : プッシュする対象のリモートリポジトリ
        //        | string branch : プッシュする対象のブランチ
        //        | string path   : 対象のフォルダ
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | DirectoryNotFoundException
        //        | FileNotFoundException
        //        | IOException
        //        | PathTooLongException
        //        | System.ArgumentException
        //        | System.ArgumentNullException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.NotSupportedException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.Security.SecurityException
        //        | System.SystemException
        //        | System.UnauthorizedAccessException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Git_Push(string rep, string branch, string path)
        {
            string command = "push ";

            command += rep;
            command += " ";
            command += branch;

            // Gitコマンド発行
            ExecGit(command, path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // Herokuにプッシュ(デプロイ)
        // -------------------------------------------------------------
        // 引数   | なし
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | IOException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.SystemException
        // -------------------------------------------------------------
        // カレントディレクトリを対象とする
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Git_Push_Heroku()
        {
            // Gitコマンド発行
            Git_Push("heroku", "master");
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // Herokuにプッシュ(デプロイ)(フォルダ指定)
        // -------------------------------------------------------------
        // 引数   | string path : 対象のフォルダ
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | DirectoryNotFoundException
        //        | FileNotFoundException
        //        | IOException
        //        | PathTooLongException
        //        | System.ArgumentException
        //        | System.ArgumentNullException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.NotSupportedException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.Security.SecurityException
        //        | System.SystemException
        //        | System.UnauthorizedAccessException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Git_Push_Heroku(string path)
        {
            // Gitコマンド発行
            Git_Push("heroku", "master", path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // private関数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // Gitコマンドを発行
        // -------------------------------------------------------------
        // 引数   | string command : コマンド(オプションを含む)
        //        | string path    : 対象のフォルダ
        // -------------------------------------------------------------
        // 戻り値 | string : コマンドの実行結果(標準出力された文字列)
        // -------------------------------------------------------------
        // 例外   | IOException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.SystemException
        // -------------------------------------------------------------
        // カレントディレクトリを対象とする
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        private static string ExecGit(string command)
        {
            // プロセス生成
            // (標準出力へのリダイレクトを行う)
            Process p = new Process();
            p.StartInfo.CreateNoWindow = true;              //< コンソールウィンドウ : 開かない
            p.StartInfo.RedirectStandardOutput = true;      //< 標準出力のリダイレクト : 行う
            p.StartInfo.UseShellExecute = false;            //< シェル機能 : 使用しない
            p.StartInfo.FileName = "git.exe";
            p.StartInfo.Arguments = command;
            p.Start();

            // 標準出力を読み取る
            string output = p.StandardOutput.ReadToEnd();

            // 終了まで待機する
            p.WaitForExit();
            p.Close();

            return output;
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // Gitコマンドを発行(フォルダ指定)
        // -------------------------------------------------------------
        // 引数   | string command : コマンド(オプションを含む)
        //        | string path    : 対象のフォルダ
        // -------------------------------------------------------------
        // 戻り値 | string : コマンドの実行結果(標準出力された文字列)
        // -------------------------------------------------------------
        // 例外   | DirectoryNotFoundException
        //        | FileNotFoundException
        //        | IOException
        //        | PathTooLongException
        //        | System.ArgumentException
        //        | System.ArgumentNullException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.NotSupportedException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.Security.SecurityException
        //        | System.SystemException
        //        | System.UnauthorizedAccessException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        private static string ExecGit(string command, string path)
        {
            // (終了後に復帰するため)現在のカレントディレクトリを取得
            string currentDir = Directory.GetCurrentDirectory();

            // カレントディレクトリを変更
            Directory.SetCurrentDirectory(path);

            // Git処理実行
            string output = ExecGit(command);

            // カレントディレクトリを元に戻す
            Directory.SetCurrentDirectory(currentDir);

            return output;
        }

    }       // public class GitWrapper

}       // namespace Util
