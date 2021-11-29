// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
//
// TextFileOperate
//
// [static]テキストファイルの操作
//
// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
using System;
using System.IO;
using System.Text;

namespace Util
{
    static class TextFileOperate
    {
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // テキストファイルを読み込む
        // -------+-----------------------------------------------------
        // 引数   | string fileName : [I]読み込むファイル名
        // -------+-----------------------------------------------------
        // 戻り値 | string : 読み込んだ文字列
        // -------+-----------------------------------------------------
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
        // テキストファイルに文字列を書き込む(上書き・追記)
        // -------+-----------------------------------------------------
        // 引数   | string fileName : [I]書き込む対象のファイル名
        //        | string text     : [I]書き込む文字列
        //        | bool append     : [I]書き込みモード
        //        |                      true  - 追記
        //        |                      false - 上書き
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // -------+-----------------------------------------------------
        // 例外   | UnauthorizedAccessException
        //        | ArgumentException
        //        | ArgumentNullException
        //        | DirectoryNotFoundException
        //        | IOException
        //        | PathTooLongException
        //        | System.Security.SecurityException
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void WriteTextFile(string fileName, string text, bool append = false)
        {
            // テキストファイルを上書きモードで開く
            // (using ステートメントにより、例外発生時も自動的にリソースが解放される)
            using (StreamWriter sw = new StreamWriter(fileName, append, new UTF8Encoding(false)))
            {
                // ファイルに書き込む
                sw.WriteLine(text);
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // テキストファイル中の指定した文字列を置換する
        // -------+-----------------------------------------------------
        // 引数   | string fileName : [I]読み込むファイル名
        //        | string oldStr   : [I]置換前の文字列
        //        | string newStr   : [I]置換後の文字列
        // -------+-----------------------------------------------------
        // 戻り値 | string : 読み込んだ文字列
        // -------+-----------------------------------------------------
        // 例外   | UnauthorizedAccessException
        //        | ArgumentException
        //        | ArgumentNullException
        //        | DirectoryNotFoundException
        //        | IOException
        //        | PathTooLongException
        //        | System.Security.SecurityException
        //        | FileNotFoundException
        //        | NotSupportedException
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

    }
}
