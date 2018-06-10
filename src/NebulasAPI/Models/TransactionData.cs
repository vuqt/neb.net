using Multiformats.Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebulasAPI.Models
{
    public class TransactionData
    {
        public string hash { get; set; }
        public string chainId { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string value { get; set; }
        public string nonce { get; set; }
        public string timestamp { get; set; }
        public string type { get; set; }
        public string data { get; set; }
        public string gas_price { get; set; }
        public string gas_limit { get; set; }
        public string contract_address { get; set; }
        public string status { get; set; }
        public string gas_used { get; set; }
        public string execute_error { get; set; }
        public string execute_result { get; set; }

        public void HashTransaction()
        {
            string hash = string.Empty;

            string strHashString = this.from + this.to +
                this.value +
                this.nonce +
                this.timestamp;

            byte[] bytes = Multihash.Encode(strHashString, HashType.SHA3_256);

            hash = Convert.ToBase64String(bytes);

            this.hash = hash;
        }
    }
}
