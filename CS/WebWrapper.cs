// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
//
// WebWrapper
//
// [static]Web APIの使用
// 依存 : JsonFileOperate
//
// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Text.Json;
using System.IO;

namespace Util
{
    // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    // WebWrapper クラス
    // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    static class WebWrapper
    {
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public 定数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // private 定数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public メソッド (static)
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // HTTPリクエストを発行する
        // (通常のテキスト送信)
        // -------+-----------------------------------------------------
        // 引数   | string uri  : [I]リクエストURL
        // -------+-----------------------------------------------------
        // 戻り値 | string : 応答
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string PostWebRequest_WwwForm(string url)
        {
            // 応答格納用バイト列
            byte[] res;

            // WebClientクライアントを使用して送受信
            using (var wc = new WebClient())
            {
                var vals = new System.Collections.Specialized.NameValueCollection();
                vals.Add("key1", "val1");
                res = wc.UploadValues(url, vals);
            }

            return System.Text.Encoding.UTF8.GetString(res);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // HTTPリクエストを発行する
        // (application/json)
        // -------+-----------------------------------------------------
        // 引数   | string uri  : [I]リクエストURL
        //        | string json : [I]送信するJSON
        // -------+-----------------------------------------------------
        // 戻り値 | string : 応答
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string PostWebRequest_Json(string url, string json)
        {
            // HTTPリクエスト作成
            var req = WebRequest.Create(new Uri(url)) as HttpWebRequest;
            req.ContentType = "application/json";
            req.Method = "POST";

            // 要求書き込み
            using (var sw = new StreamWriter(req.GetRequestStream()))
            {
                sw.Write(json);
                sw.Flush();
                sw.Close();
            }

            // 応答読み出し
            string ret;
            var res = req.GetResponse();
            using (var sr = new StreamReader(res.GetResponseStream()))
            {
                ret = sr.ReadToEnd();
            }

            return ret;
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // HTTPリクエストを発行する
        // (application/json)
        // -------+-----------------------------------------------------
        // 引数   | T                         : dic の Value に用いる型
        //        | string uri                : [I]リクエストURL
        //        | Dictionary<string, T> dic : [I]送信するデータ
        // -------+-----------------------------------------------------
        // 戻り値 | string : 応答
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string PostWebRequest_Json<T>(string url, Dictionary<string, T> dic)
        {
            // データをJSONに変換後、送信
            string json = JsonFileOperate.ConvertDic2Json<T>(dic);
            return PostWebRequest_Json(url, json);
        }

    }
}
