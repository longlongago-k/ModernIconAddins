
namespace ModernIconExcelAddin
{
    partial class ModernIconForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.iconVIewer1 = new ModernIconLib.UI.IconVIewer();
            this.SuspendLayout();
            // 
            // iconVIewer1
            // 
            this.iconVIewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconVIewer1.Location = new System.Drawing.Point(0, 0);
            this.iconVIewer1.Name = "iconVIewer1";
            this.iconVIewer1.Size = new System.Drawing.Size(984, 446);
            this.iconVIewer1.TabIndex = 0;
            this.iconVIewer1.ImageCopiedToClipboard += new System.EventHandler(this.iconVIewer1_ImageCopiedToClipboard);
            // 
            // ModernIconForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 446);
            this.Controls.Add(this.iconVIewer1);
            this.Name = "ModernIconForm";
            this.Text = "モダンアイコン";
            this.ResumeLayout(false);

        }

        #endregion

        private ModernIconLib.UI.IconVIewer iconVIewer1;
    }
}