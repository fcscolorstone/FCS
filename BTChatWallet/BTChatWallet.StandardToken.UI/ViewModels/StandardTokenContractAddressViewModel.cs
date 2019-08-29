using System;
using System.Reactive.Linq;
using Nethereum.StandardToken.UI.UIMessages;
using Nethereum.UI.Util;
using ReactiveUI;

namespace Nethereum.StandardToken.UI.ViewModels
{
    public class StandardTokenContractAddressViewModel : ReactiveObject
    {
        private string _contractAddress;
        private int _decimals;

        public string ContractAddress
        {
            get => _contractAddress;
            set => this.RaiseAndSetIfChanged(ref _contractAddress, value);
        }
        public int Decimals
        {
            get => _decimals;
            set => this.RaiseAndSetIfChanged(ref _decimals, value);
        }

        public StandardTokenContractAddressViewModel()
        {
            var isValidContractAddresss = this.WhenAnyValue(
                x => x.ContractAddress,
                x => x.Decimals,
                (contractAddress, decimals) => Utils.IsValidAddress(contractAddress) && (decimals >= 0));

            isValidContractAddresss.Where(x => x == true)
                .Subscribe(_ => MessageBus.Current.SendMessage(new StandardTokenAddressChanged(ContractAddress, Decimals)));
        }

    }
}