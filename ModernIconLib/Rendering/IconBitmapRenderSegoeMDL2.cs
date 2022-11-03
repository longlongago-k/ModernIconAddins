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
using System.Windows.Forms;

namespace ModernIconLib.Rendering
{
    /// <summary>
    /// リストビュー用描画クラス
    /// </summary>
    public class IconBitmapRenderSegoeMDL2 : IIconDataRender
    {
        public void RenderIcon(Graphics g, FontFamily font, IconCode iconCode, IconRenderParameter def)
        {
            var sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            float pt = def.IconSize / (g.DpiY / 72.0f);
            pt *= .8f;// いくつかのアイコンははみ出るサイズになっているのでサイズ調整
            //  float sizeInPixels = font.SizeInPoints * g.DpiY / 72;  // 1 inch = 72 points
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            var layout = new RectangleF(0, 0, def.IconSize, def.IconSize);
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddString(iconCode.CharString, font, (int)FontStyle.Regular, pt, layout, sf);
                
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
            Bitmap bmp = new Bitmap(64,64);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                RenderIcon(g, font, iconCode, def);
            }
            return bmp;

        }

        //protected Bitmap createIconImage(FontFamily font, IconCode icon, IconRenderParameter def)
        //{
        //    //int iconSIze = def.IconSize;
        //    Bitmap bmp = new Bitmap(def.IconSize, def.IconSize);
        //    var sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
        //    float pt = def.IconSize / 1.33f;
        //    using (Graphics g = Graphics.FromImage(bmp))
        //    {
        //        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //        g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

        //        using (GraphicsPath path = new GraphicsPath())
        //        {
        //            path.AddString(icon.CharString, font, (int)FontStyle.Regular, pt, new RectangleF(0, 0, def.IconSize, def.IconSize), sf);
        //            using (Brush b = new SolidBrush(def.FillColor))
        //                g.FillPath(b, path);
        //            if (def.HasOutline)
        //                using (Pen p = new Pen(def.OutlineColor, def.OutlineWidth))
        //                    g.DrawPath(p, path);

        //        }
        //    }
        //    return bmp;
        //}

    }
}
