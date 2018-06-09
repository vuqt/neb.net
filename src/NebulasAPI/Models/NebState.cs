using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebulasAPI.Models
{
    public class NebState : RESTfulResult
    {
        public NebStateResult result;
    }

    public class NebStateResult
    {
        public string chain_id { get; set; }
        public string tail { get; set; }
        public string lib { get; set; }
        public string height { get; set; }
        public string protocol_version { get; set; }
        public string synchronized { get; set; }
        public string version { get; set; }
    }
}
