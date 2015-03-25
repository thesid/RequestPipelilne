using System;
using Newtonsoft.Json;

namespace Request.Formatter
{
    public class JsonToXmlFormatter : IOutputTypesStrategy
    {
        // jsst an implimentaion to convert the input string into an XML 
        public object Execute(string input)
        {
            if (String.IsNullOrEmpty(input)) return null;

            //the below lies of code took me quite some time
            //Something dosent seem to be ok
            //but I dint want a Type either.
            var json = @"{'?xml': {'@version': '1.0','@standalone': 'no'},'root':" + input.Replace('"', '\'') + "}";
            var xmlDocument = JsonConvert.DeserializeXmlNode(json);

            return xmlDocument;
        }


    }
}