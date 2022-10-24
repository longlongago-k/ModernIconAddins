namespace ModernIconLib.UI
{
    partial class DefferredTextbox
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
            this.components = new System.ComponentModel.Container();
            this.timerInput = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerInput
            // 
            this.timerInput.Interval = 300;
            // 
            // DefferredTextbox
            // 
            this.TextChanged += new System.EventHandler(this.DefferredTextbox_TextChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerInput;
    }
}
