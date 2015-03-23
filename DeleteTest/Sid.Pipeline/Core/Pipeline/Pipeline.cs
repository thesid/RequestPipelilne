using System.Collections.Generic;
using System.Linq;

namespace Sid.Pipeline.Core.Pipeline
{
    public class Pipeline : IPipeline
    {
        private readonly List<IFilter> _filters = new List<IFilter>();

        public IPipelineObject Execute(IPipelineObject input)
        {
            return _filters.Aggregate(input, (current, filter) => filter.Execute(current));
        }

        public IPipeline Register<T, TU>(IFilter<T, TU> filter)
            where T : IPipelineObject
            where TU : IPipelineObject
        {
            _filters.Add(filter);
            return this;
        }

    }

}
