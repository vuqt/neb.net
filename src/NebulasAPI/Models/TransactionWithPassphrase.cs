using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebulasAPI.Models
{
    public class TransactionWithPassphrase : RESTfulResult
    {
        public TransactionWithPassphraseResult result;
    }

    public class TransactionWithPassphraseResult
    {
        public string hash { get; set; }
        public string contract_address { get; set; }
    }
}
