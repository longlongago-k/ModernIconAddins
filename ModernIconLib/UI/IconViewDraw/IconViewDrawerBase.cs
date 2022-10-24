using ModernIconLib.Asset;
using ModernIconLib.Asset.Icon;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace ModernIconLib.UI.IconViewDraw
{
    public abstract class IconViewDrawerBase
    {
        protected PictureBox pictureBox;
        protected VScrollBar vScrollBar;
        protected Bitmap[] iconImageCache = Array.Empty<Bitmap>();
        public IconSetAsset CurrentAsset { get; set; } = null;
        public IconViewDrawerBase(PictureBox pictureBox, VScrollBar vScrollBar)
        {
            this.pictureBox = pictureBox ?? throw new ArgumentNullException(nameof(pictureBox));
            this.vScrollBar = vScrollBar ?? throw new ArgumentNullException(nameof(vScrollBar));
        }

        public abstract void DrawIconView(Graphics g, int iconSize);
        internal virtual Bitmap[] CreateIconImgCache()
        {
            if (CurrentAsset == null)
                return Array.Empty<Bitmap>();
            foreach (var item in iconImageCache)
                item.Dispose();
            float iconSize = 32f;
            iconImageCache =  CurrentAsset.IconCodeList
                .Select(icon => createIconImage(CurrentAsset, icon, (int)iconSize))
                .ToArray();
            return iconImageCache;
        }
        protected virtual Bitmap createIconImage(IconSetAsset asset, IconCode icon, int iconSize)
        {
            Bitmap bmp = new Bitmap(iconSize, iconSize);
            var sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            float pt = iconSize / 1.33f;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddString(icon.CharString, CurrentAsset.FontFamily, (int)FontStyle.Regular, pt, new RectangleF(0, 0, iconSize, iconSize), sf);
                    g.FillPath(Brushes.DimGray, path);

                }
            }
            return bmp;
        }

        internal abstract void UpdateScrollParameter();
        internal virtual void MouseMove(object sender, MouseEventArgs e) => pictureBox?.Invalidate();
    }
}