namespace Nethereum.StandardToken.UI.UIMessages
{
    public class StandardTokenAddressChanged
    {
        public StandardTokenAddressChanged(string address, int decimals)
        {
            Address = address;
            Decimals = decimals;
        }
        public string Address { get; }
        public int Decimals { get; }
    }
}