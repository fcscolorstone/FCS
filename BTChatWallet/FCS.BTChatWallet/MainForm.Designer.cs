namespace FCS.BTChatWallet
{
    partial class MainForm
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
            this.txtCurrentAccount = new System.Windows.Forms.TextBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lblPrivateKey = new System.Windows.Forms.Label();
            this.txtPrivateKey = new System.Windows.Forms.TextBox();
            this.btnRefreshBalance = new System.Windows.Forms.Button();
            this.lblAccountBalance = new System.Windows.Forms.Label();
            this.lblTextAccountBalance = new System.Windows.Forms.Label();
            this.fileOpenerKeyStore = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textAccount = new System.Windows.Forms.TextBox();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.cmbUrl = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageTransactions = new System.Windows.Forms.TabPage();
            this.panelSendTransactionStandardToken = new System.Windows.Forms.Panel();
            this.gbStandardToken = new System.Windows.Forms.GroupBox();
            this.standardTokenTransferUserControl1 = new FCS.BTChatWallet.Controls.StandardToken.StandardTokenTransferUserControl();
            this.standardTokenBalanceOfUserControl1 = new FCS.BTChatWallet.Controls.StandardToken.StandardTokenBalanceOfUserControl();
            this.standardTokenContractAddressUserControl1 = new FCS.BTChatWallet.Controls.StandardToken.StandardTokenContractAddressUserControl();
            this.gbTransfer = new System.Windows.Forms.GroupBox();
            this.transferUserControl1 = new FCS.BTChatWallet.Controls.SendTransactionUserControl();
            this.transactionsUserControl1 = new FCS.BTChatWallet.Controls.TransactionsUserControl();
            this.tabStepMainLoadAccount = new System.Windows.Forms.TabPage();
            this.tabPageLoadAccount = new System.Windows.Forms.TabControl();
            this.tabPageLoadAccountFromFile = new System.Windows.Forms.TabPage();
            this.keystoreAccountLoaderUserControl3 = new FCS.BTChatWallet.KeystoreAccountLoaderUserControl();
            this.tabPageHdWallet = new System.Windows.Forms.TabPage();
            this.hdWalletAccountLoaderUserControl1 = new FCS.BTChatWallet.Controls.HDWalletAccountLoaderUserControl();
            this.tabPageLoadAccountFromPrivateKey = new System.Windows.Forms.TabPage();
            this.privateKeyAccountLoaderUserControl1 = new FCS.BTChatWallet.PrivateKeyAccountLoaderUserControl();
            this.tabSteps = new System.Windows.Forms.TabControl();
            this.panel1.SuspendLayout();
            this.tabPageTransactions.SuspendLayout();
            this.panelSendTransactionStandardToken.SuspendLayout();
            this.gbStandardToken.SuspendLayout();
            this.gbTransfer.SuspendLayout();
            this.tabStepMainLoadAccount.SuspendLayout();
            this.tabPageLoadAccount.SuspendLayout();
            this.tabPageLoadAccountFromFile.SuspendLayout();
            this.tabPageHdWallet.SuspendLayout();
            this.tabPageLoadAccountFromPrivateKey.SuspendLayout();
            this.tabSteps.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCurrentAccount
            // 
            this.txtCurrentAccount.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtCurrentAccount.Location = new System.Drawing.Point(127, 16);
            this.txtCurrentAccount.Name = "txtCurrentAccount";
            this.txtCurrentAccount.ReadOnly = true;
            this.txtCurrentAccount.Size = new System.Drawing.Size(396, 21);
            this.txtCurrentAccount.TabIndex = 0;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(29, 18);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(59, 12);
            this.lblAccount.TabIndex = 1;
            this.lblAccount.Text = "账户地址:";
            // 
            // lblPrivateKey
            // 
            this.lblPrivateKey.AutoSize = true;
            this.lblPrivateKey.Location = new System.Drawing.Point(29, 42);
            this.lblPrivateKey.Name = "lblPrivateKey";
            this.lblPrivateKey.Size = new System.Drawing.Size(35, 12);
            this.lblPrivateKey.TabIndex = 2;
            this.lblPrivateKey.Text = "私钥:";
            // 
            // txtPrivateKey
            // 
            this.txtPrivateKey.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtPrivateKey.Location = new System.Drawing.Point(127, 40);
            this.txtPrivateKey.Name = "txtPrivateKey";
            this.txtPrivateKey.ReadOnly = true;
            this.txtPrivateKey.Size = new System.Drawing.Size(396, 21);
            this.txtPrivateKey.TabIndex = 3;
            this.txtPrivateKey.UseSystemPasswordChar = true;
            // 
            // btnRefreshBalance
            // 
            this.btnRefreshBalance.Location = new System.Drawing.Point(403, 62);
            this.btnRefreshBalance.Name = "btnRefreshBalance";
            this.btnRefreshBalance.Size = new System.Drawing.Size(120, 21);
            this.btnRefreshBalance.TabIndex = 4;
            this.btnRefreshBalance.Text = "刷新";
            this.btnRefreshBalance.UseVisualStyleBackColor = true;
            // 
            // lblAccountBalance
            // 
            this.lblAccountBalance.AutoSize = true;
            this.lblAccountBalance.Location = new System.Drawing.Point(129, 66);
            this.lblAccountBalance.Name = "lblAccountBalance";
            this.lblAccountBalance.Size = new System.Drawing.Size(11, 12);
            this.lblAccountBalance.TabIndex = 3;
            this.lblAccountBalance.Text = "0";
            // 
            // lblTextAccountBalance
            // 
            this.lblTextAccountBalance.AutoSize = true;
            this.lblTextAccountBalance.Location = new System.Drawing.Point(29, 66);
            this.lblTextAccountBalance.Name = "lblTextAccountBalance";
            this.lblTextAccountBalance.Size = new System.Drawing.Size(77, 12);
            this.lblTextAccountBalance.TabIndex = 2;
            this.lblTextAccountBalance.Text = "余额（ETH）:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textAccount);
            this.panel1.Controls.Add(this.btnCreateAccount);
            this.panel1.Controls.Add(this.btnRefreshBalance);
            this.panel1.Controls.Add(this.cmbUrl);
            this.panel1.Controls.Add(this.lblAccountBalance);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblTextAccountBalance);
            this.panel1.Controls.Add(this.lblAccount);
            this.panel1.Controls.Add(this.lblPrivateKey);
            this.panel1.Controls.Add(this.txtPrivateKey);
            this.panel1.Controls.Add(this.txtCurrentAccount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1092, 121);
            this.panel1.TabIndex = 5;
            // 
            // textAccount
            // 
            this.textAccount.Location = new System.Drawing.Point(545, 57);
            this.textAccount.Name = "textAccount";
            this.textAccount.Size = new System.Drawing.Size(300, 21);
            this.textAccount.TabIndex = 8;
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.Location = new System.Drawing.Point(544, 16);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(116, 23);
            this.btnCreateAccount.TabIndex = 7;
            this.btnCreateAccount.Text = "创建账户";
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // cmbUrl
            // 
            this.cmbUrl.FormattingEnabled = true;
            this.cmbUrl.Items.AddRange(new object[] {
            "https://ropsten.infura.io",
            "https://mainnet.infura.io",
            "http://localhost:8545"});
            this.cmbUrl.Location = new System.Drawing.Point(127, 85);
            this.cmbUrl.Name = "cmbUrl";
            this.cmbUrl.Size = new System.Drawing.Size(396, 20);
            this.cmbUrl.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rpc Url:";
            // 
            // tabPageTransactions
            // 
            this.tabPageTransactions.Controls.Add(this.panelSendTransactionStandardToken);
            this.tabPageTransactions.Controls.Add(this.transactionsUserControl1);
            this.tabPageTransactions.Location = new System.Drawing.Point(4, 22);
            this.tabPageTransactions.Name = "tabPageTransactions";
            this.tabPageTransactions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTransactions.Size = new System.Drawing.Size(1084, 543);
            this.tabPageTransactions.TabIndex = 4;
            this.tabPageTransactions.Text = "发送交易(ETH/ERC20)";
            this.tabPageTransactions.UseVisualStyleBackColor = true;
            // 
            // panelSendTransactionStandardToken
            // 
            this.panelSendTransactionStandardToken.Controls.Add(this.gbStandardToken);
            this.panelSendTransactionStandardToken.Controls.Add(this.gbTransfer);
            this.panelSendTransactionStandardToken.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSendTransactionStandardToken.Location = new System.Drawing.Point(3, 3);
            this.panelSendTransactionStandardToken.Name = "panelSendTransactionStandardToken";
            this.panelSendTransactionStandardToken.Size = new System.Drawing.Size(1078, 276);
            this.panelSendTransactionStandardToken.TabIndex = 3;
            // 
            // gbStandardToken
            // 
            this.gbStandardToken.Controls.Add(this.standardTokenTransferUserControl1);
            this.gbStandardToken.Controls.Add(this.standardTokenBalanceOfUserControl1);
            this.gbStandardToken.Controls.Add(this.standardTokenContractAddressUserControl1);
            this.gbStandardToken.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbStandardToken.Location = new System.Drawing.Point(516, 0);
            this.gbStandardToken.Name = "gbStandardToken";
            this.gbStandardToken.Size = new System.Drawing.Size(562, 276);
            this.gbStandardToken.TabIndex = 3;
            this.gbStandardToken.TabStop = false;
            this.gbStandardToken.Text = "标准ETH Token";
            // 
            // standardTokenTransferUserControl1
            // 
            this.standardTokenTransferUserControl1.Location = new System.Drawing.Point(5, 117);
            this.standardTokenTransferUserControl1.Margin = new System.Windows.Forms.Padding(2);
            this.standardTokenTransferUserControl1.Name = "standardTokenTransferUserControl1";
            this.standardTokenTransferUserControl1.Size = new System.Drawing.Size(516, 157);
            this.standardTokenTransferUserControl1.TabIndex = 2;
            this.standardTokenTransferUserControl1.ViewModel = null;
            // 
            // standardTokenBalanceOfUserControl1
            // 
            this.standardTokenBalanceOfUserControl1.Location = new System.Drawing.Point(5, 89);
            this.standardTokenBalanceOfUserControl1.Margin = new System.Windows.Forms.Padding(2);
            this.standardTokenBalanceOfUserControl1.Name = "standardTokenBalanceOfUserControl1";
            this.standardTokenBalanceOfUserControl1.Size = new System.Drawing.Size(433, 38);
            this.standardTokenBalanceOfUserControl1.TabIndex = 1;
            this.standardTokenBalanceOfUserControl1.ViewModel = null;
            // 
            // standardTokenContractAddressUserControl1
            // 
            this.standardTokenContractAddressUserControl1.Location = new System.Drawing.Point(5, 17);
            this.standardTokenContractAddressUserControl1.Margin = new System.Windows.Forms.Padding(2);
            this.standardTokenContractAddressUserControl1.Name = "standardTokenContractAddressUserControl1";
            this.standardTokenContractAddressUserControl1.Size = new System.Drawing.Size(433, 68);
            this.standardTokenContractAddressUserControl1.TabIndex = 0;
            this.standardTokenContractAddressUserControl1.ViewModel = null;
            // 
            // gbTransfer
            // 
            this.gbTransfer.Controls.Add(this.transferUserControl1);
            this.gbTransfer.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbTransfer.Location = new System.Drawing.Point(0, 0);
            this.gbTransfer.Name = "gbTransfer";
            this.gbTransfer.Size = new System.Drawing.Size(516, 276);
            this.gbTransfer.TabIndex = 1;
            this.gbTransfer.TabStop = false;
            this.gbTransfer.Text = "发送交易";
            // 
            // transferUserControl1
            // 
            this.transferUserControl1.Location = new System.Drawing.Point(3, 17);
            this.transferUserControl1.Margin = new System.Windows.Forms.Padding(4);
            this.transferUserControl1.Name = "transferUserControl1";
            this.transferUserControl1.Size = new System.Drawing.Size(506, 252);
            this.transferUserControl1.TabIndex = 0;
            this.transferUserControl1.ViewModel = null;
            // 
            // transactionsUserControl1
            // 
            this.transactionsUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transactionsUserControl1.Location = new System.Drawing.Point(3, 3);
            this.transactionsUserControl1.Margin = new System.Windows.Forms.Padding(2);
            this.transactionsUserControl1.Name = "transactionsUserControl1";
            this.transactionsUserControl1.Size = new System.Drawing.Size(1078, 537);
            this.transactionsUserControl1.TabIndex = 1;
            this.transactionsUserControl1.ViewModel = null;
            // 
            // tabStepMainLoadAccount
            // 
            this.tabStepMainLoadAccount.Controls.Add(this.tabPageLoadAccount);
            this.tabStepMainLoadAccount.Location = new System.Drawing.Point(4, 22);
            this.tabStepMainLoadAccount.Name = "tabStepMainLoadAccount";
            this.tabStepMainLoadAccount.Padding = new System.Windows.Forms.Padding(3);
            this.tabStepMainLoadAccount.Size = new System.Drawing.Size(1084, 543);
            this.tabStepMainLoadAccount.TabIndex = 3;
            this.tabStepMainLoadAccount.Text = "账户";
            this.tabStepMainLoadAccount.UseVisualStyleBackColor = true;
            // 
            // tabPageLoadAccount
            // 
            this.tabPageLoadAccount.Controls.Add(this.tabPageLoadAccountFromFile);
            this.tabPageLoadAccount.Controls.Add(this.tabPageHdWallet);
            this.tabPageLoadAccount.Controls.Add(this.tabPageLoadAccountFromPrivateKey);
            this.tabPageLoadAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPageLoadAccount.Location = new System.Drawing.Point(3, 3);
            this.tabPageLoadAccount.Name = "tabPageLoadAccount";
            this.tabPageLoadAccount.SelectedIndex = 0;
            this.tabPageLoadAccount.Size = new System.Drawing.Size(1078, 537);
            this.tabPageLoadAccount.TabIndex = 0;
            // 
            // tabPageLoadAccountFromFile
            // 
            this.tabPageLoadAccountFromFile.Controls.Add(this.keystoreAccountLoaderUserControl3);
            this.tabPageLoadAccountFromFile.Location = new System.Drawing.Point(4, 22);
            this.tabPageLoadAccountFromFile.Name = "tabPageLoadAccountFromFile";
            this.tabPageLoadAccountFromFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLoadAccountFromFile.Size = new System.Drawing.Size(1070, 511);
            this.tabPageLoadAccountFromFile.TabIndex = 0;
            this.tabPageLoadAccountFromFile.Text = "KeyStore文件";
            this.tabPageLoadAccountFromFile.UseVisualStyleBackColor = true;
            // 
            // keystoreAccountLoaderUserControl3
            // 
            this.keystoreAccountLoaderUserControl3.Location = new System.Drawing.Point(0, 6);
            this.keystoreAccountLoaderUserControl3.Margin = new System.Windows.Forms.Padding(4);
            this.keystoreAccountLoaderUserControl3.Name = "keystoreAccountLoaderUserControl3";
            this.keystoreAccountLoaderUserControl3.Size = new System.Drawing.Size(440, 145);
            this.keystoreAccountLoaderUserControl3.TabIndex = 0;
            this.keystoreAccountLoaderUserControl3.ViewModel = null;
            // 
            // tabPageHdWallet
            // 
            this.tabPageHdWallet.Controls.Add(this.hdWalletAccountLoaderUserControl1);
            this.tabPageHdWallet.Location = new System.Drawing.Point(4, 22);
            this.tabPageHdWallet.Name = "tabPageHdWallet";
            this.tabPageHdWallet.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHdWallet.Size = new System.Drawing.Size(830, 511);
            this.tabPageHdWallet.TabIndex = 1;
            this.tabPageHdWallet.Text = "助记词";
            this.tabPageHdWallet.UseVisualStyleBackColor = true;
            // 
            // hdWalletAccountLoaderUserControl1
            // 
            this.hdWalletAccountLoaderUserControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.hdWalletAccountLoaderUserControl1.Location = new System.Drawing.Point(3, 3);
            this.hdWalletAccountLoaderUserControl1.Margin = new System.Windows.Forms.Padding(4);
            this.hdWalletAccountLoaderUserControl1.Name = "hdWalletAccountLoaderUserControl1";
            this.hdWalletAccountLoaderUserControl1.Size = new System.Drawing.Size(824, 206);
            this.hdWalletAccountLoaderUserControl1.TabIndex = 0;
            this.hdWalletAccountLoaderUserControl1.ViewModel = null;
            // 
            // tabPageLoadAccountFromPrivateKey
            // 
            this.tabPageLoadAccountFromPrivateKey.Controls.Add(this.privateKeyAccountLoaderUserControl1);
            this.tabPageLoadAccountFromPrivateKey.Location = new System.Drawing.Point(4, 22);
            this.tabPageLoadAccountFromPrivateKey.Name = "tabPageLoadAccountFromPrivateKey";
            this.tabPageLoadAccountFromPrivateKey.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLoadAccountFromPrivateKey.Size = new System.Drawing.Size(830, 511);
            this.tabPageLoadAccountFromPrivateKey.TabIndex = 2;
            this.tabPageLoadAccountFromPrivateKey.Text = "私钥";
            this.tabPageLoadAccountFromPrivateKey.UseVisualStyleBackColor = true;
            // 
            // privateKeyAccountLoaderUserControl1
            // 
            this.privateKeyAccountLoaderUserControl1.Location = new System.Drawing.Point(1, 6);
            this.privateKeyAccountLoaderUserControl1.Margin = new System.Windows.Forms.Padding(4);
            this.privateKeyAccountLoaderUserControl1.Name = "privateKeyAccountLoaderUserControl1";
            this.privateKeyAccountLoaderUserControl1.Size = new System.Drawing.Size(406, 96);
            this.privateKeyAccountLoaderUserControl1.TabIndex = 0;
            this.privateKeyAccountLoaderUserControl1.ViewModel = null;
            // 
            // tabSteps
            // 
            this.tabSteps.Controls.Add(this.tabStepMainLoadAccount);
            this.tabSteps.Controls.Add(this.tabPageTransactions);
            this.tabSteps.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabSteps.ItemSize = new System.Drawing.Size(48, 18);
            this.tabSteps.Location = new System.Drawing.Point(0, 126);
            this.tabSteps.Name = "tabSteps";
            this.tabSteps.SelectedIndex = 0;
            this.tabSteps.Size = new System.Drawing.Size(1092, 569);
            this.tabSteps.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 695);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabSteps);
            this.Name = "MainForm";
            this.Text = "BTChat Wallet";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPageTransactions.ResumeLayout(false);
            this.panelSendTransactionStandardToken.ResumeLayout(false);
            this.gbStandardToken.ResumeLayout(false);
            this.gbTransfer.ResumeLayout(false);
            this.tabStepMainLoadAccount.ResumeLayout(false);
            this.tabPageLoadAccount.ResumeLayout(false);
            this.tabPageLoadAccountFromFile.ResumeLayout(false);
            this.tabPageHdWallet.ResumeLayout(false);
            this.tabPageLoadAccountFromPrivateKey.ResumeLayout(false);
            this.tabSteps.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCurrentAccount;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label lblPrivateKey;
        private System.Windows.Forms.TextBox txtPrivateKey;
        private System.Windows.Forms.OpenFileDialog fileOpenerKeyStore;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAccountBalance;
        private System.Windows.Forms.Label lblTextAccountBalance;
        private System.Windows.Forms.ComboBox cmbUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefreshBalance;
        private System.Windows.Forms.TabPage tabPageTransactions;
        private System.Windows.Forms.Panel panelSendTransactionStandardToken;
        private System.Windows.Forms.GroupBox gbStandardToken;
        private System.Windows.Forms.GroupBox gbTransfer;
        private Controls.SendTransactionUserControl transferUserControl1;
        private Controls.TransactionsUserControl transactionsUserControl1;
        private System.Windows.Forms.TabPage tabStepMainLoadAccount;
        private System.Windows.Forms.TabControl tabPageLoadAccount;
        private System.Windows.Forms.TabPage tabPageLoadAccountFromFile;
        private KeystoreAccountLoaderUserControl keystoreAccountLoaderUserControl3;
        private System.Windows.Forms.TabPage tabPageHdWallet;
        private Controls.HDWalletAccountLoaderUserControl hdWalletAccountLoaderUserControl1;
        private System.Windows.Forms.TabPage tabPageLoadAccountFromPrivateKey;
        private PrivateKeyAccountLoaderUserControl privateKeyAccountLoaderUserControl1;
        private System.Windows.Forms.TabControl tabSteps;
        private Controls.StandardToken.StandardTokenTransferUserControl standardTokenTransferUserControl1;
        private Controls.StandardToken.StandardTokenBalanceOfUserControl standardTokenBalanceOfUserControl1;
        private Controls.StandardToken.StandardTokenContractAddressUserControl standardTokenContractAddressUserControl1;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.TextBox textAccount;
    }
}

