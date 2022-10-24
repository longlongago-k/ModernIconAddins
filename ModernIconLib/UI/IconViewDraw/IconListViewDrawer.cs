using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernIconLib.UI.IconViewDraw
{
    public class IconListViewDrawer : IconViewDrawerBase
    {

        public IconListViewDrawer(PictureBox pictureBox, VScrollBar vScrollBar) : base(pictureBox, vScrollBar)
        {
        }

        public override void DrawIconView(Graphics g, int iconSize)
        {
            int top = vScrollBar.Value;
            int bottom = top + pictureBox.Height;
            int width = pictureBox.Width;
            int height = pictureBox.Height;

            int rows = CurrentAsset.IconCodeList.Length;//縦の画像数
            int imgStart = top / iconSize;
            int yOffset = -top % iconSize;
            StringFormat format = new StringFormat() { LineAlignment = StringAlignment.Center };
            for (int i = imgStart; i < CurrentAsset.IconCodeList.Length; i++)
            {
                float yPos = yOffset + (i - imgStart) * iconSize;
                g.DrawLine(Pens.DimGray, 0, yPos, width, yPos);
                g.DrawString(i.ToString(), pictureBox.Font, Brushes.DimGray, new RectangleF(0, yPos, 40, iconSize), format);
                float lOffsetText = 40 + iconSize + 10;
                g.DrawString(CurrentAsset.IconCodeList[i].Name, pictureBox.Font, Brushes.DimGray, new RectangleF(lOffsetText, yPos, width - lOffsetText, iconSize), format);
                g.DrawImage(iconImageCache[i], new PointF(40, yPos));
                //path.Add Path(pathCache[i]);

            }
        }

        internal override void UpdateScrollParameter()
        {
            int iconSize = 32;
            int width = pictureBox.Width;
            int height = pictureBox.Height;

            if (CurrentAsset != null)
            {
                int _height = (CurrentAsset.IconCodeList.Length) * iconSize;
                if (height < _height)
                {
                    float ratio = vScrollBar.Value / (float)(vScrollBar.Maximum - vScrollBar.LargeChange);
                    vScrollBar.Enabled = true;
                    vScrollBar.LargeChange = height;
                    vScrollBar.Maximum = _height - 1;
                    vScrollBar.Value = (int)(ratio * (vScrollBar.Maximum - vScrollBar.LargeChange));
                }
            }
            else
                vScrollBar.Enabled = false;

        }

    }
}
