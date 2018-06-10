using Multiformats.Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NebulasAPI.Models
{
    public class IrreversibleBlock : RESTfulResult
    {
        public IrreversibleBlockResult result;
    }

    public class IrreversibleBlockResult
    {
        public string hash { get; set; }
        public string parent_hash { get; set; }
        public string height { get; set; }
        public string nonce { get; set; }
        public string coinbase { get; set; }
        public string timestamp { get; set; }
        public string chain_id { get; set; }
        public string state_root { get; set; }
        public string txs_root { get; set; }
        public string events_root { get; set; }
        public ConsensusRootData consensus_root { get; set; }
        public string miner { get; set; }
        public string is_finality { get; set; }
        public TransactionData[] transactions { get; set; }
    }

    public class ConsensusRootData
    {
        public string timestamp { get; set; }
        public string proposer { get; set; }
        public string dynasty_root { get; set; }
    }
}
