﻿namespace Nethereum.UI.UIMessages
{
    public class UrlChanged
    {
        public UrlChanged(string url)
        {
            Url = url;
        }
        public string Url { get; }
    }
}
