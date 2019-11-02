using System.Reactive;
using System.Reactive.Linq;
using Genesis.Ensure;
using Nethereum.UI.UIMessages;
using Nethereum.Web3.Accounts;
using ReactiveUI;

namespace Nethereum.UI.ViewModels
{
    public class PrivateKeyLoaderViewModel : ReactiveObject
    {
        private string _privateKey;
        public string PrivateKey
        {
            get => _privateKey;
            set => this.RaiseAndSetIfChanged(ref _privateKey, value);
        }

        private string _export_info;
        public string ExportInfo
        {
            get => _export_info;
            set => this.RaiseAndSetIfChanged(ref _export_info, value);
        }

        public Account _account;
        
        private readonly ReactiveCommand<Unit, string> _loadAccountFromPrivateKeyCommand;
        public ReactiveCommand<Unit, string> LoadAccountFromPrivateKeyCommand => this._loadAccountFromPrivateKeyCommand;

        private readonly ReactiveCommand<Unit, string> _exportPrivateKeyCommand;
        public ReactiveCommand<Unit, string> ExportPrivateKeyCommand => this._exportPrivateKeyCommand;

        public PrivateKeyLoaderViewModel()
        {
            var canExecuteLoadPrivateKey = this.WhenAnyValue(
                x => x.PrivateKey,
                (privateKey) => !string.IsNullOrEmpty(privateKey));

            this._loadAccountFromPrivateKeyCommand = ReactiveCommand.Create(this.LoadAccountFromPrivateKey, canExecuteLoadPrivateKey);

            var canExportPrivateKey = this.WhenAny(
                x => x._account,
                (_account) => (null != _account));

            this._exportPrivateKeyCommand = ReactiveCommand.Create(this.ExportPrivateKey, canExportPrivateKey);

        }

        public string LoadAccountFromPrivateKey()
        {
            Ensure.ArgumentNotNull(this.PrivateKey, "Private Key");
            _account = new Account(_privateKey);

            MessageBus.Current.SendMessage(new AccountLoaded(_account));

            return _privateKey;
        }

        public string ExportPrivateKey()
        {
            var pk = _account?.PrivateKey;

            MessageBus.Current.SendMessage(new AccountExported(pk));

            return pk;
        }
    }
}