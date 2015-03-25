using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace Request.Requester
{
    public static class RestHelper
    {
        //rest helper to make rest calls using restsharp
        //original intention was toall ow this method to make all sorts of rest requests
        // but it looks good for now
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
            return JsonConvert.SerializeObject(response.Content);//All the output is converted in as a string which is in a json format.
        }
    }

}
