using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nethereum.JsonRpc.Client;
using Nethereum.JsonRpc.WebSocketStreamingClient;
using Nethereum.KeyStore;
using Nethereum.RPC;
using Nethereum.RPC.Eth;
using Nethereum.RPC.Eth.Blocks;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.RPC.Reactive.Eth.Subscriptions;
using Nethereum.Signer;
using Nethereum.StandardToken.UI.ViewModels;
using Nethereum.UI.ViewModels;
using Nethereum.Web3.Accounts;
using ReactiveUI;

namespace FCS.BTChatWallet
{
    public partial class MainForm : Form, IViewFor<AccountViewModel>
    {
        private KeyStoreLoaderViewModel _keyStoreLoaderViewModel;
        private AccountViewModel _accountViewModel;
        private SendTransactionViewModel _sendTransactionViewModel;
        private PrivateKeyLoaderViewModel _privateKeyLoaderViewModel;
        private HdWalletAccountLoaderViewModel _hdWalletAccountLoaderViewModel;
        private StandardTokenBalanceOfViewModel _standardTokenBalanceOfViewModel;
        private TransactionsViewModel _transactionsViewModel;
        private StandardTokenContractAddressViewModel _standardTokenContractAddressViewModel;
        private StandardTokenTransferViewModel _standardTokenTransferViewModel;

        public MainForm()
        {
            InitializeComponent();
            _accountViewModel = new AccountViewModel();
            ViewModel = _accountViewModel;

            _sendTransactionViewModel = new SendTransactionViewModel();
            transferUserControl1.ViewModel = _sendTransactionViewModel;
            _keyStoreLoaderViewModel = new KeyStoreLoaderViewModel();
            keystoreAccountLoaderUserControl3.ViewModel = _keyStoreLoaderViewModel;
            _privateKeyLoaderViewModel = new PrivateKeyLoaderViewModel();
            privateKeyAccountLoaderUserControl1.ViewModel = _privateKeyLoaderViewModel;
            _hdWalletAccountLoaderViewModel = new HdWalletAccountLoaderViewModel();
            hdWalletAccountLoaderUserControl1.ViewModel = _hdWalletAccountLoaderViewModel;

            _standardTokenBalanceOfViewModel = new StandardTokenBalanceOfViewModel();
             standardTokenBalanceOfUserControl1.ViewModel = _standardTokenBalanceOfViewModel;

            _standardTokenContractAddressViewModel = new StandardTokenContractAddressViewModel();
             standardTokenContractAddressUserControl1.ViewModel = _standardTokenContractAddressViewModel;

            _standardTokenTransferViewModel = new StandardTokenTransferViewModel();
            standardTokenTransferUserControl1.ViewModel = _standardTokenTransferViewModel;

            _transactionsViewModel = new TransactionsViewModel();
            transactionsUserControl1.ViewModel = _transactionsViewModel;

            this.Bind(ViewModel, x => x.Address, x => x.txtCurrentAccount.Text);
            this.Bind(ViewModel, x => x.PrivateKey, x => x.txtPrivateKey.Text);
            this.Bind(ViewModel, x => x.Balance, x => x.lblAccountBalance.Text);
            this.Bind(ViewModel, x => x.Url, x => x.cmbUrl.Text);
            this.BindCommand(ViewModel, x => x.RefreshBalanceCommand, x => x.btnRefreshBalance);

            ViewModel.Url = "https://ropsten.infura.io";

            //WatchEventRpc();
        }

        public async void WatchEventRpc()
        {
            var client = new RpcClient(new Uri("https://mainnet.infura.io"));

            var ethGetBlockByHash = new EthGetBlockWithTransactionsByNumber(client);

            var bts = await ethGetBlockByHash.SendRequestAsync(new BlockParameter(7865954));
            if (null != bts)
            {
                var author = bts.Author;
            }

            var ethGetGasEstimate = new EthGasPrice(client);
            var gas = await ethGetGasEstimate.SendRequestAsync();
            Console.WriteLine(gas.Value);

            var apiService = new EthApiService(client);
            var bal = await apiService.GetBalance.SendRequestAsync("0xDcCC7b8dDf511f7CE2Ecf8672F57a4E277d73198");
            Console.WriteLine(bal.Value);

            var gass = await apiService.GasPrice.SendRequestAsync();
            Console.WriteLine(gass.Value);

        }

        public void WatchEventWebSocket()
        {
            var client = new StreamingWebSocketClient("wss://mainnet.infura.io/ws");

            // var client = new StreamingWebSocketClient("ws://127.0.0.1:8546");
            var blockHeaderSubscription = new EthNewBlockHeadersObservableSubscription(client);

            blockHeaderSubscription.GetSubscribeResponseAsObservable().Subscribe(subscriptionId =>
                Console.WriteLine("Block Header subscription Id: " + subscriptionId));

            blockHeaderSubscription.GetSubscriptionDataResponsesAsObservable().Subscribe(block =>
                Console.WriteLine("New Block: " + block.BlockHash));

            blockHeaderSubscription.GetUnsubscribeResponseAsObservable().Subscribe(response =>
                            Console.WriteLine("Block Header unsubscribe result: " + response));

            //client.StartAsync().Wait();
            //blockHeaderSubscription.SubscribeAsync().Wait();
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (AccountViewModel)value; }
        }

        public AccountViewModel ViewModel { get; set; }

        // test
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            var account = CreateAccount("hell2018", "D:\\SVN\\ThreeKing\\KeyStore");
            var addr = account.Address;
            Console.WriteLine(addr);
        }

        public Account CreateAccount(string password, string path)
        {
            var ecKey = GenerateNewAccount();
            return CreateAccount(password, ecKey, path);
        }

        public EthECKey GenerateNewAccount()
        {
            //Generate a private key pair using SecureRandom
            return Nethereum.Signer.EthECKey.GenerateKey();
        }

        public Account CreateAccount(string password, EthECKey key, string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //Create a store service, to encrypt and save the file using the web3 standard
            var service = new KeyStoreService();
            var encryptedKey = service.EncryptAndGenerateDefaultKeyStoreAsJson(password, key.GetPrivateKeyAsBytes(), key.GetPublicAddress());
            var fileName = service.GenerateUTCFileName(key.GetPublicAddress());
            //save the File
            using (var newfile = File.CreateText(Path.Combine(path, fileName)))
            {
                newfile.Write(encryptedKey);
                newfile.Flush();
            }

            return new Account(key.GetPrivateKey());
        }
    }
}
