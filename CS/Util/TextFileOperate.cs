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
        /// <returns>読み込んだ文字列<br/>
        ///          失敗時は Empty</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string ReadTextFile(string fileName)
        {
            try
            {
                // テキストファイルを開く
                using StreamReader sr = new StreamReader(fileName, new UTF8Encoding(false));
                // 内容をすべて読み込む
                return sr.ReadToEnd();
            }
            // 例外発生時は null を返す
            catch
            {
                return String.Empty;
            }
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
        /// <returns>書き込み結果<br/>
        ///          true  - 成功<br/>
        ///          false - 失敗</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool WriteTextFile(string fileName, string text, bool append = false)
        {
            try
            {
                // テキストファイルを上書きモードで開く
                using StreamWriter sw = new StreamWriter(fileName, append, new UTF8Encoding(false));
                // ファイルに書き込む
                sw.WriteLine(text);

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
