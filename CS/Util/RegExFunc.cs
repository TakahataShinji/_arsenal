using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Util
{
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    /// <summary>
    /// [static] 正規表現
    /// </summary>
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    static class RegExFunc
    {
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// public 定数
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// 検索オプション<br/>
        /// None - オプション無し<br/>
        /// IgnoreCase - 大文字と小文字を区別しない<br/>
        /// Multiline - 複数行モード<br/>
        /// Singleline - 単一行モード<br/>
        /// </summary>
        public enum E_Options
        {
            None,           //< オプション無し
            IgnoreCase,     //< 大文字と小文字を区別しない
            Multiline,      //< 複数行モード
            Singleline,     //< 単一行モード
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// private 定数
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// オプション変換テーブル
        /// </summary>
        private static Dictionary<E_Options, RegexOptions> dic_Options =
            new Dictionary<E_Options, RegexOptions>
            {
                { E_Options.None,        RegexOptions.None          },   //< オプション無し
                { E_Options.IgnoreCase,  RegexOptions.IgnoreCase    },   //< 大文字と小文字を区別しない
                { E_Options.Multiline,   RegexOptions.Multiline     },   //< 複数行モード
                { E_Options.Singleline,  RegexOptions.Singleline    },   //< 単一行モード
            };

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// public メソッド (static)
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] 文字列がパターンにマッチするかを確認する
        /// </summary>
        /// <param name="target">[I]検査対象文字列</param>
        /// <param name="pattern">[I]検索パターン</param>
        /// <param name="options">[I]検索オプション<br/>
        ///                          None       - オプション無し(デフォルト)<br/>
        ///                          IgnoreCase - 大文字と小文字を区別しない<br/>
        ///                          Multiline  - 複数行モード<br/>
        ///                          Singleline - 単一行モード</param>
        /// <returns>検査結果<br/>
        ///          true  - マッチする<br/>
        ///          false - マッチしない、またはパターンが不正</returns>
        /// <exception cref="Exception"></exception>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool IsMatch(string target,
                                   string pattern,
                                   E_Options options = E_Options.None)
        {
            return Regex.IsMatch(target, pattern, dic_Options[options]);
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] 文字列中のパターンにマッチした箇所を抜き出す
        /// </summary>
        /// <param name="target">[I]検査対象文字列</param>
        /// <param name="pattern">[I]検索パターン</param>
        /// <param name="options">[I]検索オプション<br/>
        ///                          None       - オプション無し(デフォルト)<br/>
        ///                          IgnoreCase - 大文字と小文字を区別しない<br/>
        ///                          Multiline  - 複数行モード<br/>
        ///                          Singleline - 単一行モード</param>
        /// <returns>マッチ箇所一覧</returns>
        /// <exception cref="Exception"></exception>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string[] Matches(string target, 
                                       string pattern,
                                       E_Options options = E_Options.None)
        {
            var matches = Regex.Matches(target, pattern, dic_Options[options]);
            string[] ret = new string[matches.Count];
            for(int i = 0; i < matches.Count; ++i)
            {
                ret[i] = matches[i].Value;
            }
            return ret;
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static] 文字列中のパターンにマッチする部分を置換する
        /// </summary>
        /// <param name="input">[I]置換前の文字列</param>
        /// <param name="pattern">[I]検索パターン</param>
        /// <param name="replacement">[I]該当箇所を置換する文字列</param>
        /// <param name="options">[I]検索オプション<br/>
        ///                          None       - オプション無し(デフォルト)<br/>
        ///                          IgnoreCase - 大文字と小文字を区別しない<br/>
        ///                          Multiline  - 複数行モード<br/>
        ///                          Singleline - 単一行モード</param>
        /// <returns>置換後の文字列</returns>
        /// <exception cref="Exception"></exception>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static string Replace(string input,
                                     string pattern,
                                     string replacement,
                                     E_Options options = E_Options.None)
        {
            return Regex.Replace(input, pattern, replacement, dic_Options[options]);
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [static]文字列中のパターンにマッチする部分を置換する<br/>
        ///         (target自身を変更)
        /// </summary>
        /// <param name="target">[I]置換前の文字列<br/>
        ///                      [O]置換後の文字列</param>
        /// <param name="pattern">[I]検索パターン</param>
        /// <param name="replacement">[I]該当箇所を置換する文字列</param>
        /// <param name="options">[I]検索オプション<br/>
        ///                          None       - オプション無し(デフォルト)<br/>
        ///                          IgnoreCase - 大文字と小文字を区別しない<br/>
        ///                          Multiline  - 複数行モード<br/>
        ///                          Singleline - 単一行モード</param>
        /// <exception cref="Exception"></exception>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void Replace(ref string target,
                                   string pattern,
                                   string replacement,
                                   E_Options options = E_Options.None)
        {
            target = Replace(target, pattern, replacement, options);
        }

    }       // static class RegExFunc

    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    /// <summary>
    /// 正規表現(設定したパターンを保持する)
    /// </summary>
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    class RegExFuncCompiled
    {
        /// <summary>
        /// 正規表現コアモジュール
        /// </summary>
        private Regex core;

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="pattern">[I]保持するパターン</param>
        /// <exception cref="Exception"></exception>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public RegExFuncCompiled(string pattern)
        {
            // 正規表現オブジェクト生成
            core = new Regex(pattern, RegexOptions.Compiled);
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// public メソッド
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// 文字列が保持しているパターンにマッチするかを確認する
        /// </summary>
        /// <param name="target">[I]検査対象文字列</param>
        /// <returns>検査結果<br/>
        ///          true  - マッチする<br/>
        ///          false - マッチしない、またはパターンが不正</returns>
        /// <exception cref="Exception"></exception>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public bool IsMatch(string target)
        {
            return core.IsMatch(target);
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// 文字列中のパターンにマッチする部分を置換する
        /// </summary>
        /// <param name="input">[I]置換される文字列</param>
        /// <param name="replacement">[I]該当箇所を置換する文字列</param>
        /// <returns>置換後の文字列</returns>
        /// <exception cref="Exception"></exception>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public string Replace(string input, string replacement)
        {
            return core.Replace(input, replacement);
        }

    }       // class RegExFuncCompiled

}       // namespace Util
