using ModernIconLib.Asset.Icon;
using ModernIconLib.Configuration;
using ModernIconLib.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernIconLib.UI.Preview
{
    public partial class IconPreView : UserControl
    {
        public bool ShowPlusRuler { get; set; } = false;
        public IconData IconData { get => _iconData; set => setIconData(value); }
        private IconData _iconData = null;
        public IconRenderParameter IconRenderParameter { get; set; }

        private IIconRender renderIcon = new IconBitmapRender();
        private IIconRender renderAwsome = new IconBitmapListViewFontAwesomeRender();
        private IIconRender renderSegoeMDL2 = new IconBitmapListViewRenderSegoeMDL2();
        private IIconRender renderFluent = new IconBitmapListViewRenderFluent();
        private EmfVectorGraphics emfGraphics = new EmfVectorGraphics();
        public IconPreView()
        {
            InitializeComponent();
        }

        private void pictureBoxPreview_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            drawGrid(g);
            drawIcon(g);
            if (ShowPlusRuler)
            {
                g.DrawLine(Pens.Red, Width * .5f, 0, Width * .5f, Height);
                g.DrawLine(Pens.Red, 0, Height * .5f, Width, Height * .5f);
            }
        }

        private void drawIcon(Graphics g)
        {
            if (IconData == null)
                return;
            getRenderer(IconData).RenderIcon(g, IconData.Font, IconData.IconCode, IconRenderParameter);
        }

        private void drawGrid(Graphics g)
        {
            int gridSize = 20;
            int numCol = (int)((pictureBoxPreview.Width) / gridSize) + 2;
            int numRow = (int)((pictureBoxPreview.Height) / gridSize) + 2;
            int offSetCol = ((int)(-0.5f * (pictureBoxPreview.Width - gridSize)) % gridSize) - 1;
            int offSetRow = ((int)(-0.5f * (pictureBoxPreview.Height - gridSize)) % gridSize) - 1;
            g.Clear(Color.White);
            for (int y = 0; y < numRow; y++)
            {
                for (int x = 0; x < numCol; x++)
                {
                    Brush b;
                    if ((x + y) % 2 == 0)
                        b = Brushes.LightGray;
                    else
                        b = Brushes.White;
                    g.FillRectangle(b, x * gridSize, y * gridSize, gridSize, gridSize);


                }
            }
        }

        private void setIconData(IconData iconData)
        {
            this._iconData = iconData;
        }

        private IIconRender getRenderer(IconData icon)
        {
            if (icon.Font.Name.Contains("Awesome"))
                return renderAwsome;
            if (icon.Font.Name.Contains("Segoe"))
                return renderSegoeMDL2;
            else if (icon.Font.Name.Contains("Fluent"))
                return renderFluent;
            else
                return renderIcon;
        }

    }
}
