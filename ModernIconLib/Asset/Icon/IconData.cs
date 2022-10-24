using ModernIconLib.Configuration;
using ModernIconLib.Rendering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernIconLib.Asset.Icon
{
    /// <summary>
    /// アイコンデータ クラス
    /// </summary>
    public class IconData : IDisposable
    {
        /// <summary>
        /// アイコンコード
        /// </summary>
        public IconCode IconCode { get; set; }
        /// <summary>
        /// フォントデータ
        /// </summary>
        public FontFamily Font { get; set; }
        /// <summary>
        /// アイコンキャッシュ画像
        /// CreateIconCache()が呼ばれるまではNull
        /// </summary>
        public Bitmap IconImage { get; set; }

        private IIconDataRender render;
        private IconRenderParameter renderParam;
        public IconData(IconCode iconCode, FontFamily font)
        {
            IconCode = iconCode ?? throw new ArgumentNullException(nameof(iconCode));
            Font = font ?? throw new ArgumentNullException(nameof(font));
        }

        public IconData(IconCode iconCode, FontFamily font, IIconDataRender render, IconRenderParameter renderParam) : this(iconCode, font)
        {
            this.render = render;
            this.renderParam = renderParam;
        }

        public void CreateIconCache()
        {
            IconImage?.Dispose();
            IconImage = render.RenderIcon(Font, IconCode, renderParam);
        }
        public void Dispose()
        {
            IconCode = null;
            IconImage?.Dispose();
            render = null;
            renderParam = null;
        }
    }
}
