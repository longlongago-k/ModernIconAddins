using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ModernIconLib.Rendering
{
    /// <summary>
    /// Emf取り扱いクラス。WindowsAPIをインポートする
    /// </summary>
    class EmfVectorGraphics
    {
        [DllImport("gdi32.dll")]
        private extern static IntPtr CopyEnhMetaFile(IntPtr hemfSrc, IntPtr hNULL);
        [DllImport("user32.dll")]
        private extern static bool OpenClipboard(IntPtr hWndNewOwner);
        [DllImport("user32.dll")]
        private extern static bool EmptyClipboard();
        [DllImport("user32.dll")]
        private extern static IntPtr SetClipboardData(uint uFormat, IntPtr hMem);
        [DllImport("user32.dll")]
        private extern static bool CloseClipboard();
        [DllImport("gdi32.dll")]
        private extern static bool DeleteEnhMetaFile(IntPtr hemf);
        private System.Drawing.Imaging.Metafile meta;
        public Graphics GetVectorRecording(Graphics g, int width, int height)
        {
            IntPtr hdc = g.GetHdc();
            Rectangle rec = new Rectangle(0, 0, width, height);
            this.meta = new System.Drawing.Imaging.Metafile(hdc, rec, System.Drawing.Imaging.MetafileFrameUnit.Pixel, System.Drawing.Imaging.EmfType.EmfOnly);
            g.ReleaseHdc(hdc);
            g.Dispose();

            Graphics mg = Graphics.FromImage(meta);
            mg.SetClip(new RectangleF(0, 0, width, height));
            mg.PageUnit = GraphicsUnit.Pixel;
            return mg;

            //Clipboard::SetImage(outputImage);
        }

        public void SetClipboard()
        {
            if (meta == null)
                return;
            IntPtr hEmf = meta.GetHenhmetafile();
            if (!hEmf.Equals(new IntPtr(0)))
            {
                IntPtr hEmf2 = CopyEnhMetaFile(hEmf, IntPtr.Zero);
                if (!hEmf2.Equals(new IntPtr(0)))
                {
                    if (OpenClipboard(IntPtr.Zero))
                    {
                        if (EmptyClipboard())
                        {
                            IntPtr hRes = SetClipboardData(14, hEmf2);
                            hRes.Equals(hEmf2);
                            CloseClipboard();
                        }
                    }
                }
                DeleteEnhMetaFile(hEmf);
            }
            meta.Dispose();
            meta = null;
        }
    }

}
