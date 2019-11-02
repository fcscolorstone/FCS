namespace FCS.BTChatWallet
{
    partial class PrivateKeyAccountLoaderUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoadAccountFromPrivateKey = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrivateKey = new System.Windows.Forms.TextBox();
            this.fileOpenerKeyStore = new System.Windows.Forms.OpenFileDialog();
            this.btnExportPK = new System.Windows.Forms.Button();
            this.lb_export_pk = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLoadAccountFromPrivateKey
            // 
            this.btnLoadAccountFromPrivateKey.Location = new System.Drawing.Point(12, 53);
            this.btnLoadAccountFromPrivateKey.Name = "btnLoadAccountFromPrivateKey";
            this.btnLoadAccountFromPrivateKey.Size = new System.Drawing.Size(192, 30);
            this.btnLoadAccountFromPrivateKey.TabIndex = 17;
            this.btnLoadAccountFromPrivateKey.Text = "从私钥导入账户";
            this.btnLoadAccountFromPrivateKey.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "私钥:";
            // 
            // txtPrivateKey
            // 
            this.txtPrivateKey.Font = new System.Drawing.Font("宋体", 10F);
            this.txtPrivateKey.Location = new System.Drawing.Point(49, 13);
            this.txtPrivateKey.Name = "txtPrivateKey";
            this.txtPrivateKey.Size = new System.Drawing.Size(341, 23);
            this.txtPrivateKey.TabIndex = 13;
            // 
            // btnExportPK
            // 
            this.btnExportPK.Location = new System.Drawing.Point(226, 53);
            this.btnExportPK.Name = "btnExportPK";
            this.btnExportPK.Size = new System.Drawing.Size(164, 30);
            this.btnExportPK.TabIndex = 18;
            this.btnExportPK.Text = "导出私钥";
            this.btnExportPK.UseVisualStyleBackColor = true;
            // 
            // lb_export_pk
            // 
            this.lb_export_pk.ForeColor = System.Drawing.Color.OrangeRed;
            this.lb_export_pk.Location = new System.Drawing.Point(12, 86);
            this.lb_export_pk.Name = "lb_export_pk";
            this.lb_export_pk.Padding = new System.Windows.Forms.Padding(10);
            this.lb_export_pk.Size = new System.Drawing.Size(378, 98);
            this.lb_export_pk.TabIndex = 19;
            this.lb_export_pk.Text = "1112222222222222222223";
            // 
            // PrivateKeyAccountLoaderUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_export_pk);
            this.Controls.Add(this.btnExportPK);
            this.Controls.Add(this.btnLoadAccountFromPrivateKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPrivateKey);
            this.Name = "PrivateKeyAccountLoaderUserControl";
            this.Size = new System.Drawing.Size(406, 245);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadAccountFromPrivateKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrivateKey;
        private System.Windows.Forms.OpenFileDialog fileOpenerKeyStore;
        private System.Windows.Forms.Button btnExportPK;
        private System.Windows.Forms.Label lb_export_pk;
    }
}
