using ModernIconLib.Asset;
using ModernIconLib.Asset.Icon;
using ModernIconLib.Configuration;
using ModernIconLib.Rendering;
using ModernIconLib.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernIconLib.UI
{
    public partial class IconVIewer : UserControl
    {
        public event EventHandler ImageCopiedToClipboard;

        private IconSetAsset currentAsset = null;
        private IconRenderParameter renderPaream = new IconRenderParameter();
        private ListViewIconItem[] itemList = Array.Empty<ListViewIconItem>();
        private ListViewIconItem[] itemListFiltered = Array.Empty<ListViewIconItem>();

        public IconVIewer()
        {
            InitializeComponent();
            //pictureBoxBg.MouseWheel += PictureBoxBg_MouseWheel;
            iconDrawSettingPanel.IconRenderParameter = renderPaream;
            typeof(System.Windows.Forms.ListView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, listViewIcon, new object[] { true });
        }
        private void IconVIewer_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            var asset_google = GoogleMaterialIconAssetReader.ReadFromResource();
            var asset_pictgrammer = PictogrammersMaterialIconAssetReader.ReadFromResource();
            var asset_fontawesome = FontAwesomeIconAssetReader.ReadFromResource();
            var asset_segoemdl2 = SegoeUIMDL2AssetReader.ReadFromResource();
            SetAssets(asset_google.Concat(asset_pictgrammer).Concat(asset_fontawesome).Concat(asset_segoemdl2).ToArray());

        }

        public void SetAssets(IconSetAsset[] assets)
        {
            if (assets.Length == 0)
                return;

            comboBoxAssets.Items.AddRange(assets);
            comboBoxAssets.SelectedIndex = 0;

        }

        private void comboBoxAssets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAssets.SelectedIndex < 0)
                return;
            if (comboBoxAssets.SelectedItem is IconSetAsset == false)
                return;
            iconDrawSettingPanel.IconData = null;
            currentAsset = (IconSetAsset)comboBoxAssets.SelectedItem;
            comboBoxAssets.Enabled = false;
            textBoxSearch.Enabled = false;
            //progressBar.Value = 0;
            //progressBar.Visible = true;
            listViewIcon.TileSize = new Size(64 + 150, 64);
            listViewIcon.Items.Clear();
            IIconDataRender render;
            if (currentAsset.AssetName.Contains("Font Awesome"))
                render = new IconBitmapListViewFontAwesomeRender();
            else if (currentAsset.AssetName.Contains("Segoe"))
                render = new IconBitmapListViewRenderSegoeMDL2();
            else
                render = new IconBitmapListViewRender();

            currentAsset.CreateIconImageList(render, renderPaream);
            Parallel.ForEach(currentAsset.IconImageList, icon => icon.CreateIconCache());
            setImageList();
            comboBoxAssets.Enabled = true;
            textBoxSearch.Enabled = true;
        }

        private void setImageList()
        {
            itemList = currentAsset.IconImageList
                .Select(icon =>
                new ListViewIconItem(new string[]{
                    icon.IconCode.Name.ToString(),
                    icon.IconCode.Code.ToString("X")
                },
                currentAsset.IconCodeIdxDic[icon.IconCode]
                )
                { IconData = icon})
                .ToArray();
            
            filterItems(textBoxSearch.Text);
            //listViewIcon.Items.AddRange(itemList.ToArray());
        }


        //private void radioButtonTileView_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (radioButtonListView.Checked)
        //        listViewIcon.View = View.Details;
        //    else if (radioButtonTileView.Checked)
        //        listViewIcon.View = View.Tile;
        //    //else if (radioButtonTile2.Checked)
        //    //    currentDrawer = tileDetailViewDrawer;
        //    //updateScrollParameter();
        //    //pictureBoxBg.Invalidate();
        //}

        private void listViewIcon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewIcon.SelectedItems.Count == 0)
                return;
            if (listViewIcon.SelectedItems[0] is ListViewIconItem item)
                iconDrawSettingPanel.IconData = item.IconData;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            filterItems(textBoxSearch.Text);
        }

        private void filterItems(string text)
        {
            if (string.IsNullOrEmpty(text))
                itemListFiltered = itemList.ToArray();
            itemListFiltered = itemList.Where(item => 
                item.IconData.IconCode.Name.Contains(text, StringComparison.OrdinalIgnoreCase) |
                item.IconData.IconCode.Cateogy.Any(cat => cat.Contains(text, StringComparison.OrdinalIgnoreCase)) |
                item.IconData.IconCode.Tags.Any(cat => cat.Contains(text, StringComparison.OrdinalIgnoreCase))
                ).ToArray();
            listViewIcon.Items.Clear();
            listViewIcon.Items.AddRange(itemListFiltered);

        }

        private void iconDrawSettingPanel_ImageCopiedToClipboard(object sender, EventArgs e)
        {
            ImageCopiedToClipboard?.Invoke(sender, e);
        }

        /// <summary>
        /// ListViewのオーナードローメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewIcon_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            //Tileモード飲み対応
            if (listViewIcon.View != View.Tile)
            {
                e.DrawDefault = true;
                return;
            }
            bool isSelected = e.Item.Selected;//Stateプロパティはトリッキーなので使用しない事
            e.DrawBackground();

            var item = ((ListViewIconItem)e.Item);
            Rectangle imageRect = new Rectangle(e.Bounds.X, e.Bounds.Y, 64, 64);
            Rectangle imageRectInner = imageRect;
            imageRectInner.Inflate(-3,-3); ;
            imageRectInner.Offset(-1, -1);
            RectangleF textRect = new RectangleF(e.Bounds.X + imageRect.Width, e.Bounds.Y, e.Bounds.Width - imageRect.Width, e.Bounds.Height);
            e.Graphics.DrawImage(item.IconData.IconImage, imageRect);
            var sf = new StringFormat() {  LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter, FormatFlags = StringFormatFlags.NoWrap};
            //アイテム選択時
            if (isSelected)
            {
                //青色の四角形等で描画
                using (var b = new SolidBrush(SystemColors.Highlight))
                    e.Graphics.FillRectangle(b, textRect);
                //テキストを描画
                using (var b = new SolidBrush(SystemColors.HighlightText))
                    drawListViewItemText(e, item, b, b, textRect, sf);
                //アイコンの淵部分を描画
                using (var p = new Pen(SystemColors.Highlight, 2f))
                    e.Graphics.DrawRectangle(p, imageRectInner);
               e.DrawFocusRectangle();
            }
            else
            {
                drawListViewItemText(e, item, Brushes.Black, Brushes.Gray, textRect, sf);
            }


        }

        /// <summary>
        /// ListViewのオーナードローで、アイコンのテキスト部分を描画する
        /// </summary>
        /// <param name="e"></param>
        /// <param name="item"></param>
        /// <param name="brushPrimary">タイトル色</param>
        /// <param name="brushSecondary">タグ・カテゴリ等描画色</param>
        /// <param name="textRect"></param>
        /// <param name="sf"></param>
        private void drawListViewItemText(DrawListViewItemEventArgs e, ListViewIconItem item, Brush brushPrimary, Brush brushSecondary,
            RectangleF textRect, StringFormat sf)
        {
            //カテゴリーを持つ場合は3行
            bool hasCategory = item.IconData.IconCode.Cateogy.Length > 0;
            if (hasCategory)
            {
                e.Graphics.DrawString(item.IconData.IconCode.Name + "\r\n\r\n ", listViewIcon.Font, brushPrimary, textRect, sf);
                e.Graphics.DrawString("\r\n" + string.Join(",", item.IconData.IconCode.Cateogy) + "\r\n ", listViewIcon.Font, brushSecondary, textRect, sf);
                e.Graphics.DrawString("\r\n\r\n" + item.IconData.IconCode.Code.ToString("X"), listViewIcon.Font, brushSecondary, textRect, sf);
            }
            else//カテゴリー持たない場合は2行
            {
                e.Graphics.DrawString(item.IconData.IconCode.Name + "\r\n ", listViewIcon.Font, brushPrimary, textRect, sf);
                e.Graphics.DrawString("\r\n" + item.IconData.IconCode.Code.ToString("X"), listViewIcon.Font, brushSecondary, textRect, sf);
            }
        }

        private void listViewIcon_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
                e.DrawDefault = true;

        }

        private void listViewIcon_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void listViewIcon_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            Parallel.ForEach(currentAsset.IconImageList, icon => icon.CreateIconCache());
            listViewIcon.Invalidate();
        }
    }
}
