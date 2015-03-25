namespace Request.Formatter
{
    public class JsonFormatter : IOutputTypesStrategy
    {

        public object Execute(string input)
        {
            return input;
        }
    }
}