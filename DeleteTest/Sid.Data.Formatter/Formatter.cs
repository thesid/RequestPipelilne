using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sid.Pipeline.Core;
using Sid.Types;

namespace Sid.Data.Formatter
{
    public class Formatter<T, U> : IFilter<T, U>
        where T : class, IPipelineObject
        where U : class , IPipelineObject, new()
    {
        public IPipelineObject Execute(IPipelineObject input)
        {

            var outputResult = Converter.Process(input.Output.ToString(), input.OutputType.ToString());

            var type = typeof(U);
            var instObject = Activator.CreateInstance(type);
            (instObject as U).Output = outputResult;
            (instObject as U).OutputType = input.OutputType;

            return instObject as U;

          //  return new FormatResponse() { Output = outputResult, OutputType = input.OutputType.ToString() };
        }

        public U Execute(T input)
        {
            throw new NotImplementedException();
        }
    }

}
