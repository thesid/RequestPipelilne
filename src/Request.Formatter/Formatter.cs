using System;
using Request.Pipeline.Core;

namespace Request.Formatter
{

    //the filter to the pipeline that need an implimentation of the Ifilter
    //the execute method is where the format log goes in.
    // the calling of the appropriate formatted is decided here.

    // I ma using activator to create an instance and extract the result out of it 
    // not sure if this would be the best way to do it 
    // though the current though says it will work and i am going with it.
    public class Formatter<T, TU> : IFilter<T,TU>
        where T : class, IPipelineObject
        where TU : class , IPipelineObject, new()
    {
        public IPipelineObject Execute(IPipelineObject input)
        {
            var outputResult = Converter.Process(input.Output.ToString(), input.OutputType.ToString());

            var type = typeof(TU);
            var instObject = Activator.CreateInstance(type);
            (instObject as TU).Output = outputResult;
            (instObject as TU).OutputType = input.OutputType;

            return instObject as TU;
        }

    }

}
