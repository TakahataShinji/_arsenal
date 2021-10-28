// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
//
// HerokuWrapper
//
// Heroku操作
//
// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
using System.Diagnostics;

namespace Util
{
    public class HerokuWrapper
    {
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 定数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // Heroku CLI 実行ファイルのパス
        private const string cHerokuCliPath = "E:\\Heroku\\bin\\heroku.cmd";

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public関数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // アプリケーション作成
        // -------------------------------------------------------------
        // 引数   | string appName : アプリケーション名
        //        | string option  : オプション
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
        public static void Heroku_Create(string appName, string option ="")
        {
            string command =  "create ";
                   command += appName;

            // オプションが指定されている場合はコマンド列に追記
            if (option != "")
            {
                command += " ";
                command += option;
            }

            // Herokuコマンド発行
            ExecHeroku(command);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // アプリケーション作成(標準PHP使用)
        // -------------------------------------------------------------
        // 引数   | string appName : アプリケーション名
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
        // ビルドパックとしてHeroku標準PHP(heroku/php)を使用
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Heroku_Create_Php(string appName)
        {
            // アプリケーション作成
            Heroku_Create(appName, "-s cedar -b heroku/php");
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // アドオンの追加
        // -------------------------------------------------------------
        // 引数   | string appName   : 追加先のアプリケーション名
        //        | string addonName : 追加するアドオン名
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
        public static void Heroku_Addons_Add(string appName, string addonName)
        {
            string command = "addons:add ";
            command += addonName;
            command += " -a ";
            command += appName;

            // Herokuコマンド発行
            ExecHeroku(command);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ClearDB(MySQL)アドオンの追加
        // -------------------------------------------------------------
        // 引数   | string appName : 追加先のアプリケーション名
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
        // プランは ignite を指定
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Heroku_Addons_Add_ClearDb(string appName)
        {
            // アドオン追加
            Heroku_Addons_Add(appName, "cleardb:ignite");
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // コンフィグ値の取得
        // -------------------------------------------------------------
        // 引数   | string appName : 対象のアプリケーション
        //        | string key     : 取得対象キー
        // -------------------------------------------------------------
        // 戻り値 | string : 取得したコンフィグ値
        // -------------------------------------------------------------
        // 例外   | IOException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.SystemException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string Heroku_Config_Get(string appName, string key)
        {
            string command = "config:get ";
                   command += key;
                   command += " -a ";
                   command += appName;

            // Herokuコマンド発行
            return ExecHeroku(command);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // コンフィグ値の追加
        // -------------------------------------------------------------
        // 引数   | string appName : 対象のアプリケーション
        //        | string key     : 追加対象キー
        //        | string val     : 設定値
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
        public static void Heroku_Config_Add(string appName, string key, string val)
        {
            string command = "config:add ";
                   command += key;
                   command += "=";
                   command += val;
                   command += " -a ";
                   command += appName;

            // Herokuコマンド発行
            ExecHeroku(command);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // (ClearDB MySQL)データベースURLの取得
        // -------------------------------------------------------------
        // 引数   | string appName   : 対象のアプリケーション
        // -------------------------------------------------------------
        // 例外   | IOException
        //        | System.ComponentModel.Win32Exception
        //        | System.InvalidOperationException
        //        | System.ObjectDisposedException
        //        | System.OutOfMemoryException
        //        | System.SystemException
        // -------------------------------------------------------------
        // 戻り値 | string : CLEARDB_DATABASE_URL の値
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string Heroku_Config_Get_ClearDb_Url(string appName)
        {
            // コンフィグ値の取得
            return Heroku_Config_Get(appName, "CLEARDB_DATABASE_URL");
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // データベースURLの追加
        // -------------------------------------------------------------
        // 引数   | string appName : 対象のアプリケーション
        //        | string val     : DATABASE_URL に設定する値
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
        public static void Heroku_Config_Add_Db_Url(string appName, string val)
        {
            // コンフィグ値の追加
            Heroku_Config_Add(appName, "DATABASE_URL", val);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // HerokuアプリケーションをGitリモートリポジトリに指定
        // -------------------------------------------------------------
        // 引数   | string appName : 対象のアプリケーション
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
        // Git Initを実行済み( = デプロイ元)のディレクトリ上でコールすること
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Heroku_Git_Remote(string appName)
        {
            string command = "git:remote -a ";
                   command += appName;

            // Herokuコマンド発行
            ExecHeroku(command);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // private関数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // Heroku(Heroku CLI)コマンドを発行
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
        private static string ExecHeroku(string command)
        {
            // プロセス生成
            // (標準出力へのリダイレクトを行う)
            Process p = new Process();
            p.StartInfo.CreateNoWindow = true;              //< コンソールウィンドウ : 開かない
            p.StartInfo.RedirectStandardOutput = true;      //< 標準出力のリダイレクト : 行う
            p.StartInfo.UseShellExecute = false;            //< シェル機能 : 使用しない
            p.StartInfo.FileName = cHerokuCliPath;
            p.StartInfo.Arguments = command;
            p.Start();

            // 標準出力を読み取る
            string output = p.StandardOutput.ReadToEnd();

            // 終了まで待機する
            p.WaitForExit();
            p.Close();

            return output;
        }

    }       // public class HerokuWrapper

}       // namespace Util
