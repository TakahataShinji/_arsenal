using System;
using System.IO;
using System.Text;

namespace Util
{
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    /// <summary>
    /// [static]テキストファイルの操作
    /// </summary>
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    static class TextFileOperate
    {
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] テキストファイルを読み込む
        /// </summary>
        /// <param name="fileName">[I]読み込むファイル名</param>
        /// <returns>読み込んだ文字列</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string ReadTextFile(string fileName)
        {
            // 読み出しストリーム生成
            using StreamReader sr = new StreamReader(fileName, new UTF8Encoding(false));

            // 内容をすべて読み込む
            return sr.ReadToEnd();
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] テキストファイルを読み込み、行ごとに区切る
        /// </summary>
        /// <param name="fileName">読み込むファイル名</param>
        /// <returns>読み込んだ行の集合</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string[] ReadTextFileByLine(string fileName)
        {
            return ReadTextFile(fileName).Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] テキストファイルを読み込み、
        ///          改行および区切り文字ごとに区切る
        /// </summary>
        /// <param name="fileName">読み込むファイル名</param>
        /// <param name="separator">区切り文字</param>
        /// <returns>読み込んだ内容</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string[] ReadTextFileBySeparator(string fileName, char[] separator)
        {
            // 指定された区切り文字に改行文字を追加
            Array.Resize<char>(ref separator, separator.Length + 2);
            separator[separator.Length - 2] = '\r';
            separator[separator.Length - 1] = '\n';
            return ReadTextFile(fileName).Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] テキストファイルに文字列を書き込む(上書き・追記)
        /// </summary>
        /// <param name="fileName">[I]書き込む対象のファイル名</param>
        /// <param name="text">[I]書き込む文字列</param>
        /// <param name="append">[I]書き込みモード<br/>
        ///                         true  - 追記<br/>
        ///                         false - 上書き</param>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void WriteTextFile(string fileName, string text, bool append = false)
        {
            // 書き込みストリーム生成
            using StreamWriter sw = new StreamWriter(fileName, append, new UTF8Encoding(false));

            // ファイルに書き込む
            sw.WriteLine(text);
        }

    }
}
