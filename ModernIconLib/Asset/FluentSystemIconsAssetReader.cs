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
    public class FluentSystemIconsAssetReader
    {
        static FluentSystemIconsAssetReader()
        {
        }

        public static IconSetAsset[] ReadFromResource()
        {
            IconSetAsset asset1 = readFromResource("FluentSystemIcons-Regular", "FluentSystemIcons-Regular", Properties.Resources.FluentSystemIcons_Regular, Properties.Resources.FluentSystemIcons_Regular_codepoints);
            IconSetAsset asset2 = readFromResource("FluentSystemIcons-Filled", "FluentSystemIcons-Filled", Properties.Resources.FluentSystemIcons_Filled, Properties.Resources.FluentSystemIcons_Filled_codepoints);
            return new IconSetAsset[] { asset1, asset2};
        }
        private static IconSetAsset readFromResource(string name, string familyName, byte[] fontData, string codePoints)
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

