// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
//
// SettingManager
//
// 設定値の管理
// 
// 依存 : Util.Settings クラス
// ※ Util.Settings クラスをプロジェクトごとに作成すること
//
// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Util
{
    // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    // 設定値管理
    // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    public class SettingManager
    {
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 変数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public Settings mSettings;                                                      //< 設定値本体
        private XmlSerializer mXmlSerializer = new XmlSerializer(typeof(Settings));     //< シリアライザ

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // プロパティ
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public String XmlFileName { get; private set; }                                 //< 保存先のXMLファイル名

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // コンストラクタ
        // -------+-----------------------------------------------------
        // 引数   | String fileName : 保存先ファイル名
        //        |                   デフォルト "Settings.xml"
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public SettingManager(String fileName = "Settings.xml")
        {
            // 設定値本体を生成
            mSettings = new Settings();

            // ファイル名を保存
            XmlFileName = fileName;
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 設定値をXMLファイルに保存
        // -------+-----------------------------------------------------
        // 引数   | なし
        // -------+-----------------------------------------------------
        // 戻り値 | bool : 保存の成否
        //        |        true  - 成功
        //        |        false - 失敗
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public bool Save()
        {
            try
            {
                // XMLファイルを開く(UTF-8 BOM無し)
                StreamWriter sw = new StreamWriter(XmlFileName, false, new UTF8Encoding(false));

                // ファイルに保存(シリアライズ)
                mXmlSerializer.Serialize(sw, mSettings);

                // ストリームを閉じる
                sw.Close();
            }

            // 例外捕捉時は false を返す(保存失敗)
            catch
            {
                return false;
            }

            return true;
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 設定値をXMLファイルから読み込む
        // -------+-----------------------------------------------------
        // 引数   | なし
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public void Load()
        {
            try
            {
                // XMLファイルが存在しない場合は例外を投げる
                if (!File.Exists(XmlFileName))
                {
                    throw new Exception();
                }

                // XMLファイルを開く(UTF-8 BOM無し)
                StreamReader sr = new StreamReader(XmlFileName, new UTF8Encoding(false));

                // ファイルから読み込む(デシリアライズ)
                mSettings = (Settings)mXmlSerializer.Deserialize(sr);

                // ストリームを閉じる
                sr.Close();
            }

            // 例外捕捉時は設定値をリセット(読み込み失敗)
            catch
            {
                mSettings.Reset();
            }
        }

    }       // class SettingManager

}       // namespace FileCopier
