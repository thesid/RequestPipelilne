using System;
using Request.Pipeline.Core;

namespace Request.Requester
{
    public class RestRequester<T, TU> : IFilter<T,TU>
        where T : class, IPipelineObject
        where TU : class, IPipelineObject
    {
        public IPipelineObject Execute(IPipelineObject input)
        {
            //using the rest helper to make the rest call
            //could have passed the diffrent parts as parameters 
            //bus currently assuming that i just have input url and passing the rest as null's
            var result = RestHelper.Get(((T)input).Output.ToString(), null, null, null, null);

            var type = typeof(TU);
            var instObject = Activator.CreateInstance(type);
            (instObject as TU).Output = result;
            (instObject as TU).OutputType = input.OutputType;

            return instObject as TU;
        }

    }

}
