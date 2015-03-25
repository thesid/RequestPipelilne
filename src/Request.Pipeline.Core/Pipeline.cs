using System.Collections.Generic;
using System.Linq;

namespace Request.Pipeline.Core
{
    //the heart of the pipeline
    //I accumulate all the filters and then start executing them one by one in the sequesnce of accumulation 
    //using the IEnumerable aggrigator
    //using a list to aggrigate them together.

    public class Pipeline : IPipeline
    {
        private readonly IList<IFilter> _filters = new List<IFilter>();

        public IPipelineObject Execute(IPipelineObject input)
        {
            return _filters.Aggregate(input, (current, filter) => filter.Execute(current));
        }

        public IPipeline Register<T, TU>(IFilter<T,TU> filter)
            where T : IPipelineObject
            where TU : IPipelineObject
        {
            _filters.Add(filter);
            return this;
        }

    }

}
