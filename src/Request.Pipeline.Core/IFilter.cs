
namespace Request.Pipeline.Core
{
    //the filter interfaces which internally has a generic implimentaion 
    //the initial idea was not to use the pipeline object  
  
    public interface IFilter
    {
        IPipelineObject Execute(IPipelineObject input);
    }

    public interface IFilter<in T, out TU> : IFilter
        where T : IPipelineObject
        where TU : IPipelineObject
    {

    }
}
