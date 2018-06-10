using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebulasAPI.Utils
{
    public static class Constant
    {
        public const string MAINNET = "https://mainnet.nebulas.io/";
        public const string TESTNET = "https://testnet.nebulas.io/";

        public const string API_VERSION = "/v1";

        public const string LINK_GetNebState = "/user/nebstate";
        public const string LINK_GetAccountState = "/user/accountstate";
        public const string LINK_LatestIrreversibleBlock = "/user/lib";
        public const string LINK_SendTransactionWithPassphrase = "/admin/transactionWithPassphrase";
        public const string LINK_GetBlockByHash = "/user/getBlockByHash";
        public const string LINK_GetBlockByHeight = "/user/getBlockByHeight";
        public const string LINK_GetTransactionReceipt = "/user/getTransactionReceipt";
        public const string LINK_GetTransactionByContract = "/user/getTransactionByContract";
        public const string LINK_GetGasPrice = "/user/getGasPrice";
        public const string LINK_EstimateGas = "/user/estimateGas";
        public const string LINK_GetEventsByHash = "/user/getEventsByHash";
        public const string LINK_Subscribe = "/user/subscribe";
        public const string LINK_GetDynasty = "/user/dynasty";
    }
}
