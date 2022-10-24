using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModernIconPowerPointAddin
{
    public partial class Ribbon
    {
        ModernIconForm form = null;
        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void button1ModernIcon_Click(object sender, RibbonControlEventArgs e)
        {
            if (form != null)
            {
                form.Activate();
                return;
            }
            form = new ModernIconForm();
            form.FormClosed += (s , _) => form = null;
            form.ImageCopiedToClipboard += (s, _) => paste();
            form.Show();
        }

        private void paste()
        {
            var presentation = Globals.ThisAddIn.Application.ActivePresentation;
            var slide = (Microsoft.Office.Interop.PowerPoint.Slide)Globals.ThisAddIn.Application.ActiveWindow.View.Slide;
            slide.Shapes.Paste();
        }
    }
}
