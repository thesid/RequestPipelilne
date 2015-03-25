using Request.Pipeline.Core;

namespace Request.Types
{
    public class RequestObject : IPipelineObject
    {
        public RequestObject(string request,string outputType)
        {
            Output = request;
            OutputType = outputType;
        }

        public object Output { get; set; }
        public object OutputType { get; set; }

    }
}
