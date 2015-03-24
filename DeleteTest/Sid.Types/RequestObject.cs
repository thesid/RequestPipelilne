using Sid.Pipeline.Core;

namespace Sid.Types
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
