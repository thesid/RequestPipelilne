
namespace Request.Pipeline.Core
{
    //the basic operations that  a pipeline should perform which is registering and then execution
    public interface IPipeline
    {
        IPipelineObject Execute(IPipelineObject input);

        IPipeline Register<T, TU>(IFilter<T, TU> filter)
            where T : IPipelineObject
            where TU : IPipelineObject;
    }
}
