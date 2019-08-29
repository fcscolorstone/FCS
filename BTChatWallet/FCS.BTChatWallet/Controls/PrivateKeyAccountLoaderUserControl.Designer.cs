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
            this.SuspendLayout();
            // 
            // btnLoadAccountFromPrivateKey
            // 
            this.btnLoadAccountFromPrivateKey.Location = new System.Drawing.Point(198, 52);
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
            // PrivateKeyAccountLoaderUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLoadAccountFromPrivateKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPrivateKey);
            this.Name = "PrivateKeyAccountLoaderUserControl";
            this.Size = new System.Drawing.Size(406, 96);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadAccountFromPrivateKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrivateKey;
        private System.Windows.Forms.OpenFileDialog fileOpenerKeyStore;
    }
}
