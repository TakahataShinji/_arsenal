// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
//
// MySqlWrapper
//
// MySQL操作
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
    class MySqlWrapper
    {
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public関数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ダンプ(バックアップ)
        // -------------------------------------------------------------
        // 引数   | string userName : ユーザ名
        //        | string password : パスワード
        //        | string hostName : ホスト名
        //        | string dbName   : データベース名
        //        | string port     : ポート番号
        //        | string dumpFile : ダンプファイル名
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // ファイルのリダイレクト(">")はコマンドプロンプトでしか使用できないため、
        // cmd.exeにコマンド列を渡す
        // (mysqldump.exeを直接コールしない)
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Dump(string userName, 
                                string password,
                                string hostName,
                                string dbName,
                                string port,
                                string dumpFile)
        {
            // コマンド列を構成
            string procphrase = "/c mysqldump";

            // ユーザ名
            procphrase += " -u ";
            procphrase += userName;

            // パスワード
            procphrase += " -p";        // "-p"の直後にスペースを挟まない
            procphrase += password;

            // ホスト・DB名
            procphrase += " -h ";
            procphrase += hostName;
            procphrase += " ";
            procphrase += dbName;

            // (指定されている場合のみ)ポート番号を連結
            if (port != "")
            {
                procphrase += " -P ";
                procphrase += port;
            }

            // ダンプファイル名
            procphrase += " > ";
            procphrase += dumpFile;

            // コマンド発行
            // (ウィンドウを隠して起動)
            ProcessStartInfo pi = new ProcessStartInfo("cmd.exe", procphrase);
            pi.WindowStyle = ProcessWindowStyle.Hidden;
            Process p = Process.Start(pi);

            // 終了まで待機する
            p.WaitForExit();
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // リストア
        // -------------------------------------------------------------
        // 引数   | string userName : ユーザ名
        //        | string password : パスワード
        //        | string hostName : ホスト名
        //        | string dbName   : データベース名
        //        | string port     : ポート番号
        //        | string dumpFile : ダンプファイル名
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // ・ダンプファイルの有無についてのチェックは行わない
        //   呼び元でチェックを行うこと
        // ・ファイルのリダイレクト("<")はコマンドプロンプトでしか使用できないため、
        //   cmd.exeにコマンド列を渡す
        //   (mysql.exeを直接コールしない)
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Restore(string userName,
                                   string password,
                                   string hostName,
                                   string dbName,
                                   string port,
                                   string dumpFile)
        {
            // コマンド列を構成
            string procphrase = "/c mysql";

            // ユーザ名
            procphrase += " -u ";
            procphrase += userName;

            // パスワード
            procphrase += " -p";        // "-p"の直後にスペースを挟まない
            procphrase += password;

            // ホスト・DB名
            procphrase += " -h ";
            procphrase += hostName;
            procphrase += " ";
            procphrase += dbName;

            // (指定されている場合のみ)ポート番号を連結
            if (port != "")
            {
                procphrase += " -P ";
                procphrase += port;
            }

            // ダンプファイル名
            procphrase += " < ";
            procphrase += dumpFile;

            // コマンド発行
            // (ウィンドウを隠して起動)
            ProcessStartInfo pi = new ProcessStartInfo("cmd.exe", procphrase);
            pi.WindowStyle = ProcessWindowStyle.Hidden;
            Process p = Process.Start(pi);

            // 終了まで待機する
            p.WaitForExit();
        }

    }       // class MySqlWrapper
}       // namespace Util
