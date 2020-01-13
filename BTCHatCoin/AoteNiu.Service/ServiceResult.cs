using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoteNiu.Service
{
    public class ServiceResult
    {
        public IList<string> Errors { get; set; }

        public IDictionary<string, object> ExtraData { get; set; }

        public ServiceResult() 
        {
            this.Errors = new List<string>();
            this.ExtraData = new Dictionary<string, object>();
        }

        public bool Success 
        {
            get { return this.Errors.Count == 0; }
        }

        public void AddError(string error) 
        {
            this.Errors.Add(error);
        }

        public void AddExtra(string data, object o)
        {
            this.ExtraData.Add(data, o);
        }
    }

    public class GetContractInfoServiceResult
    {
        public string symbol { get; set; }

        public string name { get; set; }

        public decimal totalSupply { get; set; }

        public int decimals { get; set; }
    }
}
