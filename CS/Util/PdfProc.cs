using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Windows.Data.Pdf;
using Windows.Storage.Streams;

namespace Util
{
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    /// <summary>
    /// [static]PDFの操作
    /// </summary>
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    static class PdfProc
    {
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// public メソッド
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [async]ファイルからPDFドキュメントを取得
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <returns>PDFドキュメント</returns>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        public static async Task<PdfDocument> LoadPdf(string path)
        {
            path = System.IO.Path.GetFullPath(path);
            var file = await Windows.Storage.StorageFile.GetFileFromPathAsync(path);

            // ファイルからPDFドキュメントを読み込む
            return await PdfDocument.LoadFromFileAsync(file);
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [async]PDFファイルをビットマップとして読み込む
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <param name="orgDpi">変換前の解像度</param>
        /// <param name="modDpi">変換後の解像度</param>
        /// <returns>ビットマップ</returns>
        /// <returns>変換後のビットマップ</returns>
        /// <remarks>マルチページPDFに対応<br/>
        /// 解像度指定が正しくない場合は、解像度変換を行わない</remarks>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        public static async Task<List<BitmapSource>> LoadPdfAsBitmap(string path,
                                                                     double orgDpi = 0,
                                                                     double modDpi = 0)
        {
            PdfDocument pdf = await LoadPdf(path);
            return await TransPdfDocumentToBitmapSource(pdf, orgDpi, modDpi);
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// private メソッド
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// <summary>
        /// [async]PDFドキュメントをビットマップに変換
        /// </summary>
        /// <param name="pdf">PDFドキュメント</param>
        /// <param name="orgDpi">変換前の解像度</param>
        /// <param name="modDpi">変換後の解像度</param>
        /// <returns>変換後のビットマップ</returns>
        /// <remarks>マルチページPDFに対応<br/>
        /// 解像度指定が正しくない場合は、解像度変換を行わない</remarks>
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        private static async Task<List<BitmapSource>> TransPdfDocumentToBitmapSource(PdfDocument pdf, 
                                                                                   double orgDpi = 0, 
                                                                                   double modDpi = 0)
        {
            List<BitmapSource> ret = new List<BitmapSource>();

            // 各ページをビットマップ(BitmapSource)に変換する
            for (uint i = 0; i < pdf.PageCount; i++)
            {
                using PdfPage page = pdf.GetPage(i);
                using var ras = new InMemoryRandomAccessStream();

                // ストリームにレンダリング
                // 解像度指定が有効な場合のみ解像度変換
                PdfPageRenderOptions renderOptions = new PdfPageRenderOptions();
                if (orgDpi > 0 && modDpi > 0)
                {
                    renderOptions.DestinationWidth = (uint)Math.Round(page.Dimensions.ArtBox.Width / orgDpi * modDpi);
                }
                await page.RenderToStreamAsync(ras, renderOptions);

                // ビットマップに書き出し
                Stream ios = WindowsRuntimeStreamExtensions.AsStream(ras);
                PngBitmapDecoder decoder = new PngBitmapDecoder(ios, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                BitmapSource d = decoder.Frames[0];
                ret.Add(d);
            }

            return ret;
        }

    }       // static class PdfProc

}       // namespace Util

