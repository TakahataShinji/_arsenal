// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
//
// HerokuWrapper
//
// Heroku操作
//
// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Util
{
    class HerokuWrapper
    {
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public関数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // アプリケーション作成
        // -------------------------------------------------------------
        // 引数   | string appName : 対象パス
        //        | string option  : オプション
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // ビルドパックとしてHeroku標準PHP(heroku/php)を使用
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
        // 引数   | string appName : 対象パス
        // -------------------------------------------------------------
        // 戻り値 | なし
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
        // 引数   | string appName   : 対象のアプリケーション
        //        | string addonName : 追加するアドオン名
        // -------------------------------------------------------------
        // 戻り値 | なし
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
        // ClearDBアドオンの追加
        // -------------------------------------------------------------
        // 引数   | string appName   : 対象のアプリケーション
        // -------------------------------------------------------------
        // 戻り値 | なし
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
        //        | string val     : キーの値
        // -------------------------------------------------------------
        // 戻り値 | なし
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
        // (ClearDB)データベースURLの取得
        // -------------------------------------------------------------
        // 引数   | string appName   : 対象のアプリケーション
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
        // Heroku(Heroku CLI)コマンドを発行
        // -------------------------------------------------------------
        // 引数   | string command : コマンド(オプションを含む)
        // -------------------------------------------------------------
        // 戻り値 | string : コマンドの実行結果(標準出力された文字列)
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        private static string ExecHeroku(string command)
        {
            // プロセス生成
            // (標準出力へのリダイレクトを行う)
            Process p = new Process();
            p.StartInfo.CreateNoWindow = true;              //< コンソールウィンドウ : 開かない
            p.StartInfo.RedirectStandardOutput = true;      //< 標準出力のリダイレクト : 行う
            p.StartInfo.UseShellExecute = false;            //< シェル機能 : 使用しない
            p.StartInfo.FileName = "E:\\Heroku\\bin\\heroku.cmd";
            p.StartInfo.Arguments = command;
            p.Start();

            // 標準出力を読み取る
            string output = p.StandardOutput.ReadToEnd();

            // 終了まで待機する
            p.WaitForExit();
            p.Close();

            return output;
        }
        
    }       // class SvnWrapper
}       // namespace Util
