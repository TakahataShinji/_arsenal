// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
//
// OthersWrapper
//
// その他の外部プログラム操作
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
    class OthersWrapper
    {
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 定数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        private const string cLocalByFlywheel = "C:\\Users\\iota0\\AppData\\Local\\Programs\\local-by-flywheel\\Local by Flywheel.exe";
            //< Local by Flywheel のパス

        private const string cMySqlWorkbench = "E:\\MySQL\\MySQL Workbench 6.3 CE\\MySQLWorkbench.exe";
            //< MySQL Workbench のパス

        private const string cFirefox = "E:\\Mozilla Firefox\\firefox.exe";
            //< Firefox のパス

        // WEBブラウザの開き方区分(複数URL時)
        public const int NEWWINDOW = 0; //< 新しいウィンドウで開く
        public const int NEWTAB    = 1; //< 新しいタブで開く

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public関数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // Local by Flywheelを開く
        // -------------------------------------------------------------
        // 引数   | なし
        // -------------------------------------------------------------
        // 戻り値 | Process : 生成したプロセス
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static Process OpenLocalByFlywheel()
        {
            // コマンド発行
            return Process.Start(cLocalByFlywheel);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // MySQL Workbenchを開く
        // -------------------------------------------------------------
        // 引数   | なし
        // -------------------------------------------------------------
        // 戻り値 | Process : 生成したプロセス
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static Process OpenMySqlWorkbench()
        {
            // コマンド発行
            return Process.Start(cMySqlWorkbench);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // Mozilla Firefoxを開く
        // -------------------------------------------------------------
        // 引数   | string url : 開く対象のURL
        // -------------------------------------------------------------
        // 戻り値 | Process : 生成したプロセス
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static Process OpenFirefox(string url)
        {
            // コマンド発行
            return Process.Start(cFirefox, url);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // Mozilla Firefoxを開く(複数URL指定)
        // -------------------------------------------------------------
        // 引数   | string[] urls : 開く対象のURL
        //        | int      proc : 開く方法
        //        |                 NEWWINDOW
        // -------------------------------------------------------------
        // 戻り値 | Process : 生成したプロセス
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static Process OpenFirefox(string[] urls, int proc = NEWWINDOW)
        {
            string options = "";

            for (int i=0; i<urls.Length; i++)
            {
                if (proc == NEWWINDOW)
                {
                    options += "-new-window ";
                }
                else if (proc == NEWTAB)
                {
                    options += "-new-tab ";
                }

                options += urls[i];
                options += " ";
            }

            // コマンド発行
            return OpenFirefox(options);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // エクスプローラを開く
        // -------------------------------------------------------------
        // 引数   | string path : 対象のフォルダパス
        // -------------------------------------------------------------
        // 戻り値 | なし
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void OpenExplorer(string path)
        {
            Process.Start("explorer.exe", path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // コマンドプロンプトを開く
        // -------------------------------------------------------------
        // 引数   | string path : 初期パス
        // -------------------------------------------------------------
        // 戻り値 | なし
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void OpenCmd(string path)
        {
            Process.Start("cmd.exe", "/k cd " + path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // Excelを開く
        // -------------------------------------------------------------
        // 引数   | string path : 対象のフォルダパス
        // -------------------------------------------------------------
        // 戻り値 | なし
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void OpenExcel(string path)
        {
            Process.Start("excel.exe", path);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // プロセスの名前を指定して強制終了
        // -------------------------------------------------------------
        // 引数   | string name : 終了するプロセス名
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 中身のあるフォルダも強制的に削除する
        // (サブフォルダ、およびファイルを再帰的に削除)
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void KillProcessByName(string name)
        {
            // 対象のフォルダが存在する場合のみ削除
            Process[] ps = Process.GetProcessesByName(name);

            foreach (Process p in ps)
            {
                // プロセスを強制終了
                p.Kill();
            }
        }

    }       // class OthersWrapper

}       // namespace Util
