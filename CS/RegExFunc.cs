// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
//
// RegExFunc
//
// [static]正規表現
//
// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Util
{
    // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    // RegExFunc クラス
    // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    static class RegExFunc
    {
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public 定数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public enum E_Options
        {
            None,           //< オプション無し
            IgnoreCase,     //< 大文字と小文字を区別しない
            Multiline,      //< 複数行モード
            Singleline,     //< 単一行モード
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // private 定数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // オプション変換テーブル
        private static Dictionary<E_Options, RegexOptions> dic_Options =
            new Dictionary<E_Options, RegexOptions>
            {
                { E_Options.None,        RegexOptions.None          },   //< オプション無し
                { E_Options.IgnoreCase,  RegexOptions.IgnoreCase    },   //< 大文字と小文字を区別しない
                { E_Options.Multiline,   RegexOptions.Multiline     },   //< 複数行モード
                { E_Options.Singleline,  RegexOptions.Singleline    },   //< 単一行モード
            };

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public メソッド (static)
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 文字列がパターンにマッチするかを確認する
        // -------+-----------------------------------------------------
        // 引数   | String target  : [I]検査対象文字列
        //        | String pattern : [I]パターン
        // -------+-----------------------------------------------------
        // 戻り値 | Boolean : 検査結果
        //        |           true  - マッチする
        //        |           false - マッチしない、またはパターンが不正
        // -------+-----------------------------------------------------
        // 例外   | あり
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static Boolean IsMatch(String target, String pattern)
        {
            return Regex.IsMatch(target, pattern);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 文字列中のパターンにマッチする部分を置換する
        // -------+-----------------------------------------------------
        // 引数   | String input       : [I]置換される文字列
        //        | String pattern     : [I]パターン
        //        | String replacement : [I]置換する文字列
        //        | E_Options options  : [I]検索オプション
        //        |                         None       - オプション無し(デフォルト)
        //        |                         IgnoreCase - 大文字と小文字を区別しない
        //        |                         Multiline  - 複数行モード
        //        |                         Singleline - 単一行モード
        // -------+-----------------------------------------------------
        // 戻り値 | String : 置換後の文字列
        // -------+-----------------------------------------------------
        // 例外   | あり
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static String Replace(String input,
                                     String pattern,
                                     String replacement,
                                     E_Options options = E_Options.None)
        {
            return Regex.Replace(input, pattern, replacement, dic_Options[options]);
        }

    }

    // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    // RegExFuncCompiled クラス
    // 設定したパターンを保持する
    // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    class RegExFuncCompiled
    {
        private Regex core;     //< 正規表現オブジェクト

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // コンストラクタ
        // -------+-----------------------------------------------------
        // 引数   | String pattern : [I]保持するパターン
        // -------+-----------------------------------------------------
        // 例外   | あり
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public RegExFuncCompiled(String pattern)
        {
            // 正規表現オブジェクト生成
            core = new Regex(pattern, RegexOptions.Compiled);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public メソッド
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 文字列が保持しているパターンにマッチするかを確認する
        // -------+-----------------------------------------------------
        // 引数   | String target  : [I]検査対象文字列
        // -------+-----------------------------------------------------
        // 戻り値 | Boolean : 検査結果
        //        |           true  - マッチする
        //        |           false - マッチしない、またはパターンが不正
        // -------+-----------------------------------------------------
        // 例外   | あり
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public Boolean IsMatch(String target)
        {
            return core.IsMatch(target);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 文字列中のパターンにマッチする部分を置換する
        // -------+-----------------------------------------------------
        // 引数   | String input       : [I]置換される文字列
        //        | String replacement : [I]置換する文字列
        // -------+-----------------------------------------------------
        // 戻り値 | String : 置換後の文字列
        // -------+-----------------------------------------------------
        // 例外   | あり
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public String Replace(String input, String replacement)
        {
            return core.Replace(input, replacement);
        }
    }

}
