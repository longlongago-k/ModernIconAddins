using ModernIconLib.Asset.Icon;
using ModernIconLib.Configuration;
using ModernIconLib.Rendering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernIconLib.Asset
{
    /// <summary>
    /// アイコンアセットクラス
    /// フォント名、全アイコンリストを保持する
    /// </summary>
    public class IconSetAsset
    {
        public string AssetName { get; set; }
        public FontFamily FontFamily { get; set; }
        public IconCode[] IconCodeList { get; set; }
        public Dictionary<IconCode, int> IconCodeIdxDic { get; }
        public IconData[] IconImageList { get; set; } = Array.Empty<IconData>();


        public IconSetAsset(string assetName, FontFamily fontFamily, IconCode[] iconCodeList)
        {
            AssetName = assetName ?? throw new ArgumentNullException(nameof(assetName));
            FontFamily = fontFamily ?? throw new ArgumentNullException(nameof(fontFamily));
            IconCodeList = iconCodeList;
            this.IconCodeIdxDic = iconCodeList.Select((code, idx) => new { idx, code })
                .ToDictionary(v => v.code, v => v.idx);
        }

        public void CreateIconImageList(IIconDataRender render, IconRenderParameter renderParam)
        {
            if (IconImageList == null)
                return;
            if (IconImageList.Length > 0)
                foreach (var icon in IconImageList)
                {
                    icon.Dispose();
                }

            this.IconImageList = 
                IconCodeList.Select(code =>  new IconData(code, FontFamily, render, renderParam))
                .ToArray();
        }

        public override string ToString()
        {
            return $"{AssetName} ({IconCodeList?.Length})";
        }
    }
}
