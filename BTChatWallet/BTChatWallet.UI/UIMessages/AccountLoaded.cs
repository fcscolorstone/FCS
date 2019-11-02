using Nethereum.Web3.Accounts;

namespace Nethereum.UI.UIMessages
{
    public class AccountLoaded
    {
        public AccountLoaded(Account account)
        {
            Account = account;
        }

        public Account Account { get; }
    }

    public class AccountExported
    {
        public AccountExported(string info)
        {
            Info = info;
        }

        public string Info { get; }
    }
}