// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
//
// MessageBoxFunc
//
// メッセージボックスの表示
//
// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
using System.Windows.Forms;

namespace Util
{
    public class MessageBoxFunc
    {
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public関数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 問い合わせメッセージボックス表示
        // -------------------------------------------------------------
        // 引数   | string msg   : 表示するメッセージ
        //        | string title : タイトル(デフォルト値あり)
        // -------------------------------------------------------------
        // 戻り値 | bool - 押されたボタンの種別
        //        |        true  : はい
        //        |        false : いいえ
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool ShowPrompt(string msg, string title = "確認")
        {
            // メッセージボックスを表示
            DialogResult ret = MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // 「はい」が押された場合 true を
            // それ以外(「いいえ」)は false を返す
            return (ret == DialogResult.Yes);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 情報メッセージボックス表示
        // -------------------------------------------------------------
        // 引数   | string msg   : 表示するメッセージ
        //        | string title : タイトル(デフォルト値あり)
        // -------------------------------------------------------------
        // 戻り値 | なし
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void ShowInfoMsgBox(string msg, string title = "情報")
        {
            // メッセージボックスを表示
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 警告メッセージボックス表示
        // -------------------------------------------------------------
        // 引数   | string msg   : 表示するメッセージ
        //        | string title : タイトル(デフォルト値あり)
        // -------------------------------------------------------------
        // 戻り値 | なし
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void ShowWarnMsgBox(string msg, string title = "警告")
        {
            // メッセージボックスを表示
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // エラーメッセージボックス表示
        // -------------------------------------------------------------
        // 引数   | string msg   : 表示するメッセージ
        //        | string title : タイトル(デフォルト値あり)
        // -------------------------------------------------------------
        // 戻り値 | なし
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void ShowErrorMsgBox(string msg, string title = "エラー")
        {
            // メッセージボックスを表示
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }       // public class MessageBoxFunc

}       // namespace SiteManager
