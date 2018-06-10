using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebulasAPI.Models
{
    public class Dynasty :  RESTfulResult
    {
        public DynastyResult result;
    }

    public class DynastyResult
    {
        public string[] miners;
    }
}
