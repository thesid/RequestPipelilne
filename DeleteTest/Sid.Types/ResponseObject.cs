using Sid.Pipeline.Core;

namespace Sid.Types
{
    public class ResponseObject : IPipelineObject
    {
        public object Output { get; set; }
        public object OutputType { get; set; }
    }
}