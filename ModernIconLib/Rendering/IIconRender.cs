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
    /// アイコン描画インターフェース
    /// </summary>
    public interface IIconRender
    {
        void RenderIcon(Graphics g, FontFamily font, IconCode iconCode, IconRenderParameter def);
    }
}
