// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
//
// FirefoxWrapper
//
// Mozilla Firefox の操作
//
// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
using System.Diagnostics;

namespace Util
{
    public class FirefoxWrapper
    {
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 定数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // Mozilla Firefox のパス
        private const string cFirefox = "E:\\Mozilla Firefox\\firefox.exe";

        // WEBページの開き方区分(複数URL時)
        public enum OpenMethod
        {
            NEWWINDOW,  //< 新しいウィンドウで開く
            NEWTAB      //< 新しいタブで開く
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public関数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

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
        // 引数   | string[]   urls : 開く対象のURL
        //        | OpenMethod proc : 開く方法
        //        |                   OpenMethod.NEWWINDOW - 新しいウィンドウで開く
        //        |                   OpenMethod.NEWTAB    - 新しいタブで開く
        // -------------------------------------------------------------
        // 戻り値 | Process : 生成したプロセス
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static Process OpenFirefox(string[] urls, OpenMethod proc = OpenMethod.NEWWINDOW)
        {
            string options = "";

            // 指定されたURL群をシリアライズ
            foreach (string s in urls)
            {
                if (proc == OpenMethod.NEWWINDOW)
                {
                    options += "-new-window ";
                }
                else if (proc == OpenMethod.NEWTAB)
                {
                    options += "-new-tab ";
                }

                options += s;
                options += " ";
            }

            // コマンド発行
            return OpenFirefox(options);
        }

    }       // public class FirefoxWrapper

}       // namespace Util
