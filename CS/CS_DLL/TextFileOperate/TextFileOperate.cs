// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
//
// TextFileOperate
//
// テキストファイル操作
//
// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
using System;
using System.Text;
using System.IO;

namespace Util
{
    public class TextFileOperate
    {
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public関数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // テキストファイルを読み込む
        // -------------------------------------------------------------
        // 引数   | string fileName : 読み込むファイルのパス
        // -------------------------------------------------------------
        // 戻り値 | string : 読み込んだ文字列
        // -------------------------------------------------------------
        // 例外   | ArgumentException
        //        | ArgumentNullException
        //        | FileNotFoundException
        //        | DirectoryNotFoundException
        //        | NotSupportedException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string ReadTextFile(string fileName)
        {
            string ret = "";

            // テキストファイルを開く
            // (using ステートメントにより、例外発生時も自動的にリソースが解放される)
            using (StreamReader sr = new StreamReader(fileName, new UTF8Encoding(false)))
            {
                // 内容をすべて読み込む
                ret = sr.ReadToEnd();
            }

            return ret;
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // テキストファイルに文字列を書き込む
        // -------------------------------------------------------------
        // 引数   | string fileName : 書き込み先のファイルパス
        //        | string text     : 書き込む文字列
        //        | bool append     : 書き込みモード(追記モードで書き込むか)
        //        |                   true  - 追記
        //        |                   false - 上書き
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | ArgumentException
        //        | ArgumentNullException
        //        | DirectoryNotFoundException
        //        | IOException
        //        | PathTooLongException
        //        | System.Security.SecurityException
        //        | UnauthorizedAccessException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void WriteTextFile(string fileName,
                                         string text, 
                                         bool append = false)
        {
            // テキストファイルを書き込み用に開く
            // (using ステートメントにより、例外発生時も自動的にリソースが解放される)
            using (StreamWriter sw = new StreamWriter(fileName, append, new UTF8Encoding(false)))
            {
                // ファイルに書き込む
                sw.WriteLine(text);
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // テキストファイル中の指定した文字列を置換する
        // -------------------------------------------------------------
        // 引数   | string fileName : 読み込むファイル名
        //        | string oldStr   : 置換前の文字列
        //        | string newStr   : 置換後の文字列
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | ArgumentException
        //        | ArgumentNullException
        //        | DirectoryNotFoundException
        //        | FileNotFoundException
        //        | IOException
        //        | NotSupportedException
        //        | PathTooLongException
        //        | System.Security.SecurityException
        //        | UnauthorizedAccessException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void ReplaceText(string fileName, string oldStr, string newStr)
        {
            // ファイルの内容を読み込む
            string content = ReadTextFile(fileName);

            // 含まれる oldStr をすべて newStr で置換
            content = content.Replace(oldStr, newStr);

            // ファイルを上書き保存
            WriteTextFile(fileName, content);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // XMLファイルに値を保存(直列化)
        // -------------------------------------------------------------
        // 引数   | string fileName : 書き込むXMLファイル名
        //        | object o        : 保存対象データオブジェクト
        //        | Type type       : 保存対象データの型
        // -------------------------------------------------------------
        // 戻り値 | なし
        // -------------------------------------------------------------
        // 例外   | ArgumentException
        //        | ArgumentNullException
        //        | DirectoryNotFoundException
        //        | EncoderFallbackException
        //        | IOException
        //        | PathTooLongException
        //        | System.Security.SecurityException
        // -------------------------------------------------------------
        // type は typeof(型名)で取得したものを使用する
        // リスト型も使用できる
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void SerializeXML(string fileName,
                                        object o, 
                                        Type type)
        {
            // シリアライザの生成
            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(type);

            // XMLファイルを開く
            // (using ステートメントにより、例外発生時も自動的にリソースが解放される)
            using (StreamWriter sw = new StreamWriter(fileName, false, new UTF8Encoding(false)))
            {
                // XMLファイルに書き込み(直列化)
                serializer.Serialize(sw, o);
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // XMLファイルから値を取得(並列化)
        // -------------------------------------------------------------
        // 引数   | string fileName : 読み込むXMLファイル名
        //        | Type type       : 並列化対象データの型
        // -------------------------------------------------------------
        // 戻り値 | object : 並列化されたデータオブジェクト
        // -------------------------------------------------------------
        // 例外   | ArgumentException
        //        | ArgumentNullException
        //        | DirectoryNotFoundException
        //        | FileNotFoundException
        //        | InvalidOperationException
        //        | NotSupportedException
        // -------------------------------------------------------------
        // 戻り値は汎用の object のため、
        // 参照する際は呼び出し側でキャストする必要がある
        // 例 : (TypeName)Util.DeserializeXML(fileName, typeof(TypeName));
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static object DeserializeXML(string fileName, Type type)
        {
            object ret = null;

            // シリアライザの生成
            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(type);

            // XMLファイルを開く
            // (using ステートメントにより、例外発生時も自動的にリソースが解放される)
            using (StreamReader sr = new StreamReader(fileName, new UTF8Encoding(false)))
            {
                // XMLファイルから読み込み、並列化
                ret = serializer.Deserialize(sr);
            }

            return ret;
        }

    }       // public class TextFileOperate

}       // namespace Util
