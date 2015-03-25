using System.Collections.Generic;
using Newtonsoft.Json;

namespace Request.Formatter
{
    public static class Converter
    {

        public enum OutputTypes
        {
            Xml,
            Json
        }

        //just a simple stradgy pattern implimentation that woudl decide on the type of converted to be called,
        // this dictonary could be filled in by a confuguration provided from an exeternal source and the 
        //enum could be completely removed as well
        private static readonly Dictionary<string, IOutputTypesStrategy> Strategies =
            new Dictionary<string, IOutputTypesStrategy>();

        static Converter()
        {
            Strategies.Add(OutputTypes.Xml.ToString().ToUpper(), new JsonToXmlFormatter());
            Strategies.Add(OutputTypes.Json.ToString().ToUpper(), new JsonFormatter());
        }

        public static object Process(string input, string type)
        {
            var output = JsonConvert.DeserializeObject(input);
            return Strategies[type.ToUpper()].Execute(output.ToString());
        }

    }
}
