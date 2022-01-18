using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Text;
using System.Xml;

namespace Util
{
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    /// <summary>
    /// [static] JSON / XMLファイルの操作
    /// </summary>
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    static class Json_Xml_FileOperate
    {
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// public メソッド (static)
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// Object <=> JSON
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>[static] JSONをオブジェクトに変換する</summary>
        /// <typeparam name="T">戻り値の型</typeparam>
        /// <param name="json">[I]元データ</param>
        /// <returns>変換結果(オブジェクト)<br/>
        ///          失敗時は default(T)</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static T? ConvertJsonToObj<T>(string json)
        {
            try
            {
                // JSONをオブジェクトに変換(デシリアライズ)
                return JsonSerializer.Deserialize<T>(json);
            }
            // 例外発生時は T のデフォルト値を返す
            catch
            {
                return default(T);
            }
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>[static] オブジェクトをJSONに変換する</summary>
        /// <typeparam name="T">元データの型</typeparam>
        /// <param name="target">[I]元データ</param>
        /// <returns>変換結果(JSON)<br/>
        ///          失敗時は null</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string? ConvertObjToJson<T>(T target)
        {
            try
            {
                // オブジェクトをJSONに変換(シリアライズ)
                return JsonSerializer.Serialize<T>(target);
            }
            // 例外発生時は null を返す
            catch
            {
                return null;
            }
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>[static] JSONファイルからオブジェクトを読み込む</summary>
        /// <typeparam name="T">戻り値の型</typeparam>
        /// <param name="fileName">[I]読み込むファイル</param>
        /// <returns>読み込み結果(オブジェクト)<br/>
        ///          失敗時は default(T)</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static T? LoadObjFromJsonFile<T>(string fileName)
        {
            try
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
            // 例外発生時は T のデフォルト値を返す
            catch
            {
                return default(T);
            }
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>[static] オブジェクトをJSONファイルに保存する</summary>
        /// <typeparam name="T">元データの型</typeparam>
        /// <param name="fileName">[I]保存先ファイル名</param>
        /// <param name="target">[I]元データ</param>
        /// <returns>処理結果<br/>
        ///          true  - 成功<br/>
        ///          false - 失敗</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool SaveObjToJsonFile<T>(string fileName, T target)
        {
            try
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

                return true;
            }
            // 例外発生時は false を返す
            catch
            {
                return false;
            }
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// Dictionary <=> JSON
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>[static] JSONをDictionaryに変換する</summary>
        /// <typeparam name="T">Dictionaryの値の型</typeparam>
        /// <param name="json">[I]元データ</param>
        /// <returns>変換結果(Dictionary)<br/>
        ///          失敗時は null</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static Dictionary<string, T>? ConvertJsonToDic<T>(string json)
        {
            return ConvertJsonToObj<Dictionary<string, T>>(json);
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>[static] DictionaryをJSONに変換する</summary>
        /// <typeparam name="T">Dictionaryの値の型</typeparam>
        /// <param name="dic">[I]元データ</param>
        /// <returns>変換結果(JSON)<br/>
        ///          失敗時は null</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string? ConvertDicToJson<T>(Dictionary<string, T> dic)
        {
            return ConvertObjToJson(dic);
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>[static] JSONファイルからDictionaryを読み込む</summary>
        /// <typeparam name="T">Dictionaryの値の型</typeparam>
        /// <param name="fileName">[I]読み込むファイル</param>
        /// <returns>読み込み結果(Dictionary)<br/>
        ///          失敗時は null</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static Dictionary<string, T>? LoadDicFromJsonFile<T>(string fileName)
        {
            return LoadObjFromJsonFile<Dictionary<string, T>>(fileName);
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>[static] DictionaryをJSONファイルに保存する</summary>
        /// <typeparam name="T">Dictionaryの値の型</typeparam>
        /// <param name="fileName">[I]保存先ファイル名</param>
        /// <param name="dic">[I]元データ</param>
        /// <returns>処理結果<br/>
        ///          true  - 成功<br/>
        ///          false - 失敗</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool SaveDicToJsonFile<T>(string fileName, Dictionary<string, T> dic)
        {
            return SaveObjToJsonFile(fileName, dic);
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// Object <=> XML
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>[static] XMLファイルから保存値(オブジェクト)を読み込む</summary>
        /// <typeparam name="T">戻り値の型</typeparam>
        /// <param name="fileName">[I]読み込むファイル</param>
        /// <returns>読み込み結果(オブジェクト)<br/>
        ///          失敗時は default(T)</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static T? LoadObjFromXmlFile<T>(string fileName)
        {
            try
            {
                // シリアライザ生成
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

                // 読み込み用ストリーム生成
                using (var sr = new StreamReader(fileName, new UTF8Encoding(false)))
                {
                    // デシリアライズ実行、ストリームを閉じる
                    T? ret = (T?)serializer.Deserialize(sr);
                    sr.Close();
                    return ret;
                }
            }
            // 例外発生時は T のデフォルト値を返す
            catch
            {
                return default(T);
            }
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>[static] オブジェクトをXMLファイルに保存する</summary>
        /// <typeparam name="T">元データの型</typeparam>
        /// <param name="fileName">[I]保存先ファイル名</param>
        /// <param name="target">[I]元データ</param>
        /// <returns>処理結果<br/>
        ///          true  - 成功<br/>
        ///          false - 失敗</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool SaveObjToXmlFile<T>(string fileName, T target)
        {
            try
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
                return true;
            }
            // 例外発生時は false を返す
            catch
            {
                return false;
            }
        }

    }
}
