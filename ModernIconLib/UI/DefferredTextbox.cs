using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernIconLib.UI
{
    /// <summary>
    /// 遅延つきテキストボックス(未実装)
    /// Throttleによりインクリメンタルサーチ時の応答改善に使用される。
    /// </summary>
    public partial class DefferredTextbox : TextBox
    {
        public DefferredTextbox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void DefferredTextbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
