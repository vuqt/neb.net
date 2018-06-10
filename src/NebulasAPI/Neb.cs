using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NebulasAPI.Utils;
using NebulasAPI.Models;
using RestSharp;
using System.Net;
using Newtonsoft.Json;

namespace NebulasAPI
{
    public class Neb
    {
        //choose mainnet/testnet
        private string API_URL = Constant.MAINNET;

        //support /v1 now
        private string API_VERSION = Constant.API_VERSION;

        private RestUtils restUtils = null;

        public Neb()
        {
            restUtils = new RestUtils();
        }

        public Neb(bool isTestnet)
        {
            restUtils = new RestUtils();

            if (isTestnet)
            {
                API_URL = Constant.TESTNET;
            }
            else
            {
                API_URL = Constant.MAINNET;
            }
        }

        /// <summary>
        /// Return the state of the neb.
        /// https://github.com/nebulasio/wiki/blob/master/rpc.md#getnebstate
        /// </summary>
        /// <returns></returns>
        public NebState GetNebState()
        {
            NebState result = new NebState();

            if (restUtils == null)
            {
                restUtils = new RestUtils();
            }

            string resource = string.Format("{0}{1}", API_VERSION, Constant.LINK_GetNebState);
            IRestResponse response = restUtils.Send(API_URL, resource);

            if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<NebState>(response.Content);
                    result.message = string.Empty;
                } catch (Exception ex)
                {
                    result.message = ex.Message;
                }
            } else
            {
                result.message = response.ErrorMessage;
            }

            return result;
        }

        /// <summary>
        /// Return the state of the account. Balance and nonce of the given address will be returned.
        /// https://github.com/nebulasio/wiki/blob/master/rpc.md#getaccountstate
        /// </summary>
        /// <param name="address">Hex string of the account addresss.</param>
        /// <param name="height">block account state with height. If not specified, use 0 as tail height.</param>
        /// <returns></returns>
        public AccountState GetAccountState(string address, Int64 height = 0)
        {
            AccountState result = new AccountState();

            if (restUtils == null)
            {
                restUtils = new RestUtils();
            }

            string resource = string.Format("{0}{1}", API_VERSION, Constant.LINK_GetAccountState);

            Dictionary<string, object> paras = new Dictionary<string, object>();
            paras.Add("address", address);
            paras.Add("height", height.ToString());

            IRestResponse response = restUtils.Post(API_URL, resource, paras);

            if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<AccountState>(response.Content);
                    result.message = string.Empty;
                }
                catch (Exception ex)
                {
                    result.message = ex.Message;
                }
            }
            else
            {
                result.message = response.ErrorMessage;
            }

            return result;
        }

        /// <summary>
        /// Return the latest irreversible block.
        /// https://github.com/nebulasio/wiki/blob/master/rpc.md#latestirreversibleblock
        /// </summary>
        /// <returns></returns>
        public IrreversibleBlock LatestIrreversibleBlock()
        {
            IrreversibleBlock result = new IrreversibleBlock();

            if (restUtils == null)
            {
                restUtils = new RestUtils();
            }

            string resource = string.Format("{0}{1}", API_VERSION, Constant.LINK_LatestIrreversibleBlock);
            IRestResponse response = restUtils.Send(API_URL, resource);

            if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<IrreversibleBlock>(response.Content);
                    result.message = string.Empty;
                }
                catch (Exception ex)
                {
                    result.message = ex.Message;
                }
            }
            else
            {
                result.message = response.ErrorMessage;
            }

            return result;
        }

        /*/// <summary>
        /// SignTransactionWithPassphrase sign transaction. The transaction's from addrees must be unlocked before sign call.
        /// https://github.com/nebulasio/wiki/blob/master/rpc_admin.md#signtransactionwithpassphrase
        /// </summary>
        /// <param name="transaction">this is the same as the SendTransaction parameters</param>
        /// <param name="passphrase">from account passphrase</param>
        /// <returns>Signed transaction data.</returns>
        public SendTransactionWithPassphrase SendTransactionWithPassphrase(TransactionData transaction, string passphrase)
        {
            SendTransactionWithPassphrase result = new Models.SendTransactionWithPassphrase();

            if (restUtils == null)
            {
                restUtils = new RestUtils();
            }

            string resource = string.Format("{0}{1}", API_VERSION, Constant.LINK_SendTransactionWithPassphrase);

            Dictionary<string, object> paras = new Dictionary<string, object>();
            paras.Add("transaction", transaction);
            paras.Add("passphrase", passphrase);

            IRestResponse response = restUtils.Post(API_URL, resource, paras);

            if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<SendTransactionWithPassphrase>(response.Content);
                    result.message = string.Empty;
                }
                catch (Exception ex)
                {
                    result.message = ex.Message;
                }
            }
            else
            {
                result.message = response.ErrorMessage;
            }

            return result;
        }*/
        /// <summary>
        /// Get block header info by the block hash.
        /// https://github.com/nebulasio/wiki/blob/master/rpc.md#getblockbyhash
        /// </summary>
        /// <param name="hash">Hex string of transaction hash.</param>
        /// <param name="full_fill_transaction">If true it returns the full transaction objects, if false only the hashes of the transactions.</param>
        /// <returns></returns>
        public IrreversibleBlock GetBlockByHash(string hash, bool full_fill_transaction)
        {
            IrreversibleBlock result = new IrreversibleBlock();

            if (restUtils == null)
            {
                restUtils = new RestUtils();
            }

            string resource = string.Format("{0}{1}", API_VERSION, Constant.LINK_GetBlockByHash);

            Dictionary<string, object> paras = new Dictionary<string, object>();
            paras.Add("hash", hash);
            paras.Add("full_fill_transaction", full_fill_transaction);

            IRestResponse response = restUtils.Post(API_URL, resource, paras);

            if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<IrreversibleBlock>(response.Content);
                    result.message = string.Empty;
                }
                catch (Exception ex)
                {
                    result.message = ex.Message;
                }
            }
            else
            {
                result.message = response.ErrorMessage;
            }

            return result;
        }

        /// <summary>
        /// Get block header info by the block height.
        /// https://github.com/nebulasio/wiki/blob/master/rpc.md#getblockbyheight
        /// </summary>
        /// <param name="height">Height of transaction hash.</param>
        /// <param name="full_fill_transaction">If true it returns the full transaction objects, if false only the hashes of the transactions.</param>
        /// <returns></returns>
        public IrreversibleBlock GetBlockByHeight(Int64 height, bool full_fill_transaction)
        {
            IrreversibleBlock result = new IrreversibleBlock();

            if (restUtils == null)
            {
                restUtils = new RestUtils();
            }

            string resource = string.Format("{0}{1}", API_VERSION, Constant.LINK_GetBlockByHeight);

            Dictionary<string, object> paras = new Dictionary<string, object>();
            paras.Add("height", height);
            paras.Add("full_fill_transaction", full_fill_transaction);

            IRestResponse response = restUtils.Post(API_URL, resource, paras);

            if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<IrreversibleBlock>(response.Content);
                    result.message = string.Empty;
                }
                catch (Exception ex)
                {
                    result.message = ex.Message;
                }
            }
            else
            {
                result.message = response.ErrorMessage;
            }

            return result;
        }

        /// <summary>
        /// Get transactionReceipt info by tansaction hash. If the transaction not submit or only submit and not packaged on chain, it will reurn not found error.
        /// https://github.com/nebulasio/wiki/blob/master/rpc.md#gettransactionreceipt
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public TransactionReceipt GetTransactionReceipt(string hash)
        {
            TransactionReceipt result = new TransactionReceipt();

            if (restUtils == null)
            {
                restUtils = new RestUtils();
            }

            string resource = string.Format("{0}{1}", API_VERSION, Constant.LINK_GetTransactionReceipt);

            Dictionary<string, object> paras = new Dictionary<string, object>();
            paras.Add("hash", hash);

            IRestResponse response = restUtils.Post(API_URL, resource, paras);

            if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<TransactionReceipt>(response.Content);
                    result.message = string.Empty;
                }
                catch (Exception ex)
                {
                    result.message = ex.Message;
                }
            }
            else
            {
                result.message = response.ErrorMessage;
            }

            return result;
        }

        /// <summary>
        /// Get transactionReceipt info by contract address. If contract not exists or packaged on chain, a not found error will be returned.
        /// https://github.com/nebulasio/wiki/blob/master/rpc.md#gettransactionbycontract
        /// </summary>
        /// <param name="address">Hex string of contract account address.</param>
        /// <returns></returns>
        public TransactionReceipt GetTransactionByContract(string address)
        {
            TransactionReceipt result = new TransactionReceipt();

            if (restUtils == null)
            {
                restUtils = new RestUtils();
            }

            string resource = string.Format("{0}{1}", API_VERSION, Constant.LINK_GetTransactionByContract);

            Dictionary<string, object> paras = new Dictionary<string, object>();
            paras.Add("address", address);

            IRestResponse response = restUtils.Post(API_URL, resource, paras);

            if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<TransactionReceipt>(response.Content);
                    result.message = string.Empty;
                }
                catch (Exception ex)
                {
                    result.message = ex.Message;
                }
            }
            else
            {
                result.message = response.ErrorMessage;
            }

            return result;
        }

        /// <summary>
        /// Return current gasPrice.
        /// </summary>
        /// <returns></returns>
        public GasPrice GetGasPrice()
        {
            GasPrice result = new GasPrice();

            if (restUtils == null)
            {
                restUtils = new RestUtils();
            }

            string resource = string.Format("{0}{1}", API_VERSION, Constant.LINK_GetGasPrice);
            IRestResponse response = restUtils.Send(API_URL, resource);

            if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<GasPrice>(response.Content);
                    result.message = string.Empty;
                }
                catch (Exception ex)
                {
                    result.message = ex.Message;
                }
            }
            else
            {
                result.message = response.ErrorMessage;
            }

            return result;
        }

        /// <summary>
        /// Return the estimate gas of transaction.
        /// </summary>
        /// <returns></returns>
        public EstimateGas EstimateGas(string from, string to, string value, int nonce, string gasPrice, string gasLimit)
        {
            EstimateGas result = new EstimateGas();

            if (restUtils == null)
            {
                restUtils = new RestUtils();
            }

            Dictionary<string, object> paras = new Dictionary<string, object>();
            paras.Add("from", from);
            paras.Add("to", to);
            paras.Add("value", value);
            paras.Add("nonce", nonce);
            paras.Add("gasPrice", gasPrice);
            paras.Add("gasLimit", gasLimit);

            string resource = string.Format("{0}{1}", API_VERSION, Constant.LINK_EstimateGas);
            IRestResponse response = restUtils.Post(API_URL, resource, paras);

            if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<EstimateGas>(response.Content);
                    result.message = string.Empty;
                }
                catch (Exception ex)
                {
                    result.message = ex.Message;
                }
            }
            else
            {
                result.message = response.ErrorMessage;
            }

            return result;
        }

        /// <summary>
        /// Return the events list of transaction.
        /// https://github.com/nebulasio/wiki/blob/master/rpc.md#geteventsbyhash
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public EventsByHash GetEventsByHash(string hash)
        {
            EventsByHash result = new EventsByHash();

            if (restUtils == null)
            {
                restUtils = new RestUtils();
            }

            string resource = string.Format("{0}{1}", API_VERSION, Constant.LINK_GetEventsByHash);

            Dictionary<string, object> paras = new Dictionary<string, object>();
            paras.Add("hash", hash);

            IRestResponse response = restUtils.Post(API_URL, resource, paras);

            if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<EventsByHash>(response.Content);
                    result.message = string.Empty;
                }
                catch (Exception ex)
                {
                    result.message = ex.Message;
                }
            }
            else
            {
                result.message = response.ErrorMessage;
            }

            return result;
        }

        /// <summary>
        /// Return the subscribed events of transaction & block. The request is a keep-alive connection.
        /// https://github.com/nebulasio/wiki/blob/master/rpc.md#subscribe
        /// topics: chain.pendingTransaction, chain.latestIrreversibleBlock, chain.transactionResult, chain.newTailBlock, chain.revertBlock
        /// this method will cause time-out: https://github.com/nebulasio/wiki/issues/189
        /// </summary>
        /// <param name="topics">repeated event topic name, string array.</param>
        /// <returns></returns>
        public Subscribe Subscribe(string[] topics)
        {
            Subscribe result = new Subscribe();

            if (restUtils == null)
            {
                restUtils = new RestUtils();
            }

            string resource = string.Format("{0}{1}", API_VERSION, Constant.LINK_Subscribe);

            Dictionary<string, object> paras = new Dictionary<string, object>();
            paras.Add("topics", topics);

            IRestResponse response = restUtils.Post(API_URL, resource, paras);

            if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<Subscribe>(response.Content);
                    result.message = string.Empty;
                }
                catch (Exception ex)
                {
                    result.message = ex.Message;
                }
            }
            else
            {
                result.message = response.ErrorMessage;
            }

            return result;
        }

        /// <summary>
        /// GetDynasty get dpos dynasty.
        /// https://github.com/nebulasio/wiki/blob/master/rpc.md#getdynasty
        /// </summary>
        /// <param name="height">block height</param>
        /// <returns></returns>
        public Dynasty GetDynasty(Int64 height)
        {
            Dynasty result = new Dynasty();

            if (restUtils == null)
            {
                restUtils = new RestUtils();
            }

            Dictionary<string, object> paras = new Dictionary<string, object>();
            paras.Add("height", height);

            string resource = string.Format("{0}{1}", API_VERSION, Constant.LINK_GetDynasty);
            IRestResponse response = restUtils.Post(API_URL, resource, paras);

            if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<Dynasty>(response.Content);
                    result.message = string.Empty;
                }
                catch (Exception ex)
                {
                    result.message = ex.Message;
                }
            }
            else
            {
                result.message = response.ErrorMessage;
            }

            return result;
        }
    }
}
