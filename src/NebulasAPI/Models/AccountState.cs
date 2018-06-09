using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebulasAPI.Models
{
    public class AccountState : RESTfulResult
    {
        public AccountStateResult result;
    }

    public class AccountStateResult
    {
        public string balance { get; set; }
        public string nonce { get; set; }
        public string type { get; set; }
    }
}
