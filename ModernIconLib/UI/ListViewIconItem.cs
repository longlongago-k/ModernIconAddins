using ModernIconLib.Asset.Icon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernIconLib.UI
{
    /// <summary>
    /// リストビューアイテムクラス
    /// IconDataを持つ。それ以外は変更無し
    /// </summary>
    public class ListViewIconItem : ListViewItem
    {
        public IconData IconData { get; set; }
        public ListViewIconItem() { }

        public ListViewIconItem(string text) : base(text) { }

        public ListViewIconItem(string[] items) : base(items) { }

        public ListViewIconItem(ListViewGroup group) : base(group) { }

        public ListViewIconItem(string text, int imageIndex) : base(text, imageIndex) { }

        public ListViewIconItem(string[] items, int imageIndex) : base(items, imageIndex) { }

        public ListViewIconItem(ListViewSubItem[] subItems, int imageIndex) : base(subItems, imageIndex) { }

        public ListViewIconItem(string text, ListViewGroup group) : base(text, group) { }

        public ListViewIconItem(string[] items, ListViewGroup group) : base(items, group) { }

        public ListViewIconItem(string text, string imageKey) : base(text, imageKey) { }

        public ListViewIconItem(string[] items, string imageKey) : base(items, imageKey) { }

        public ListViewIconItem(ListViewSubItem[] subItems, string imageKey) : base(subItems, imageKey) { }

        public ListViewIconItem(string text, int imageIndex, ListViewGroup group) : base(text, imageIndex, group) { }

        public ListViewIconItem(string[] items, int imageIndex, ListViewGroup group) : base(items, imageIndex, group) { }

        public ListViewIconItem(ListViewSubItem[] subItems, int imageIndex, ListViewGroup group) : base(subItems, imageIndex, group) { }

        public ListViewIconItem(string text, string imageKey, ListViewGroup group) : base(text, imageKey, group) { }

        public ListViewIconItem(string[] items, string imageKey, ListViewGroup group) : base(items, imageKey, group) { }

        public ListViewIconItem(ListViewSubItem[] subItems, string imageKey, ListViewGroup group) : base(subItems, imageKey, group) { }

        public ListViewIconItem(string[] items, int imageIndex, Color foreColor, Color backColor, Font font) : base(items, imageIndex, foreColor, backColor, font) { }

        public ListViewIconItem(string[] items, string imageKey, Color foreColor, Color backColor, Font font) : base(items, imageKey, foreColor, backColor, font) { }

        public ListViewIconItem(string[] items, int imageIndex, Color foreColor, Color backColor, Font font, ListViewGroup group) : base(items, imageIndex, foreColor, backColor, font, group) { }

        public ListViewIconItem(string[] items, string imageKey, Color foreColor, Color backColor, Font font, ListViewGroup group) : base(items, imageKey, foreColor, backColor, font, group) { }

        protected ListViewIconItem(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
