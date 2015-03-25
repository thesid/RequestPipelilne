using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request.Pipeline.Core
{
    public abstract class FilterBase<T, TU> : IFilter<T, TU>
        where T : IPipelineObject
        where TU : IPipelineObject, new()
    {
        protected abstract TU Process(T input);

        IPipelineObject IFilter.Execute(IPipelineObject input)
        {
            return Execute((T)input);
        }

        public TU Execute(T input)
        {
            return Process(input);
        }
    }
}
