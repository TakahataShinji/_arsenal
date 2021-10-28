// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
//
// MessageBoxFunc
//
// [static]メッセージボックス処理
//
// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Util
{
    static class MessageBoxFunc
    {
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 定数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // メッセージボックス処理結果(押されたボタン)
        public enum E_MsgBoxResult
        {
            E_MSGBOX_OK,            //< 押されたボタン : 「OK」
            E_MSGBOX_CANCEL,        //< 押されたボタン : 「キャンセル」
            E_MSGBOX_YES,           //< 押されたボタン : 「はい」
            E_MSGBOX_NO,            //< 押されたボタン : 「いいえ」
        };

        // DialogResult と E_MsgBoxResult の変換辞書
        private static Dictionary<DialogResult, E_MsgBoxResult> D_MsgBoxResult = new Dictionary<DialogResult, E_MsgBoxResult>()
        {
            { DialogResult.OK,      E_MsgBoxResult.E_MSGBOX_OK      },      //< 「OK」
            { DialogResult.Cancel,  E_MsgBoxResult.E_MSGBOX_CANCEL  },      //< 「キャンセル」
            { DialogResult.Yes,     E_MsgBoxResult.E_MSGBOX_YES     },      //< 「はい」
            { DialogResult.No,      E_MsgBoxResult.E_MSGBOX_NO      },      //< 「いいえ」
        };

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public メソッド (static)
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 「情報」メッセージボックス表示
        // -------+-----------------------------------------------------
        // 引数   | String msg   : 表示するメッセ―ジ
        //        | String title : メッセージボックスの表題
        //        |                デフォルト - "情報"
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 「情報」アイコン、「OK」ボタンを表示
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void ShowInfoMsgBox(String msg, String title = "情報")
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 「警告」メッセージボックス表示
        // -------+-----------------------------------------------------
        // 引数   | String msg   : 表示するメッセ―ジ
        //        | String title : メッセージボックスの表題
        //        |                デフォルト - "警告"
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 「警告」アイコン、「OK」ボタンを表示
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void ShowWarnMsgBox(String msg, String title = "警告")
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 「エラー」メッセージボックス表示
        // -------+-----------------------------------------------------
        // 引数   | String msg   : 表示するメッセ―ジ
        //        | String title : メッセージボックスの表題
        //        |                デフォルト - "警告"
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 「エラー」アイコン、「OK」ボタンを表示
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void ShowErrorMsgBox(String msg, String title = "エラー")
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 問い合わせメッセージボックス表示
        // -------+-----------------------------------------------------
        // 引数   | String msg   : 表示するメッセ―ジ
        //        | String title : メッセージボックスの表題
        //        |                デフォルト - "確認"
        // -------+-----------------------------------------------------
        // 戻り値 | E_MsgBoxResult : 押されたボタン
        //        |                  E_MSGBOX_YES - 「はい」
        //        |                  E_MSGBOX_NO  - 「いいえ」
        // -------+-----------------------------------------------------
        // 「情報」アイコン、「はい」、「いいえ」ボタンを表示
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static E_MsgBoxResult ShowYesNoMsgBox(String msg, String title = "確認")
        {
            // メッセージボックス表示、押されたボタンを取得
            DialogResult ret = MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            // E_MsgBoxResult に変換して返す
            return D_MsgBoxResult[ret];
        }

    }       // class MessageBoxFunc

}       // namespace Util
