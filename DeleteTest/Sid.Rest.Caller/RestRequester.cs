using System;
using Sid.Pipeline.Core;


namespace Sid.Rest.Caller
{

    public class RestRequester<T, U> : IFilter<T, U>
        where T : class, IPipelineObject
        where U : class, IPipelineObject, new()
    {

        public IPipelineObject Execute(IPipelineObject input)
        {
            var result = RestHelper.Get(((T)input).Output.ToString(), null, null, null, null);
            
            var type = typeof(U);
            var instObject = Activator.CreateInstance(type);
            (instObject as U).Output = result;
            (instObject as U).OutputType = input.OutputType;

            return instObject as U;
        }

        public U Execute(T input)
        {
            throw new NotImplementedException();
        }
    }

}
