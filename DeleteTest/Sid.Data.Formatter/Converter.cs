using System.Collections.Generic;
using System.Text;
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
}
