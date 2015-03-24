using System.Xml;
using Newtonsoft.Json;

namespace Sid.Data.Formatter
{
    public class JsonToXmlFormatter : IOutputTypesStrategy
    {

        public object Execute(string input)
        {


            string json = @"{
  '?xml': {
    '@version': '1.0',
    '@standalone': 'no'
  },
  'root':
" + input.Replace('"', '\'') + "}";

            XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(json);

            return doc;
        }


    }
}