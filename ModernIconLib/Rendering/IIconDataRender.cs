using ModernIconLib.Asset.Icon;
using ModernIconLib.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernIconLib.Rendering
{
    /// <summary>
    /// アイコンBitmap 作成と描画 インターフェース
    /// </summary>
    public interface IIconDataRender : IIconRender
    {
        Bitmap RenderIcon(FontFamily font, IconCode iconCode, IconRenderParameter def);

    }
}
