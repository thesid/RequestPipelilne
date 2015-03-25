using Request.Pipeline.Core;

namespace Request.Types
{
    public class ResponseObject : IPipelineObject
    {
        public object Output { get; set; }
        public object OutputType { get; set; }
    }
}