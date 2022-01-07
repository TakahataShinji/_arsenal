/// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
//
// SettingManager
//
/// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Util
{
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    /// <summary>
    /// 設定値管理<br/>
    /// 依存 : Util.Settings <br/>
    ///        Util.Json_Xml_FileOperate
    /// </summary>
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    public class SettingManager
    {
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 定数
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// 設定値を保存するファイルの形式
        /// </summary>
        public enum E_FileType
        {
            JSON,           //< JSON
            XML,            //< XML
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 変数
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public Settings mSettings;          //< 設定値本体
        private E_FileType mE_FileType;     //< 保存先ファイル形式
        private string mFileName;           //< 保存先ファイル名

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="fileName">[I]保存先ファイル名</param>
        /// <param name="fileType">[I]保存先ファイル形式</param>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public SettingManager(string? fileName = null, E_FileType fileType=E_FileType.XML)
        {
            // 設定値本体を生成
            mSettings = new Settings();

            // ファイル名が無効な場合はデフォルトを充てる
            if (String.IsNullOrEmpty(fileName))
            {
                fileName = "Setting.cfg";
            }

            // ファイル名、ファイル形式を保存
            mFileName = fileName;
            mE_FileType = fileType;
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// 設定値を保存
        /// </summary>
        /// <returns>保存の成否<br/>
        ///          true  - 成功<br/>
        ///          false - 失敗</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public bool Save()
        {
            switch (mE_FileType)
            {
                // JSON保存
                case E_FileType.JSON:
                    return Json_Xml_FileOperate.SaveObjToJsonFile<Settings>(mFileName, mSettings);

                // XML保存
                case E_FileType.XML:
                    return Json_Xml_FileOperate.SaveObjToXmlFile<Settings>(mFileName, mSettings);

                default:
                    return false;
            }
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// 設定値の読み込み
        /// </summary>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public void Load()
        {
            switch (mE_FileType)
            {
                // JSON保存
                case E_FileType.JSON:
//                    mSettings.DeepCopyFrom(Json_Xml_FileOperate.LoadObjFromJsonFile<Settings>(mFileName));
                    break;

                // XML保存
                case E_FileType.XML:
  //                  mSettings.DeepCopyFrom(Json_Xml_FileOperate.LoadObjFromXmlFile<Settings>(mFileName));
                    break;

                default:
                    mSettings.Reset();
                    break;
            }
        }

    }       // class SettingManager

}       // namespace FileCopier
