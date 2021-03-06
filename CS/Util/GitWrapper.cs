// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
//
// GitWrapper
//
// Git操作
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
    class GitWrapper
    {
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public メソッド
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ローカルリポジトリ作成(init)
        // -------------------------------------------------------------
        // 引数   | string path : [I]対象パス
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // カレントディレクトリを対象とする場合、引数無しでコールすること
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Git_Init(string path = "")
        {
            string command = "init";

            // パスが指定されている場合のみ、コマンド列に追記
            if (path != "")
            {
                command += " " + path;
            }

            // Gitコマンド発行
            ExecGit(command);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイルをステージング(管理下におく)(add)
        // -------------------------------------------------------------
        // 引数   | なし
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // カレントディレクトリの全ファイルを対象とする
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Git_Add()
        {
            // Gitコマンド発行
            ExecGit("add -A");
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ファイルをステージング(管理下におく)(add)(対象指定)
        // -------------------------------------------------------------
        // 引数   | string[] files : [I]対象とするファイル
        // -------------------------------------------------------------
        // 戻り値 | なし
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
        // コミット(commit)
        // -------------------------------------------------------------
        // 引数   | string comment : [I]コミットメッセージ
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // カレントディレクトリを対象とする
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Git_Commit(string comment = "")
        {
            string command = "commit -am ";

            command += "\"";
            command += (comment == "") ? "default message" : comment;
            command += "\"";

            // Gitコマンド発行
            ExecGit(command);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // プッシュ(push)
        // -------------------------------------------------------------
        // 引数   | string rep    : [I]プッシュする対象のリモートリポジトリ
        //        | string branch : [I]プッシュする対象のブランチ
        // -------------------------------------------------------------
        // 戻り値 | なし
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
        // コミット対象のファイル一覧を取得する
        // -------------------------------------------------------------
        // 引数   | bool ConvertDelimitter : [I]パス区切り文字を変換するか
        //        |                             ("/" ⇒ "\")
        //        |                             true  - 変換する(デフォルト)
        //        |                             false - 変換しない
        // -------------------------------------------------------------
        // 戻り値 | string[] : ファイル一覧
        // -------------------------------------------------------------
        // カレントディレクトリを対象とする
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string[] Git_FilesToBeCommited(bool convertPathDelimitter = true)
        {
            // Gitコマンド発行
            string command = "diff HEAD --name-only";
            string result = ExecGit(command);

            // パス区切り文字の変換("/" ⇒ "\")
            if (convertPathDelimitter)
            {
                result = result.Replace("/", "\\");
            }

            // 改行で各要素に分解
            List<string> temp = new List<string>(result.Split('\n'));

            // 空要素を除去
            temp.Remove("");
            return temp.ToArray();
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // private メソッド
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // Gitコマンドを発行
        // -------------------------------------------------------------
        // 引数   | string command : [I]コマンド(オプションを含む)
        // -------------------------------------------------------------
        // 戻り値 | string : コマンドの実行結果(標準出力された文字列)
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        private static string ExecGit(string command)
        {
            // プロセス生成
            var sInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,                      //< コンソールウィンドウ : 開かない
                RedirectStandardOutput = true,              //< 標準出力のリダイレクト : 行う
                UseShellExecute = false,                    //< シェル機能 : 使用しない
                StandardOutputEncoding = Encoding.UTF8,     //< 標準出力のエンコーディング : UTF-8
                FileName = "git.exe",
                Arguments = command,
            };

            using (var p = Process.Start(sInfo))
            {
                if (p == null)
                {
                    return String.Empty;
                }

                // 標準出力を読み取る
                string output = p.StandardOutput.ReadToEnd();

                // 終了まで待機する
                p.WaitForExit();
                p.Close();

                return output;
            }
        }

    }       // class GitWrapper
}       // namespace Util
