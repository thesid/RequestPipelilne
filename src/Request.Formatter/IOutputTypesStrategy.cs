namespace Request.Formatter
{
    public interface IOutputTypesStrategy
    {
        object Execute(string input);
    }
}