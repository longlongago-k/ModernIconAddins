using ModernIconLib.Asset.Icon;
using ModernIconLib.Configuration;
using ModernIconLib.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernIconLib.UI.Preview
{
    public partial class IconDrawSettingPanel : UserControl
    {
        /// <summary>
        /// クリップボードにコピーした後に呼ばれます。
        /// </summary>
        public event EventHandler ImageCopiedToClipboard;
        public IconDrawSettingPanel()
        {
            InitializeComponent();
        }

        public IconData IconData { get => _iconData; set => setIconData(value); }
        private IconData _iconData = null;

        public IconRenderParameter IconRenderParameter
        {
            get => _iconRenderParameter; set
            {
                this._iconRenderParameter = value;
                iconPreView.IconRenderParameter = value;
            }
        }
        private IconRenderParameter _iconRenderParameter = null;
        private void IconDrawSettingPanel_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                tableLayoutPanel1.Visible = true;
            updateSizeLabel();
            trackBarSize_Scroll(this, null);
        }

        private void panelColorFill_MouseDown(object sender, MouseEventArgs e)
        {
            using (var dialog = new Cyotek.Windows.Forms.ColorPickerDialog() { Color = panelColorFill.BackColor})
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    panelColorFill.BackColor = dialog.Color;
                    IconRenderParameter.FillColor = dialog.Color;
                    iconPreView.Refresh();
                }
            }
        }
        private void panelColorOutline_MouseDown(object sender, MouseEventArgs e)
        {
            using (var dialog = new Cyotek.Windows.Forms.ColorPickerDialog() { Color = panelColorOutline.BackColor})
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    panelColorOutline.BackColor = dialog.Color;
                    IconRenderParameter.OutlineColor = dialog.Color;
                    iconPreView.Refresh();
                }
            }

        }
        private void trackBarSize_Scroll(object sender, EventArgs e)
        {
            IconRenderParameter.IconSize = trackBarSize.Value * 16;
            iconPreView.Size = new Size(IconRenderParameter.IconSize, IconRenderParameter.IconSize);
            iconPreView.Refresh();
            updateSizeLabel();
        }
        private void updateSizeLabel()
        {
            if (IconRenderParameter != null)
                labelSize.Text = $"出力サイズ {IconRenderParameter.IconSize}x{IconRenderParameter.IconSize}";
        }


        private void checkBoxFill_CheckedChanged(object sender, EventArgs e)
        {
            IconRenderParameter.IsFill = checkBoxFill.Checked;
            iconPreView.Refresh();
        }

        private void checkBoxEdge_CheckedChanged(object sender, EventArgs e)
        {
            IconRenderParameter.HasOutline = checkBoxEdge.Checked;
            iconPreView.Refresh();
        }

        private void setIconData(IconData value)
        {
            tableLayoutPanel1.Visible = value != null;
            _iconData = value;
            iconPreView.IconData = value;
            iconPreView.Refresh();
            if (value != null)
                labelTitle.Text = value.IconCode.Name;
        }

        private void buttonCopyVector_Click(object sender, EventArgs e)
        {
            if (IconData == null)
                return;
            var renderer = getRenderer(IconData);
            var emfGraphics = new EmfVectorGraphics();
            using (Bitmap img = new Bitmap(IconRenderParameter.IconSize, IconRenderParameter.IconSize))
            {
                using (Graphics g = Graphics.FromImage(img))
                {
                    using (Graphics mg = emfGraphics.GetVectorRecording(g, img.Width, img.Height))
                    {
                        renderer.RenderIcon(mg, IconData.Font, IconData.IconCode, IconRenderParameter);
                    }
                    emfGraphics.SetClipboard();
                    ImageCopiedToClipboard?.Invoke(this, null);
                }
            }

        }

        private void buttonCopyBitmap_Click(object sender, EventArgs e)
        {
            if (IconData == null)
                return;
            var renderer = getRenderer(IconData);

            using (Bitmap img = new Bitmap(IconRenderParameter.IconSize, IconRenderParameter.IconSize))
            {
                using (Graphics g = Graphics.FromImage(img))
                {
                    renderer.RenderIcon(g, IconData.Font, IconData.IconCode, IconRenderParameter);
                }
                using (var ms = new MemoryStream())
                {
                    img.Save(ms, ImageFormat.Png);

                    //DataObjectオブジェクトを作成する
                    DataObject data = new DataObject("PNG", ms); //コンストラクタで指定しないとNG
                    //data.SetData("PNG", ms);
                    //Clipboard.SetImage(img);//SetImageだと透明度非対応

                    //PNG非対応アプリ向けに背景白色塗りつぶしのアイコンを別途セット
                    using (Graphics g = Graphics.FromImage(img))
                    {
                        g.Clear(Color.White);
                        renderer.RenderIcon(g, IconData.Font, IconData.IconCode, IconRenderParameter);
                    }
                    data.SetData(DataFormats.Bitmap, img);

                    Clipboard.SetDataObject(data, true);
                    ImageCopiedToClipboard?.Invoke(this, null);

                }
            }
        }

        public void SetStandaloneMode(bool value)
        {

        }
        private IIconRender getRenderer(IconData icon)
        {
            if (icon.Font.Name.Contains("Awesome"))
                return new IconBitmapFontAwesomeRender();
            if (icon.Font.Name.Contains("Segoe"))
                return new IconBitmapRenderSegoeMDL2();
            if (icon.Font.Name.Contains("Fluent"))
                return new IconBitmapRenderFluent();
            else
                return new IconBitmapRender();
        }

    }
}
