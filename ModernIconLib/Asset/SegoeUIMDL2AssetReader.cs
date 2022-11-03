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
    public class SegoeUIMDL2AssetReader
    {
        static string cachePath = "";
        static SegoeUIMDL2AssetReader()
        {
        }


        public static IconSetAsset[] ReadFromResource()
        {
            IconSetAsset asset1 = readFromResource("Segoe MDL2 Assets", Properties.Resources.SegoeMDL2Assets_codepoints);
            return new IconSetAsset[] { asset1 };
        }
        private static IconSetAsset readFromResource(string name, string codePoints)
        {
            try
            {
                var fontFamily = new FontFamily("Segoe MDL2 Assets");
                var iconCodeList = GoogleMaterialIconCodeListReader.ReadFromCsvString(codePoints);
                return new IconSetAsset(name+"(Win10)", fontFamily, iconCodeList);
            }
            catch
            {
                return new IconSetAsset(name + "(Win10)(インストールされていません, MicrosoftのサイトからDLしてください)", null, null);

            }

        }
    }
}
