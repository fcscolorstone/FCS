namespace FCS.BTChatWallet.Controls.StandardToken
{
    partial class StandardTokenContractAddressUserControl
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
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtContractAddress = new System.Windows.Forms.TextBox();
            this.lblDecimals = new System.Windows.Forms.Label();
            this.txtDecimals = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(9, 15);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(59, 12);
            this.lblAddress.TabIndex = 22;
            this.lblAddress.Text = "合约地址:";
            // 
            // txtContractAddress
            // 
            this.txtContractAddress.Font = new System.Drawing.Font("宋体", 10F);
            this.txtContractAddress.Location = new System.Drawing.Point(78, 10);
            this.txtContractAddress.Name = "txtContractAddress";
            this.txtContractAddress.Size = new System.Drawing.Size(350, 23);
            this.txtContractAddress.TabIndex = 21;
            // 
            // lblDecimals
            // 
            this.lblDecimals.AutoSize = true;
            this.lblDecimals.Location = new System.Drawing.Point(33, 50);
            this.lblDecimals.Name = "lblDecimals";
            this.lblDecimals.Size = new System.Drawing.Size(35, 12);
            this.lblDecimals.TabIndex = 23;
            this.lblDecimals.Text = "精度:";
            // 
            // txtDecimals
            // 
            this.txtDecimals.Font = new System.Drawing.Font("宋体", 10F);
            this.txtDecimals.Location = new System.Drawing.Point(78, 44);
            this.txtDecimals.Name = "txtDecimals";
            this.txtDecimals.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDecimals.Size = new System.Drawing.Size(350, 23);
            this.txtDecimals.TabIndex = 24;
            this.txtDecimals.Text = "18";
            // 
            // StandardTokenContractAddressUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtDecimals);
            this.Controls.Add(this.lblDecimals);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtContractAddress);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StandardTokenContractAddressUserControl";
            this.Size = new System.Drawing.Size(438, 78);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtContractAddress;
        private System.Windows.Forms.Label lblDecimals;
        private System.Windows.Forms.TextBox txtDecimals;
    }
}
