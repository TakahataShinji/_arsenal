// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
//
// Json_Xml_FileOperate
//
// [static]JSON / XMLファイルの操作
//
// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Text;
using System.Xml;

namespace Util
{
    // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    // Json_Xml_FileOperate クラス
    // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    static class Json_Xml_FileOperate
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
        //DictionaryをJSONに変換する
        // -------+-----------------------------------------------------
        // 引数   | T                         : dic の Value に用いる型
        //        | Dictionary<string, T> dic : [I]元データ
        // -------+-----------------------------------------------------
        // 戻り値 | string : 変換結果(JSON)
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string ConvertDicToJson<T>(Dictionary<string, T> dic)
        {
            // dic をJSONに変換(シリアライズ)
            return JsonSerializer.Serialize(dic);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // JSONをDictionaryに変換する
        // -------+-----------------------------------------------------
        // 引数   | T           :Dictionaryの Value として用いる型
        //        | string json : [I]元データ
        // -------+-----------------------------------------------------
        // 戻り値 | Dictionary<string, T> : 変換結果(Dictionary)
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static Dictionary<string, T> ConvertJsonToDic<T>(string json)
        {
            // JSONをDictionaryに変換(デシリアライズ)
            return JsonSerializer.Deserialize<Dictionary<string, T>>(json);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // オブジェクトをJSONに変換する
        // -------+-----------------------------------------------------
        // 引数   | T target : [I]元データ
        // -------+-----------------------------------------------------
        // 戻り値 | string : 変換結果(JSON)
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string ConvertObjToJson<T>(T target)
        {
            // オブジェクトをJSONに変換(シリアライズ)
            return JsonSerializer.Serialize<T>(target);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // JSONをオブジェクトに変換する
        // -------+-----------------------------------------------------
        // 引数   | string json : [I]元データ
        // -------+-----------------------------------------------------
        // 戻り値 | T : 変換結果
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static T ConvertJsonToObj<T>(string json)
        {
            // JSONをオブジェクトに変換(デシリアライズ)
            return JsonSerializer.Deserialize<T>(json);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // JSONファイルをDictionaryに読み込む
        // -------+-----------------------------------------------------
        // 引数   | T               : Dictionaryの Value として用いる型
        //        | string fileName : [I]読み込むファイル
        // -------+-----------------------------------------------------
        // 戻り値 | Dictionary<string, T> : 変換結果(Dictionary)
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static Dictionary<string, T> LoadDicFromJsonFile<T>(string fileName)
        {
            // 読み込み用ストリーム生成
            using (var sr = new StreamReader(fileName, new UTF8Encoding(false)))
            {
                // ファイルを末尾まで読み込み
                // ストリームを閉じる
                string json = sr.ReadToEnd();
                sr.Close();

                // JSONをDictionaryに変換(デシリアライズ)
                return JsonSerializer.Deserialize<Dictionary<string, T>>(json);
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        //DictionaryをJSONファイルに保存する
        // -------+-----------------------------------------------------
        // 引数   | T                         : dic の Value に用いる型
        //        | string fileName           : [I]保存先ファイル
        //        | Dictionary<string, T> dic : [I]元データ
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void SaveDicToJsonFile<T>(string fileName, Dictionary<string, T> dic)
        {
            // 書き込み用ストリーム生成
            // 上書きモード
            using (var sw = new StreamWriter(fileName, false, new UTF8Encoding(false)))
            {
                // dic をJSONに変換(シリアライズ)して書き込み
                // ストリームを閉じる
                sw.Write(JsonSerializer.Serialize(dic));
                sw.Close();
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // JSONファイルからオブジェクトを読み込む
        // -------+-----------------------------------------------------
        // 引数   | string fileName : [I]読み込むファイル
        // -------+-----------------------------------------------------
        // 戻り値 | T : 変換結果
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static T LoadObjFromJsonFile<T>(string fileName)
        {
            // 読み込み用ストリーム生成
            using (var sr = new StreamReader(fileName, new UTF8Encoding(false)))
            {
                // ファイルを末尾まで読み込み
                // ストリームを閉じる
                string json = sr.ReadToEnd();
                sr.Close();

                // JSONをオブジェクトに変換(デシリアライズ)
                return JsonSerializer.Deserialize<T>(json);
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // オブジェクトをJSONファイルに保存する
        // -------+-----------------------------------------------------
        // 引数   | string fileName : [I]保存先ファイル
        //        | T      target   : [I]元データ
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void SaveObjToJsonFile<T>(string fileName, T target)
        {
            // 書き込み用ストリーム生成
            // 上書きモード
            using (var sw = new StreamWriter(fileName, false, new UTF8Encoding(false)))
            {
                // target をJSONに変換(シリアライズ)して書き込み
                // ストリームを閉じる
                sw.Write(JsonSerializer.Serialize<T>(target));
                sw.Close();
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // XMLから保存値(オブジェクト)を読み込む(デシリアライズ)
        // -------+-----------------------------------------------------
        // 引数   | String fileName : [I]読み込むファイル名
        // -------+-----------------------------------------------------
        // 戻り値 | T : 読みだした保存値
        // -------+-----------------------------------------------------
        // 例外   | 
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static T LoadObjFromXml<T>(String fileName)
        {
            // シリアライザ生成
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            // 読み込み用ストリーム生成
            using (var sr = new StreamReader(fileName, new UTF8Encoding(false)))
            {
                // デシリアライズ実行、ストリームを閉じる
                T ret = (T)serializer.Deserialize(sr);
                sr.Close();
                return ret;
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // XMLに値(オブジェクト)を保存する(シリアライズ)
        // -------+-----------------------------------------------------
        // 引数   | String fileName : [I]書き込むファイル名
        //        | T      target   : [I]書き込む対象のオブジェクト
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | 
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void SaveObjToXml<T>(String fileName, T target)
        {
            // シリアライザ生成
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            // 書き込み用ストリーム生成
            // 上書きモード
            using (var sw = new StreamWriter(fileName, false, new UTF8Encoding(false)))
            {
                // シリアライズ実行(保存)、ストリームを閉じる
                serializer.Serialize(sw, target);
                sw.Close();
            }
        }

    }
}
