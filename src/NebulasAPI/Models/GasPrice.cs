﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebulasAPI.Models
{
    public class GasPrice : RESTfulResult
    {
        public GasPriceResult result;
    }

    public class GasPriceResult
    {
        public string gas_price { get; set; }
    }
}
