using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernIconPowerPointAddin
{
    public partial class ModernIconForm : Form
    {
        public event EventHandler ImageCopiedToClipboard;

        public ModernIconForm()
        {
            InitializeComponent();
        }

        private void iconVIewer1_ImageCopiedToClipboard(object sender, EventArgs e)
        {
            ImageCopiedToClipboard?.Invoke(sender, e);
        }
    }
}
