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
        /// https://github.com/nebulasio/wiki/blob/master/rpc.md#getaccountstate
        /// </summary>
        /// <param name="address"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public AccountState GetAccountState(string address, Int64 height = 0)
        {
            AccountState result = new AccountState();

            if (restUtils == null)
            {
                restUtils = new RestUtils();
            }

            string resource = string.Format("{0}{1}", API_VERSION, Constant.LINK_GetAccountState);

            Dictionary<string, string> paras = new Dictionary<string, string>();
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
    }
}
