using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NebulasAPI.Utils
{
    class RestUtils
    {
        public IRestResponse Send(string baseUrl, string resource)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            RestClient client = new RestClient(baseUrl);

            RestRequest request = new RestRequest(resource, Method.GET);
            request.Timeout = int.MaxValue;

            IRestResponse response = client.Execute(request);

            return response;
        }

        public IRestResponse Post(string baseUrl, string resource, Dictionary<string, string> paras)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            RestClient client = new RestClient(baseUrl);

            RestRequest request = new RestRequest(resource, Method.POST);
            request.Timeout = int.MaxValue;
            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();
            request.AddParameter("application/json", JsonConvert.SerializeObject(paras), ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            return response;
        }
    }
}
