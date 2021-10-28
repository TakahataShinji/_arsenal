// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
//
// SettingManager
//
// 設定値の管理
//
// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Xml.Serialization;

using Util;

namespace FileCopier
{
    // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    // 設定値本体
    // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    public class Settings
    {
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 定数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // デフォルト設定値
        private const UInt16 NUM_THREADS_DEF = 3;                                 //< コピー処理スレッド数

        private const String SRCDIR_PHOTO_DEF = @"V:\DCIM";                       //< コピー元ディレクトリ(写真)
        private const String DSTDIR_PHOTO_DEF = @"M:\01_gallery\02_写真\Albums";  //< コピー先ディレクトリ(写真)
        private const String SRCDIR_MUSIC_DEF = @"D:\My_Music";                   //< コピー元ディレクトリ(楽曲ほか)
        private const String DSTDIR_MUSIC_DEF = @"V:\AV\Music";                   //< コピー先ディレクトリ(楽曲ほか)

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // プロパティ
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public UInt16 Num_Threads { get; set; }                         //< コピー処理スレッド数

        public BindingList<String> SrcDir_Photo { get; set; }           //< コピー元ディレクトリ(写真)
        public BindingList<String> DstDir_Photo { get; set; }           //< コピー先ディレクトリ(写真)
        public BindingList<String> SrcDir_Music { get; set; }           //< コピー元ディレクトリ(楽曲ほか)
        public BindingList<String> DstDir_Music { get; set; }           //< コピー先ディレクトリ(楽曲ほか)

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // コンストラクタ
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public Settings()
        {
            // BindingList を生成
            SrcDir_Photo = new BindingList<String>();   //< コピー元ディレクトリ(写真)
            DstDir_Photo = new BindingList<String>();   //< コピー先ディレクトリ(写真)
            SrcDir_Music = new BindingList<String>();   //< コピー元ディレクトリ(楽曲ほか)
            DstDir_Music = new BindingList<String>();   //< コピー先ディレクトリ(楽曲ほか)
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // コンストラクタ
        // -------+-----------------------------------------------------
        // 引数   | Settings src : 基となる Settings
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public Settings(Settings src) : this()
        {
            DeepCopyFrom(src);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public メソッド
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 設定値をデフォルトに戻す
        // -------+-----------------------------------------------------
        // 引数   | なし
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public void Reset()
        {
            // スレッド数
            Num_Threads = NUM_THREADS_DEF;

            // コピー元(写真)
            SrcDir_Photo.Clear();
            SrcDir_Photo.Add(SRCDIR_PHOTO_DEF);

            // コピー先(写真)
            DstDir_Photo.Clear();
            DstDir_Photo.Add(DSTDIR_PHOTO_DEF);

            // コピー元(楽曲その他)
            SrcDir_Music.Clear();
            SrcDir_Music.Add(SRCDIR_MUSIC_DEF);

            // コピー先(楽曲その他)
            DstDir_Music.Clear();
            DstDir_Music.Add(DSTDIR_MUSIC_DEF);
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // ディープコピー
        // -------+-----------------------------------------------------
        // 引数   | Settings src : コピー元のオブジェクト
        // -------+-----------------------------------------------------
        // 戻り値 | なし
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public void DeepCopyFrom(Settings src)
        {
            Num_Threads = src.Num_Threads;                  //< スレッド数

            SrcDir_Photo.DeepCopyFrom(src.SrcDir_Photo);     //< コピー元ディレクトリ(写真)
            DstDir_Photo.DeepCopyFrom(src.DstDir_Photo);     //< コピー先ディレクトリ(写真)
            SrcDir_Music.DeepCopyFrom(src.SrcDir_Music);     //< コピー元ディレクトリ(楽曲ほか)
            DstDir_Music.DeepCopyFrom(src.DstDir_Music);     //< コピー先ディレクトリ(楽曲ほか)
        }

    }       // class Settings

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
