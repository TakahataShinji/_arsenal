// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
//
// SlackWrapper
//
// [static]Slackへのアクセス
// 依存 : WebWrapper
//
// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Util
{
    // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    // SlackWrapper クラス
    // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    class SlackWrapper
    {
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public 定数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // 投稿者区分
        public enum E_Poster
        {
            User,
            Bot,
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // private 定数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // private プロパティ
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        private string whUrl;       //< Webhook URL

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // コンストラクタ
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public SlackWrapper(string webhookUrl)
        {
            whUrl = webhookUrl;
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public メソッド
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // チャンネルにメッセージを投稿する
        // -------+-----------------------------------------------------
        // 引数   | string message  : [I]投稿するメッセージ
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | あり
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public void PostMessage(string message)
        {
            string json = $@"{{""text"":{message}}}";
            WebWrapper.PostWebRequest_Json(whUrl, json);
        }

    }
}
