
namespace Request.Pipeline.Core
{
    //Already mentioned a lot of places this is the bigges blunder
    //it currently has an output and an output type just for the results
    public interface IPipelineObject
    {
        object Output { get; set; }
        object OutputType { get; set; }
    }
}
