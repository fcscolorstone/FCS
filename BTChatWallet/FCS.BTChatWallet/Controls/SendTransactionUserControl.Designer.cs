using Nethereum.UI.ViewModels;

namespace FCS.BTChatWallet.Controls
{
    partial class SendTransactionUserControl
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
            this.components = new System.ComponentModel.Container();
            this.btnSendTransaction = new System.Windows.Forms.Button();
            this.lblAmountInEther = new System.Windows.Forms.Label();
            this.lblToAddress = new System.Windows.Forms.Label();
            this.txtAmountInEther = new System.Windows.Forms.TextBox();
            this.txtToAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGasPrice = new System.Windows.Forms.TextBox();
            this.txtGas = new System.Windows.Forms.TextBox();
            this.errorProviderToAddress = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.lblNonce = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.txtNonce = new System.Windows.Forms.TextBox();
            this.transactionViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderToAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSendTransaction
            // 
            this.btnSendTransaction.Location = new System.Drawing.Point(202, 198);
            this.btnSendTransaction.Name = "btnSendTransaction";
            this.btnSendTransaction.Size = new System.Drawing.Size(208, 32);
            this.btnSendTransaction.TabIndex = 22;
            this.btnSendTransaction.Text = "Ethereum交易";
            this.btnSendTransaction.UseVisualStyleBackColor = true;
            // 
            // lblAmountInEther
            // 
            this.lblAmountInEther.AutoSize = true;
            this.lblAmountInEther.Location = new System.Drawing.Point(16, 46);
            this.lblAmountInEther.Name = "lblAmountInEther";
            this.lblAmountInEther.Size = new System.Drawing.Size(35, 12);
            this.lblAmountInEther.TabIndex = 21;
            this.lblAmountInEther.Text = "数量:";
            // 
            // lblToAddress
            // 
            this.lblToAddress.AutoSize = true;
            this.lblToAddress.Location = new System.Drawing.Point(16, 17);
            this.lblToAddress.Name = "lblToAddress";
            this.lblToAddress.Size = new System.Drawing.Size(59, 12);
            this.lblToAddress.TabIndex = 20;
            this.lblToAddress.Text = "收款地址:";
            // 
            // txtAmountInEther
            // 
            this.txtAmountInEther.Font = new System.Drawing.Font("宋体", 10F);
            this.txtAmountInEther.Location = new System.Drawing.Point(108, 42);
            this.txtAmountInEther.Name = "txtAmountInEther";
            this.txtAmountInEther.Size = new System.Drawing.Size(316, 23);
            this.txtAmountInEther.TabIndex = 19;
            // 
            // txtToAddress
            // 
            this.txtToAddress.Font = new System.Drawing.Font("宋体", 10F);
            this.txtToAddress.Location = new System.Drawing.Point(108, 13);
            this.txtToAddress.Name = "txtToAddress";
            this.txtToAddress.Size = new System.Drawing.Size(316, 23);
            this.txtToAddress.TabIndex = 18;
            this.txtToAddress.Validating += new System.ComponentModel.CancelEventHandler(this.txtToAddress_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "Gas价格:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 25;
            this.label2.Text = "Gas:";
            // 
            // txtGasPrice
            // 
            this.txtGasPrice.Font = new System.Drawing.Font("宋体", 10F);
            this.txtGasPrice.Location = new System.Drawing.Point(108, 104);
            this.txtGasPrice.Name = "txtGasPrice";
            this.txtGasPrice.Size = new System.Drawing.Size(316, 23);
            this.txtGasPrice.TabIndex = 24;
            // 
            // txtGas
            // 
            this.txtGas.Font = new System.Drawing.Font("宋体", 10F);
            this.txtGas.Location = new System.Drawing.Point(108, 73);
            this.txtGas.Name = "txtGas";
            this.txtGas.Size = new System.Drawing.Size(316, 23);
            this.txtGas.TabIndex = 23;
            // 
            // errorProviderToAddress
            // 
            this.errorProviderToAddress.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "Data (可选):";
            // 
            // lblNonce
            // 
            this.lblNonce.AutoSize = true;
            this.lblNonce.Location = new System.Drawing.Point(16, 137);
            this.lblNonce.Name = "lblNonce";
            this.lblNonce.Size = new System.Drawing.Size(83, 12);
            this.lblNonce.TabIndex = 30;
            this.lblNonce.Text = "Nonce (可选):";
            // 
            // txtData
            // 
            this.txtData.Font = new System.Drawing.Font("宋体", 10F);
            this.txtData.Location = new System.Drawing.Point(108, 163);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(316, 23);
            this.txtData.TabIndex = 29;
            // 
            // txtNonce
            // 
            this.txtNonce.Font = new System.Drawing.Font("宋体", 10F);
            this.txtNonce.Location = new System.Drawing.Point(108, 133);
            this.txtNonce.Name = "txtNonce";
            this.txtNonce.Size = new System.Drawing.Size(316, 23);
            this.txtNonce.TabIndex = 28;
            // 
            // transactionViewModelBindingSource
            // 
            this.transactionViewModelBindingSource.DataSource = typeof(Nethereum.UI.ViewModels.TransactionViewModel);
            // 
            // SendTransactionUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNonce);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.txtNonce);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGasPrice);
            this.Controls.Add(this.txtGas);
            this.Controls.Add(this.btnSendTransaction);
            this.Controls.Add(this.lblAmountInEther);
            this.Controls.Add(this.lblToAddress);
            this.Controls.Add(this.txtAmountInEther);
            this.Controls.Add(this.txtToAddress);
            this.Name = "SendTransactionUserControl";
            this.Size = new System.Drawing.Size(434, 245);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderToAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendTransaction;
        private System.Windows.Forms.Label lblAmountInEther;
        private System.Windows.Forms.Label lblToAddress;
        private System.Windows.Forms.TextBox txtAmountInEther;
        private System.Windows.Forms.TextBox txtToAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGasPrice;
        private System.Windows.Forms.TextBox txtGas;
        private System.Windows.Forms.ErrorProvider errorProviderToAddress;
        private System.Windows.Forms.BindingSource transactionViewModelBindingSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNonce;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.TextBox txtNonce;
    }
}
