using ModernIconLib.Asset;
using ModernIconLib.CodeList;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Collections.ObjectModel;

namespace ModernIconLib.Asset
{
    /// <summary>
    /// Google Material iconsフォント読み込みクラス
    /// </summary>
    public class GoogleMaterialIconAssetReader
    {
        static readonly string RegularUrl = "https://github.com/google/material-design-icons/raw/master/font/MaterialIcons-Regular.ttf";
        static readonly string OutlineUrl = "https://github.com/google/material-design-icons/raw/master/font/MaterialIconsOutlined-Regular.otf";
        static readonly string RoundUrl = "https://github.com/google/material-design-icons/raw/master/font/MaterialIconsRound-Regular.otf";
        static readonly string SharpUrl = "https://github.com/google/material-design-icons/raw/master/font/MaterialIconsSharp-Regular.otf";
        static readonly string RegularCodePointUrl = "https://github.com/google/material-design-icons/raw/master/font/MaterialIcons-Regular.codepoints";
        static readonly string OutlineCodePointUrl = "https://github.com/google/material-design-icons/raw/master/font/MaterialIconsOutlined-Regular.codepoints";
        static readonly string RoundCodePointUrl = "https://github.com/google/material-design-icons/raw/master/font/MaterialIconsRound-Regular.codepoints";
        static readonly string SharpCodePointUrl = "https://github.com/google/material-design-icons/raw/master/font/MaterialIconsSharp-Regular.codepoints";

        static string cachePath = "";
        static GoogleMaterialIconAssetReader()
        {
        }

        private static void checkCacheDir()
        {
            string currentPath = Assembly.GetExecutingAssembly().Location;
            if (currentPath == null)
                return;
            currentPath = Path.GetDirectoryName(currentPath);
            cachePath = currentPath + "\\cache";
            if(Directory.Exists(cachePath) ==false)
            {
                Directory.CreateDirectory(cachePath);
            }
        }

        public static IconSetAsset[] ReadFromResource()
        {
            IconSetAsset asset1 = readFromResource("Google Material Icons Regular", "Material Icons", Properties.Resources.MaterialIcons_Regular, Properties.Resources.MaterialIcons_Regular_codepoints);
            IconSetAsset asset2 = readFromResource("Google Material Icons Outlined", "Material Icons Outlined", Properties.Resources.MaterialIconsOutlined_Regular, Properties.Resources.MaterialIconsOutlined_Regular_codepoints);
            IconSetAsset asset3 = readFromResource("Google Material Icons Round", "Material Icons Round", Properties.Resources.MaterialIconsRound_Regular, Properties.Resources.MaterialIconsRound_Regular_codepoints);
            IconSetAsset asset4 = readFromResource("Google Material Icons Sharp", "Material Icons Sharp", Properties.Resources.MaterialIconsSharp_Regular, Properties.Resources.MaterialIconsSharp_Regular_codepoints);
            return new IconSetAsset[] { asset1, asset2, asset3, asset4 };
        }
        private static IconSetAsset readFromResource(string name, string familyName, byte[] fontData,string codePoints)
        {
            var iconCodeList = GoogleMaterialIconCodeListReader.ReadFromCsvString(codePoints);
            PrivateFontCollection collection = new PrivateFontCollection();

            IntPtr parray = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, parray, fontData.Length);
            collection.AddMemoryFont(parray, fontData.Length);
            FontFamily fontFamily = new FontFamily(familyName, collection);
            Marshal.FreeCoTaskMem(parray);
            return new IconSetAsset(name, fontFamily, iconCodeList);

        }
        /// <summary>
        /// (未使用)GithubリポジトリからフォントファイルをDLしてキャッシュするクラス
        /// </summary>
        /// <param name="useCache"></param>
        /// <returns></returns>
        public static IconSetAsset[] DownloadFromWeb(bool useCache = true)
        {

            IconSetAsset asset1 = downloadFromWeb("Google Material Icons Regular", "Material Icons", RegularUrl, RegularCodePointUrl);
            IconSetAsset asset2 = downloadFromWeb("Google Material Icons Outlined", "Material Icons", OutlineUrl, OutlineCodePointUrl);
            IconSetAsset asset3 = downloadFromWeb("Google Material Icons Round", "Material Icons", RoundUrl, RoundCodePointUrl);
            IconSetAsset asset4 = downloadFromWeb("Google Material Icons Sharp", "Material Icons", SharpUrl, SharpCodePointUrl);
            return new IconSetAsset[] { asset1, asset2, asset3, asset4 };
        }
        private static IconSetAsset downloadFromWeb(string name, string familyName, string fontUrl, string codePointUrl, bool useCache = true)
        {
            checkCacheDir();


            if (isCached(fontUrl) == false || isCached(codePointUrl) == false || !useCache)
            {
                WebClient wc = new WebClient();
                string iconCodeSrc = GoogleMaterialIconCodeListReader.DownloadFromUrl(new Uri(codePointUrl));
                byte[] fontData = wc.DownloadData(RegularUrl);

                var iconCodeList = GoogleMaterialIconCodeListReader.ReadFromString(iconCodeSrc);
                PrivateFontCollection collection = new PrivateFontCollection();

                IntPtr parray = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(int)) * fontData.Length);
                Marshal.Copy(fontData, 0, parray, fontData.Length);
                collection.AddMemoryFont(parray, fontData.Length);
                FontFamily fontFamily = new FontFamily(familyName, collection);
                Marshal.FreeCoTaskMem(parray);
                saveCache(fontUrl, fontData);
                saveCache(codePointUrl, Encoding.UTF8.GetBytes(iconCodeSrc));

                return new IconSetAsset(name, fontFamily, iconCodeList);
            }
            else
            {
                string fontPath = $"{cachePath}\\{Path.GetFileName(fontUrl)}";
                string codePointPath = $"{cachePath}\\{Path.GetFileName(codePointUrl)}";
                var iconCodeList = GoogleMaterialIconCodeListReader.ReadFromFile(codePointPath);
                byte[] fontData = File.ReadAllBytes(fontPath);

                PrivateFontCollection collection = new PrivateFontCollection();

                IntPtr parray = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(int)) * fontData.Length);
                Marshal.Copy(fontData, 0, parray, fontData.Length);
                collection.AddMemoryFont(parray, fontData.Length);
                FontFamily fontFamily = new FontFamily("Material Icons", collection);
                Marshal.FreeCoTaskMem(parray);

                return new IconSetAsset(name, fontFamily, iconCodeList);

            }
        }


        private static bool isCached(string url)
        {
            return File.Exists($"{cachePath}\\{Path.GetFileName(url)}");
        }
        private static void saveCache(string url, byte[] data)
        {
            File.WriteAllBytes($"{cachePath}\\{Path.GetFileName(url)}", data);
        }
    }
}
