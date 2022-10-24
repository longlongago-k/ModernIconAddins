using ModernIconLib.Asset;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernIconLib.UI.IconViewDraw
{
    public class IconTileDetailViewDrawer : IconViewDrawerBase
    {
        public IconTileDetailViewDrawer(PictureBox pictureBox, VScrollBar vScrollBar):base(pictureBox, vScrollBar)
        {
        }

        public override void DrawIconView(Graphics g, int iconSize)
        {
            int top = vScrollBar.Value;
            int bottom = top + pictureBox.Height;
            int width = pictureBox.Width;
            int height = pictureBox.Height;

            int cols = 5;//横の画像数
            int rows = CurrentAsset.IconCodeList.Length / cols + 1;//縦の画像数、1つ分はマージン
            int imgStartY = top / iconSize;
            int yOffset = -top % iconSize;

            StringFormat format = new StringFormat() { LineAlignment = StringAlignment.Center };

            float headerWidth = iconSize + 40;
            float nameWidth = (width / 5f) - headerWidth;
            float cellWidth = headerWidth + nameWidth;
            if (nameWidth < 0)
                nameWidth = 0;
            int i = imgStartY * cols;
            for (int y = imgStartY; y < rows; y++)
            {
                for (int x = 0; x < cols && i < CurrentAsset.IconCodeList.Length; x++, i++)
                {
                    float xPos = cellWidth * x;
                    //g.DrawString(Char.ConvertFromUtf32(codeList[i].code), font, Brushes.DimGray, x * iconSize, y * iconSize);
                    float yPos = yOffset + (y - imgStartY) * iconSize;
                    g.FillRectangle(Brushes.Wheat, xPos, yPos, cellWidth, iconSize);
                    g.DrawImage(iconImageCache[i], new PointF(xPos, yPos));
                    xPos += iconSize;
                    g.DrawString(CurrentAsset.IconCodeList[i].Code.ToString("X"), pictureBox.Font, Brushes.DimGray,
                        new RectangleF(xPos, yPos, (headerWidth - iconSize), iconSize), format);
                    xPos += 40;
                    g.DrawString(CurrentAsset.IconCodeList[i].Name, pictureBox.Font, Brushes.DimGray,
                        new RectangleF(xPos, yPos, nameWidth, iconSize), format);
                }
            }

        }
        internal override void UpdateScrollParameter()
        {
            int iconSize = 32;
            int width = pictureBox.Width;
            int height = pictureBox.Height;

            if (CurrentAsset != null)
            {
                    int cols = 5;
                    int rows = CurrentAsset.IconCodeList.Length / cols + 1;
                    int _height = rows * iconSize;
                    if (height < _height)
                    {
                        float ratio = vScrollBar.Value / (float)(vScrollBar.Maximum - vScrollBar.LargeChange);
                        vScrollBar.Enabled = true;
                        vScrollBar.LargeChange = height;
                        vScrollBar.Maximum = _height + vScrollBar.LargeChange - 1;
                        vScrollBar.Maximum = _height - 1;
                        vScrollBar.Value = (int)(ratio * (vScrollBar.Maximum - vScrollBar.LargeChange));
                    }
            }
            else
                vScrollBar.Enabled = false;
        }


    }
}
