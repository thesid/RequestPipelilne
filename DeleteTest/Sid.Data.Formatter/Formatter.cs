using System;
using Sid.Pipeline.Core;

namespace Sid.Data.Formatter
{
    public class Formatter<T, S> : IFilter<T, S>
        where T : class, IPipelineObject
        where S : class , IPipelineObject, new()
    {
        public IPipelineObject Execute(IPipelineObject input)
        {
            var outputResult = Converter.Process(input.Output.ToString(), input.OutputType.ToString());

            var type = typeof(S);
            var instObject = Activator.CreateInstance(type);
            (instObject as S).Output = outputResult;
            (instObject as S).OutputType = input.OutputType;

            return instObject as S;
        }

        public S Execute(T input)
        {
            throw new NotImplementedException();
        }
    }

}
