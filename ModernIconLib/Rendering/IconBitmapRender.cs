using ModernIconLib.Asset;
using ModernIconLib.Asset.Icon;
using ModernIconLib.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernIconLib.Rendering
{
    /// <summary>
    /// アイコンプレビューorエクスポート用描画クラス
    /// </summary>
    public class IconBitmapRender : IIconDataRender
    {
        public void RenderIcon(Graphics g, FontFamily font, IconCode iconCode, IconRenderParameter def)
        {
            if (iconCode == null)
                return;
            var sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            //float pt = def.IconSize / 1.33f;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            var layout = new RectangleF(0, 0, 64, 64);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddString(iconCode.CharString, font, (int)FontStyle.Regular, 64, layout, sf);
                if (def.IsFill)
                    using (Brush b = new SolidBrush(def.FillColor))
                        g.FillPath(b, path);
                if (def.HasOutline)
                    using (Pen p = new Pen(def.OutlineColor, def.OutlineWidth))
                        g.DrawPath(p, path);

            }

            //  return new IconData(iconCode, createIconImage(font, iconCode, def));
        }

        public Bitmap RenderIcon(FontFamily font, IconCode iconCode, IconRenderParameter def)
        {
            Bitmap bmp = new Bitmap(def.IconSize, def.IconSize);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                RenderIcon(g, font, iconCode, def);
            }
            return bmp;

        }
    }

}
