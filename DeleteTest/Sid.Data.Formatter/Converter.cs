using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Formatting = Newtonsoft.Json.Formatting;

namespace Sid.Data.Formatter
{
    public static class Converter
    {

        public enum OutputTypes
        {
            Xml,
            Json
        }

        private static readonly Dictionary<string, IOutputTypesStrategy> Strategies =
            new Dictionary<string, IOutputTypesStrategy>();

        static Converter()
        {
            Strategies.Add(OutputTypes.Xml.ToString().ToUpper(), new JsonToXmlFormatter());
            Strategies.Add(OutputTypes.Json.ToString().ToUpper(), new JsonFormatter());
        }

        public static object Process(string input, string type)
        {

            var x = JsonConvert.DeserializeObject(input);
            return Strategies[type.ToUpper()].Execute(x.ToString());
        }

    }

    public interface IOutputTypesStrategy
    {
        object Execute(string input);
    }

    public class JsonFormatter : IOutputTypesStrategy
    {

        public object Execute(string input)
        {
            return input;
        }
    }

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
