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
    /// FontAwesomeフォント読み込みクラス
    /// </summary>
    public class FontAwesomeIconAssetReader
    {
        static string cachePath = "";
        static FontAwesomeIconAssetReader()
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
            IconSetAsset asset1 = readFromResource("Font Awesome 7 Free-Regular", "Font Awesome 7 Free Regular", Properties.Resources.Font_Awesome_7_Free_Regular_400, Properties.Resources.Font_Awesome7Regular_codepoints);
            IconSetAsset asset2 = readFromResource("Font Awesome 7 Free-Solid", "Font Awesome 7 Free Solid", Properties.Resources.Font_Awesome_7_Free_Solid_900, Properties.Resources.Font_Awesome7Solid_codepoints);
            IconSetAsset asset3 = readFromResource("Font Awesome 7 Free-Brands", "Font Awesome 7 Brands Regular", Properties.Resources.Font_Awesome_7_Brands_Regular_400, Properties.Resources.Font_Awesome7Brands_codepoints);
            return new IconSetAsset[] { asset1, asset2, asset3, };
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
    }
}
