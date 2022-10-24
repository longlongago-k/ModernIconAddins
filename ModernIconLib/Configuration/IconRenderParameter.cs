using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernIconLib.Configuration
{
    /// <summary>
    /// アイコン設定ファイル
    /// </summary>
    public  class IconRenderParameter
    {
        public  int IconSize { get; set; } = 64;
        public  bool IsFill { get; set; } = true;
        public  bool HasOutline { get; set; } = false;
        public  int OutlineWidth { get; set; } = 1;

        public  Color FillColor { get; set; } = Color.DimGray;
        public  Color OutlineColor { get; set; } = Color.Black;

    }
}
