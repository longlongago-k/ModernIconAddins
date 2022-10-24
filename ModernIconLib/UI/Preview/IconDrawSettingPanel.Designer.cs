namespace ModernIconLib.UI.Preview
{
    partial class IconDrawSettingPanel
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelColorFill = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxFill = new System.Windows.Forms.CheckBox();
            this.checkBoxEdge = new System.Windows.Forms.CheckBox();
            this.panelColorOutline = new System.Windows.Forms.Panel();
            this.labelSize = new System.Windows.Forms.Label();
            this.trackBarSize = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonCopyVector = new System.Windows.Forms.Button();
            this.buttonCopyBitmap = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.iconPreView = new ModernIconLib.UI.Preview.IconPreView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelColorFill
            // 
            this.panelColorFill.BackColor = System.Drawing.Color.DimGray;
            this.panelColorFill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelColorFill.Location = new System.Drawing.Point(201, 15);
            this.panelColorFill.Name = "panelColorFill";
            this.panelColorFill.Size = new System.Drawing.Size(76, 24);
            this.panelColorFill.TabIndex = 1;
            this.panelColorFill.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColorFill_MouseDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.37407F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.62593F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelTitle, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonExport, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonCopyVector, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonCopyBitmap, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(402, 513);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panelColorFill, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxFill, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxEdge, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panelColorOutline, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelSize, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.trackBarSize, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label4, 1, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(396, 331);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "出力設定";
            // 
            // checkBoxFill
            // 
            this.checkBoxFill.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxFill.AutoSize = true;
            this.checkBoxFill.Checked = true;
            this.checkBoxFill.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFill.Location = new System.Drawing.Point(3, 19);
            this.checkBoxFill.Name = "checkBoxFill";
            this.checkBoxFill.Size = new System.Drawing.Size(72, 16);
            this.checkBoxFill.TabIndex = 3;
            this.checkBoxFill.Text = "塗りつぶし";
            this.checkBoxFill.UseVisualStyleBackColor = true;
            this.checkBoxFill.CheckedChanged += new System.EventHandler(this.checkBoxFill_CheckedChanged);
            // 
            // checkBoxEdge
            // 
            this.checkBoxEdge.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxEdge.AutoSize = true;
            this.checkBoxEdge.Location = new System.Drawing.Point(3, 49);
            this.checkBoxEdge.Name = "checkBoxEdge";
            this.checkBoxEdge.Size = new System.Drawing.Size(48, 16);
            this.checkBoxEdge.TabIndex = 3;
            this.checkBoxEdge.Text = "輪郭";
            this.checkBoxEdge.UseVisualStyleBackColor = true;
            this.checkBoxEdge.CheckedChanged += new System.EventHandler(this.checkBoxEdge_CheckedChanged);
            // 
            // panelColorOutline
            // 
            this.panelColorOutline.BackColor = System.Drawing.Color.Black;
            this.panelColorOutline.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelColorOutline.Location = new System.Drawing.Point(201, 45);
            this.panelColorOutline.Name = "panelColorOutline";
            this.panelColorOutline.Size = new System.Drawing.Size(76, 24);
            this.panelColorOutline.TabIndex = 1;
            this.panelColorOutline.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColorOutline_MouseDown);
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(3, 75);
            this.labelSize.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(58, 12);
            this.labelSize.TabIndex = 2;
            this.labelSize.Text = "出力サイズ";
            // 
            // trackBarSize
            // 
            this.trackBarSize.AutoSize = false;
            this.tableLayoutPanel2.SetColumnSpan(this.trackBarSize, 2);
            this.trackBarSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBarSize.LargeChange = 1;
            this.trackBarSize.Location = new System.Drawing.Point(3, 110);
            this.trackBarSize.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.trackBarSize.Maximum = 16;
            this.trackBarSize.Minimum = 1;
            this.trackBarSize.MinimumSize = new System.Drawing.Size(50, 30);
            this.trackBarSize.Name = "trackBarSize";
            this.trackBarSize.Size = new System.Drawing.Size(390, 45);
            this.trackBarSize.SmallChange = 16;
            this.trackBarSize.TabIndex = 4;
            this.trackBarSize.Value = 4;
            this.trackBarSize.Scroll += new System.EventHandler(this.trackBarSize_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "16px";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(358, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "256px";
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelTitle.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelTitle, 2);
            this.labelTitle.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelTitle.Location = new System.Drawing.Point(175, 337);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(52, 16);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "label5";
            // 
            // buttonExport
            // 
            this.buttonExport.AutoSize = true;
            this.buttonExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExport.Location = new System.Drawing.Point(207, 438);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(5);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(190, 30);
            this.buttonExport.TabIndex = 5;
            this.buttonExport.Text = "ファイルに保存";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Visible = false;
            // 
            // buttonCopyVector
            // 
            this.buttonCopyVector.AutoSize = true;
            this.buttonCopyVector.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonCopyVector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCopyVector.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonCopyVector.Location = new System.Drawing.Point(5, 478);
            this.buttonCopyVector.Margin = new System.Windows.Forms.Padding(5);
            this.buttonCopyVector.Name = "buttonCopyVector";
            this.buttonCopyVector.Size = new System.Drawing.Size(192, 30);
            this.buttonCopyVector.TabIndex = 5;
            this.buttonCopyVector.Text = "コピー(図形)";
            this.buttonCopyVector.UseVisualStyleBackColor = false;
            this.buttonCopyVector.Click += new System.EventHandler(this.buttonCopyVector_Click);
            // 
            // buttonCopyBitmap
            // 
            this.buttonCopyBitmap.AutoSize = true;
            this.buttonCopyBitmap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCopyBitmap.Location = new System.Drawing.Point(207, 478);
            this.buttonCopyBitmap.Margin = new System.Windows.Forms.Padding(5);
            this.buttonCopyBitmap.Name = "buttonCopyBitmap";
            this.buttonCopyBitmap.Size = new System.Drawing.Size(190, 30);
            this.buttonCopyBitmap.TabIndex = 5;
            this.buttonCopyBitmap.Text = "コピー(画像)";
            this.buttonCopyBitmap.UseVisualStyleBackColor = true;
            this.buttonCopyBitmap.Click += new System.EventHandler(this.buttonCopyBitmap_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.iconPreView, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 356);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(396, 74);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // iconPreView
            // 
            this.iconPreView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconPreView.IconData = null;
            this.iconPreView.IconRenderParameter = null;
            this.iconPreView.Location = new System.Drawing.Point(166, 5);
            this.iconPreView.Name = "iconPreView";
            this.iconPreView.ShowPlusRuler = false;
            this.iconPreView.Size = new System.Drawing.Size(64, 64);
            this.iconPreView.TabIndex = 0;
            // 
            // IconDrawSettingPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "IconDrawSettingPanel";
            this.Size = new System.Drawing.Size(402, 513);
            this.Load += new System.EventHandler(this.IconDrawSettingPanel_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IconPreView iconPreView;
        private System.Windows.Forms.Panel panelColorFill;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxFill;
        private System.Windows.Forms.CheckBox checkBoxEdge;
        private System.Windows.Forms.Panel panelColorOutline;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.TrackBar trackBarSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonCopyVector;
        private System.Windows.Forms.Button buttonCopyBitmap;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}
