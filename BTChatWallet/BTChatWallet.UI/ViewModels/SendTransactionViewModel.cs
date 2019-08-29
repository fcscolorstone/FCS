using System.Reactive.Linq;
using System.Threading.Tasks;
using Genesis.Ensure;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.UI.UIMessages;
using ReactiveUI;

namespace Nethereum.UI.ViewModels
{
    public class SendTransactionViewModel : SendTransactionBaseViewModel
    {

        public SendTransactionViewModel()
        {
            Gas = (ulong)Signer.Transaction.DEFAULT_GAS_LIMIT;
            GasPrice = (ulong)Signer.Transaction.DEFAULT_GAS_PRICE;

            var canExecuteTransaction = this.WhenAnyValue(
                x => x.AddressTo,
                x => x.AmountInEther,
                x => x.Url,
                x => x.Account,
                (addressTo, amountInEther, url, account) =>
                        Util.Utils.IsValidAddress(addressTo) && 
                        amountInEther != null && 
                        Util.Utils.IsValidUrl(url) && 
                        account != null);

            this._executeTrasnactionCommand = ReactiveCommand.CreateFromTask(ExecuteAsync, canExecuteTransaction);
        }

        public async Task<string> ExecuteAsync()
        {
            Ensure.ArgumentNotNullOrEmpty(this.AddressTo, "收款地址");
            Ensure.ArgumentNotNullOrEmpty(this.Url, "Rpc Url");
            Ensure.ArgumentNotNull(this.Account, "账号");
            Ensure.ArgumentNotNull(this.AmountInEther, "数量");

            var confirmed = await _confirmTransfer.Handle(GetConfirmationMessage());

            if (confirmed)
            {
                var web3 = new Web3.Web3(Account, Url);

                var transactionInput =
                    new TransactionInput
                    {
                        Value = new HexBigInteger(Web3.Web3.Convert.ToWei(AmountInEther.Value)),
                        To = AddressTo,
                        From = web3.TransactionManager.Account.Address
                    };
                if (Gas != null) transactionInput.Gas = new HexBigInteger(Gas.Value);
                if (GasPrice != null) transactionInput.GasPrice = new HexBigInteger(GasPrice.Value);
                if (Nonce != null) transactionInput.Nonce = new HexBigInteger(Nonce.Value);
                if (!string.IsNullOrEmpty(Data)) transactionInput.Data = Data;

                var transactionHash =  await web3.TransactionManager.SendTransactionAsync(transactionInput);
                MessageBus.Current.SendMessage<TransactionAdded>(new TransactionAdded(transactionHash));
                return transactionHash;
            }
            return null;
        }

      

        public string GetConfirmationMessage()
        {
            return
                $"确定提交本次交易: \n\r 收款地址: {AddressTo} \n\r 数量: {AmountInEther}";
        }    
    }
}