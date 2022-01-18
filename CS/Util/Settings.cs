using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Util
{
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    /// <summary>
    /// アセンブリの設定値
    /// </summary>
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    public struct Settings
    {
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// 定数
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// プロパティ
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public Settings()
        {
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// public メソッド
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// 設定値をデフォルトに戻す
        /// </summary>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public void Reset()
        {
        }

    }       // class Settings

}       // namespace FileCopier
