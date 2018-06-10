using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebulasAPI.Models
{
    public class EventsByHash : RESTfulResult
    {
        public EventsByHashResult result;
    }

    public class EventsByHashResult
    {
        public EventsByHashResultEvent[] events;
    }

    public class EventsByHashResultEvent
    {
        public string topic { get; set; }
        public string data { get; set; }
    }

    public class EventsByHashResultEventData
    {
        public string hash { get; set; }
        public string status { get; set; }
        public string gas_used { get; set; }
        public string error { get; set; }
    }
}
