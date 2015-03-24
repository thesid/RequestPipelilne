using System;
using Sid.Pipeline.Core;

namespace Sid.Rest.Caller
{
    public class RestRequester<T, S> : IFilter<T, S>
        where T : class, IPipelineObject
        where S : class, IPipelineObject, new()
    {
        public IPipelineObject Execute(IPipelineObject input)
        {
            var result = RestHelper.Get(((T)input).Output.ToString(), null, null, null, null);
            
            var type = typeof(S);
            var instObject = Activator.CreateInstance(type);
            (instObject as S).Output = result;
            (instObject as S).OutputType = input.OutputType;

            return instObject as S;
        }

        public S Execute(T input)
        {
            throw new NotImplementedException();
        }
    }

}
