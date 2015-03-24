using Newtonsoft.Json;

namespace Sid.Data.Formatter
{
    public class JsonToXmlFormatter : IOutputTypesStrategy
    {
        public object Execute(string input)
        {
            var json = @"{'?xml': {'@version': '1.0','@standalone': 'no'},'root':" + input.Replace('"', '\'') + "}";

            var xmlDocument = JsonConvert.DeserializeXmlNode(json);

            return xmlDocument;
        }


    }
}