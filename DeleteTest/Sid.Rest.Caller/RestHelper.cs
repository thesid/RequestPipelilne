using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace Sid.Rest.Caller
{
    public static class RestHelper
    {
        /// <summary>
        /// Rest Request helper To make reat calls.
        /// It currently supports basic GET calls only
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="resource"></param>
        /// <param name="parametersDictionary"></param>
        /// <param name="urlSegmentDictionary"></param>
        /// <param name="headerDictionary"></param>
        /// <returns></returns>
        public static string Get(
            string baseUrl,
            string resource,
            Dictionary<string, string> parametersDictionary,
            Dictionary<string, string> urlSegmentDictionary,
            Dictionary<string, string> headerDictionary)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resource, Method.GET);
            if (null != urlSegmentDictionary)
                foreach (var segement in urlSegmentDictionary)
                    request.AddUrlSegment(segement.Key, segement.Value);

            if (urlSegmentDictionary != null)
                foreach (var segement in urlSegmentDictionary)
                    request.AddParameter(segement.Key, segement.Value);

            if (headerDictionary != null)
                foreach (var header in headerDictionary)
                    request.AddHeader(header.Key, header.Value);

            var response = client.Execute(request);
            return JsonConvert.SerializeObject(response.Content);
        }
    }


}
