﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebulasAPI.Models
{
    public class Subscribe :  RESTfulResult
    {
        public SubscribeResult result;
    }

    public class SubscribeResult
    {
        public string topic { get; set; }
        public TransactionData data;
    }
}
