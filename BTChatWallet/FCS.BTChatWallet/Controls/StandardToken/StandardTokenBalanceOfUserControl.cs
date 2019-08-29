﻿using System.ComponentModel;
using System.Windows.Forms;
using Nethereum.StandardToken.UI.ViewModels;
using ReactiveUI;

namespace FCS.BTChatWallet.Controls.StandardToken
{
    public partial class StandardTokenBalanceOfUserControl : UserControl, IViewFor<StandardTokenBalanceOfViewModel>
    {
        public StandardTokenBalanceOfUserControl()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.Bind(ViewModel, x => x.Balance, x => x.lblAccountBalance.Text);
                this.BindCommand(ViewModel, x => x.RefreshBalanceCommand, x => x.btnRefreshBalance);
            }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (StandardTokenBalanceOfViewModel)value; }
        }

        public StandardTokenBalanceOfViewModel ViewModel { get; set; }
    }
}
