// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
//
// General
//
// その他の操作
//
// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
using System.Diagnostics;

namespace Util
{
    public class General
    {
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 定数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // Local by Flywheel のパス
        private const string cLocalByFlywheel = "C:\\Users\\iota0\\AppData\\Local\\Programs\\local-by-flywheel\\Local by Flywheel.exe";

        // iTunes のパス
        private const string cItunes = "E:\\iTunes\\iTunes.exe";

        // Music Center for PC のパス
        private const string cMusicCenter = "C:\\Program Files (x86)\\Sony\\Music Center\\MusicCenter.exe";

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public関数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // プロセスの名前を指定して強制終了
        // -------------------------------------------------------------
        // 引数   | string name : 終了するプロセス名
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | InvalidOperationException
        //        | NotSupportedException
        //        | System.ComponentModel.Win32Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void KillProcessByName(string name)
        {
            Process[] ps = Process.GetProcessesByName(name);

            foreach (Process p in ps)
            {
                // プロセスを強制終了
                p.Kill();
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // MS Excelを開く
        // -------------------------------------------------------------
        // 引数   | string path : Excelで開くファイルのパス
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | InvalidOperationException
        //        | ObjectDisposedException
        //        | PlatformNotSupportedException
        //        | System.ComponentModel.Win32Exception
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void OpenExcel(string path)
        {
            Process.Start("excel.exe", path);
        }

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

    }       // public class General

}       // namespace Util
