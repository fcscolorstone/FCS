﻿using Nethereum.UI.ViewModels;

namespace FCS.BTChatWallet.Controls
{
    partial class HDWalletAccountLoaderUserControl
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
            this.dgAccounts = new System.Windows.Forms.DataGridView();
            this.indexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.privateKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnloadAccount = new System.Windows.Forms.DataGridViewButtonColumn();
            this.hdWalletAccountViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnLoadHdAccounts = new System.Windows.Forms.Button();
            this.lblKeyStoreFilePassword = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtWords = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hdWalletAccountViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgAccounts
            // 
            this.dgAccounts.AllowUserToAddRows = false;
            this.dgAccounts.AllowUserToDeleteRows = false;
            this.dgAccounts.AutoGenerateColumns = false;
            this.dgAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAccounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.indexDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.privateKeyDataGridViewTextBoxColumn,
            this.btnloadAccount});
            this.dgAccounts.DataSource = this.hdWalletAccountViewModelBindingSource;
            this.dgAccounts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgAccounts.Location = new System.Drawing.Point(0, 105);
            this.dgAccounts.Name = "dgAccounts";
            this.dgAccounts.ReadOnly = true;
            this.dgAccounts.Size = new System.Drawing.Size(427, 101);
            this.dgAccounts.TabIndex = 0;
            // 
            // indexDataGridViewTextBoxColumn
            // 
            this.indexDataGridViewTextBoxColumn.DataPropertyName = "Index";
            this.indexDataGridViewTextBoxColumn.HeaderText = "序号";
            this.indexDataGridViewTextBoxColumn.Name = "indexDataGridViewTextBoxColumn";
            this.indexDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "地址";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // privateKeyDataGridViewTextBoxColumn
            // 
            this.privateKeyDataGridViewTextBoxColumn.DataPropertyName = "PrivateKey";
            this.privateKeyDataGridViewTextBoxColumn.HeaderText = "私钥";
            this.privateKeyDataGridViewTextBoxColumn.Name = "privateKeyDataGridViewTextBoxColumn";
            this.privateKeyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // btnloadAccount
            // 
            this.btnloadAccount.HeaderText = "导入";
            this.btnloadAccount.Name = "btnloadAccount";
            this.btnloadAccount.ReadOnly = true;
            this.btnloadAccount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnloadAccount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnloadAccount.Text = "选择...";
            this.btnloadAccount.UseColumnTextForButtonValue = true;
            // 
            // hdWalletAccountViewModelBindingSource
            // 
            this.hdWalletAccountViewModelBindingSource.DataSource = typeof(Nethereum.UI.ViewModels.HdWalletAccountViewModel);
            // 
            // btnLoadHdAccounts
            // 
            this.btnLoadHdAccounts.Location = new System.Drawing.Point(200, 68);
            this.btnLoadHdAccounts.Name = "btnLoadHdAccounts";
            this.btnLoadHdAccounts.Size = new System.Drawing.Size(207, 30);
            this.btnLoadHdAccounts.TabIndex = 22;
            this.btnLoadHdAccounts.Text = "导入HD Wallet账户";
            this.btnLoadHdAccounts.UseVisualStyleBackColor = true;
            // 
            // lblKeyStoreFilePassword
            // 
            this.lblKeyStoreFilePassword.AutoSize = true;
            this.lblKeyStoreFilePassword.Location = new System.Drawing.Point(6, 43);
            this.lblKeyStoreFilePassword.Name = "lblKeyStoreFilePassword";
            this.lblKeyStoreFilePassword.Size = new System.Drawing.Size(47, 12);
            this.lblKeyStoreFilePassword.TabIndex = 21;
            this.lblKeyStoreFilePassword.Text = "  密码:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "助记词:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("宋体", 10F);
            this.txtPassword.Location = new System.Drawing.Point(59, 39);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(348, 23);
            this.txtPassword.TabIndex = 19;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtWords
            // 
            this.txtWords.Font = new System.Drawing.Font("宋体", 10F);
            this.txtWords.Location = new System.Drawing.Point(59, 10);
            this.txtWords.Name = "txtWords";
            this.txtWords.Size = new System.Drawing.Size(348, 23);
            this.txtWords.TabIndex = 18;
            // 
            // HDWalletAccountLoaderUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLoadHdAccounts);
            this.Controls.Add(this.lblKeyStoreFilePassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtWords);
            this.Controls.Add(this.dgAccounts);
            this.Name = "HDWalletAccountLoaderUserControl";
            this.Size = new System.Drawing.Size(427, 206);
            ((System.ComponentModel.ISupportInitialize)(this.dgAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hdWalletAccountViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgAccounts;
        private System.Windows.Forms.BindingSource hdWalletAccountViewModelBindingSource;
        private System.Windows.Forms.Button btnLoadHdAccounts;
        private System.Windows.Forms.Label lblKeyStoreFilePassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtWords;
        private System.Windows.Forms.DataGridViewTextBoxColumn indexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn privateKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn btnloadAccount;
    }
}
