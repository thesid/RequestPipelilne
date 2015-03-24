namespace Sid.Data.Formatter
{
    public class JsonFormatter : IOutputTypesStrategy
    {

        public object Execute(string input)
        {
            return input;
        }
    }
}