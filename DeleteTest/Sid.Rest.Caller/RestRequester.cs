using System;
using Sid.Pipeline.Core;
using Sid.Types;

namespace Sid.Rest.Caller
{

    public class RestRequester<T, U> : IFilter<T, U>
        where T : class, IPipelineObject
        where U : class, IPipelineObject, new()
    {

        public IPipelineObject Execute(IPipelineObject input)
        {
            var result = RestHelper.Get(((T)input).Output.ToString(), null, null, null, null);
            return new { Output = result, input.OutputType } as U;
        }

        public U Execute(T input)
        {
            throw new NotImplementedException();
        }
    }

}
