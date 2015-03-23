namespace Sid.Pipeline.Core.Pipeline
{
    public interface IPipeline
    {
        IPipelineObject Execute(IPipelineObject input);

        IPipeline Register<T, TU>(IFilter<T, TU> filter)
            where T : IPipelineObject
            where TU : IPipelineObject;
    }

}
