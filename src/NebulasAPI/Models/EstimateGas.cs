using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebulasAPI.Models
{
    public class EstimateGas :  RESTfulResult
    {
        public EstimateGasResult result;
    }

    public class EstimateGasResult
    {
        public string gas { get; set; }
        public string err { get; set; }
    }
}
