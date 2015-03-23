namespace Sid.Pipeline.Core
{
    public interface IFilter
    {
        IPipelineObject Execute(IPipelineObject input);
    }

    public interface IFilter<in T, out TU> : IFilter
        where T : IPipelineObject
        where TU : IPipelineObject
    {
        TU Execute(T input);
    }


}
