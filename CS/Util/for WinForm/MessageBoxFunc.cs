using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Util
{
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    /// <summary>
    /// [static]メッセージボックス処理
    /// </summary>
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    static class MessageBoxFunc
    {
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// public 定数
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // メッセージボックス処理結果(押されたボタン)
        public enum E_MsgBoxResult
        {
            E_MSGBOX_OK,            //< 押されたボタン : 「OK」
            E_MSGBOX_CANCEL,        //< 押されたボタン : 「キャンセル」
            E_MSGBOX_YES,           //< 押されたボタン : 「はい」
            E_MSGBOX_NO,            //< 押されたボタン : 「いいえ」
        };

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// private 定数
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // メッセージボックス処理結果変換テーブル
        private static Dictionary<DialogResult, E_MsgBoxResult> D_MsgBoxResult = new Dictionary<DialogResult, E_MsgBoxResult>()
        {
            { DialogResult.OK,      E_MsgBoxResult.E_MSGBOX_OK      },      //< 「OK」
            { DialogResult.Cancel,  E_MsgBoxResult.E_MSGBOX_CANCEL  },      //< 「キャンセル」
            { DialogResult.Yes,     E_MsgBoxResult.E_MSGBOX_YES     },      //< 「はい」
            { DialogResult.No,      E_MsgBoxResult.E_MSGBOX_NO      },      //< 「いいえ」
        };

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// public メソッド (static)
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static]「情報」メッセージボックス表示
        /// </summary>
        /// <param name="msg">表示するメッセージ</param>
        /// <param name="title">メッセージボックスの表題</param>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void ShowInfoMsgBox(string msg, string title = "情報")
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static]「警告」メッセージボックス表示
        /// </summary>
        /// <param name="msg">表示するメッセージ</param>
        /// <param name="title">メッセージボックスの表題</param>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void ShowWarnMsgBox(string msg, string title = "警告")
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static]「エラー」メッセージボックス表示
        /// </summary>
        /// <param name="msg">表示するメッセージ</param>
        /// <param name="title">メッセージボックスの表題</param>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void ShowErrorMsgBox(string msg, string title = "エラー")
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static]問い合わせメッセージボックス表示
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="title"></param>
        /// <returns>押されたボタン<br/>
        ///          E_MsgBoxResult.E_MSGBOX_YES - 「はい」<br/>
        ///          E_MsgBoxResult.E_MSGBOX_NO  - 「いいえ」</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static E_MsgBoxResult ShowYesNoMsgBox(string msg, string title = "確認")
        {
            // メッセージボックス表示、押されたボタンを取得
            DialogResult ret = MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            // E_MsgBoxResult に変換して返す
            return D_MsgBoxResult[ret];
        }

    }       // class MessageBoxFunc

}       // namespace Util
