using Nethereum.UI.ViewModels;

namespace FCS.BTChatWallet.Controls
{
    partial class TransactionsUserControl
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
            this.gbTransactions = new System.Windows.Forms.GroupBox();
            this.dgTransactions = new System.Windows.Forms.DataGridView();
            this.blockHashDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionHashDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fromDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gasPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nonceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gbTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTransactions
            // 
            this.gbTransactions.Controls.Add(this.dgTransactions);
            this.gbTransactions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbTransactions.Location = new System.Drawing.Point(0, 60);
            this.gbTransactions.Name = "gbTransactions";
            this.gbTransactions.Size = new System.Drawing.Size(1337, 208);
            this.gbTransactions.TabIndex = 28;
            this.gbTransactions.TabStop = false;
            this.gbTransactions.Text = "交易流水";
            // 
            // dgTransactions
            // 
            this.dgTransactions.AllowUserToAddRows = false;
            this.dgTransactions.AllowUserToDeleteRows = false;
            this.dgTransactions.AutoGenerateColumns = false;
            this.dgTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.blockHashDataGridViewTextBoxColumn,
            this.transactionHashDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.fromDataGridViewTextBoxColumn,
            this.toDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.gasDataGridViewTextBoxColumn,
            this.dataDataGridViewTextBoxColumn,
            this.gasPriceDataGridViewTextBoxColumn,
            this.nonceDataGridViewTextBoxColumn});
            this.dgTransactions.DataSource = this.transactionViewModelBindingSource;
            this.dgTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTransactions.Location = new System.Drawing.Point(3, 17);
            this.dgTransactions.Name = "dgTransactions";
            this.dgTransactions.ReadOnly = true;
            this.dgTransactions.Size = new System.Drawing.Size(1331, 188);
            this.dgTransactions.TabIndex = 0;
            // 
            // blockHashDataGridViewTextBoxColumn
            // 
            this.blockHashDataGridViewTextBoxColumn.DataPropertyName = "BlockHash";
            this.blockHashDataGridViewTextBoxColumn.HeaderText = "区块高度";
            this.blockHashDataGridViewTextBoxColumn.Name = "blockHashDataGridViewTextBoxColumn";
            this.blockHashDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transactionHashDataGridViewTextBoxColumn
            // 
            this.transactionHashDataGridViewTextBoxColumn.DataPropertyName = "TransactionHash";
            this.transactionHashDataGridViewTextBoxColumn.HeaderText = "交易号";
            this.transactionHashDataGridViewTextBoxColumn.Name = "transactionHashDataGridViewTextBoxColumn";
            this.transactionHashDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "状态";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fromDataGridViewTextBoxColumn
            // 
            this.fromDataGridViewTextBoxColumn.DataPropertyName = "From";
            this.fromDataGridViewTextBoxColumn.HeaderText = "付款地址";
            this.fromDataGridViewTextBoxColumn.Name = "fromDataGridViewTextBoxColumn";
            this.fromDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // toDataGridViewTextBoxColumn
            // 
            this.toDataGridViewTextBoxColumn.DataPropertyName = "To";
            this.toDataGridViewTextBoxColumn.HeaderText = "收款地址";
            this.toDataGridViewTextBoxColumn.Name = "toDataGridViewTextBoxColumn";
            this.toDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "数量";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gasDataGridViewTextBoxColumn
            // 
            this.gasDataGridViewTextBoxColumn.DataPropertyName = "Gas";
            this.gasDataGridViewTextBoxColumn.HeaderText = "Gas";
            this.gasDataGridViewTextBoxColumn.Name = "gasDataGridViewTextBoxColumn";
            this.gasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataDataGridViewTextBoxColumn
            // 
            this.dataDataGridViewTextBoxColumn.DataPropertyName = "Data";
            this.dataDataGridViewTextBoxColumn.HeaderText = "交易数据";
            this.dataDataGridViewTextBoxColumn.Name = "dataDataGridViewTextBoxColumn";
            this.dataDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gasPriceDataGridViewTextBoxColumn
            // 
            this.gasPriceDataGridViewTextBoxColumn.DataPropertyName = "GasPrice";
            this.gasPriceDataGridViewTextBoxColumn.HeaderText = "GasPrice";
            this.gasPriceDataGridViewTextBoxColumn.Name = "gasPriceDataGridViewTextBoxColumn";
            this.gasPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nonceDataGridViewTextBoxColumn
            // 
            this.nonceDataGridViewTextBoxColumn.DataPropertyName = "Nonce";
            this.nonceDataGridViewTextBoxColumn.HeaderText = "Nonce";
            this.nonceDataGridViewTextBoxColumn.Name = "nonceDataGridViewTextBoxColumn";
            this.nonceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transactionViewModelBindingSource
            // 
            this.transactionViewModelBindingSource.DataSource = typeof(Nethereum.UI.ViewModels.TransactionViewModel);
            // 
            // TransactionsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbTransactions);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TransactionsUserControl";
            this.Size = new System.Drawing.Size(1337, 268);
            this.gbTransactions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTransactions;
        private System.Windows.Forms.DataGridView dgTransactions;
        private System.Windows.Forms.DataGridViewTextBoxColumn blockHashDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionHashDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn toDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gasPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nonceDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource transactionViewModelBindingSource;
    }
}
