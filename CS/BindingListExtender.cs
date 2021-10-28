// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
//
// BindingListExtender
//
// [static] BindingList 拡張
//
// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

using System;
using System.ComponentModel;

namespace Util
{
    public static class BindingListExtender
    {
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 拡張メソッド
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 要素を追加
        // -------+-----------------------------------------------------
        // 引数   | String str : 追加する String
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void AddItem(this BindingList<String> me, String str)
        {
            // 重複する要素が存在しなければ追加
            if (!me.Contains(str))
            {
                me.Add(str);
            }
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ディープコピー
        // -------+-----------------------------------------------------
        // 引数   | BindingList<String> src : コピー元の BindingList
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static void DeepCopyFrom(this BindingList<String> me, BindingList<String> src)
        {
            // 要素をクリア
            me.Clear();

            // 要素を順に追加
            foreach (String str in src)
            {
                me.Add(str);
            }
        }

    }       // public static class BindingListExtender
}       // namespace Util
