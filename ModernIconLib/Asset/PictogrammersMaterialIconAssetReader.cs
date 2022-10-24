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
    public class PictogrammersMaterialIconAssetReader
    {
        static PictogrammersMaterialIconAssetReader()
        {
        }


        public static IconSetAsset[] ReadFromResource()
        {
            IconSetAsset asset1 = readFromResource("Pictgrammers Material Design Icons", "Material Design Icons", Properties.Resources.Pictgrammers_materialdesignicons, Properties.Resources.Pictgrammers_Regular_codepoints);
            return new IconSetAsset[] { asset1};
        }
        private static IconSetAsset readFromResource(string name, string familyName, byte[] fontData, string codePoints)
        {
            var iconCodeList = GoogleMaterialIconCodeListReader.ReadFromCsvString(codePoints);
            PrivateFontCollection collection = new PrivateFontCollection();

            IntPtr parray = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(int)) * fontData.Length);
            Marshal.Copy(fontData, 0, parray, fontData.Length);
            collection.AddMemoryFont(parray, fontData.Length);
            FontFamily fontFamily = new FontFamily(familyName, collection);
            Marshal.FreeCoTaskMem(parray);
            return new IconSetAsset(name, fontFamily, iconCodeList);

        }
    }
}
