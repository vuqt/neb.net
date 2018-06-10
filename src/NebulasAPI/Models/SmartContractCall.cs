using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebulasAPI.Models
{
    public class SmartContractCall : RESTfulResult
    {
        public SmartContractCallResult result;
    }

    public class SmartContractCallResult
    {
        public string result { get; set; }
        public string execute_err { get; set; }
        public string estimate_gas { get; set; }
    }

    public class ContractInfo
    {
        public string function { get; set; }
        public string args { get; set; }
    }
}
