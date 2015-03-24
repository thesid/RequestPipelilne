using Sid.Pipeline.Core;

namespace Sid.Types
{
    public class FormatResponse<T> : IPipelineObject
    {
        public FormatResponse(T responseObject)
        {
            Output = responseObject;
        }

        public FormatResponse()
        {
          
        }

        public object Output { get; set; }
        public object OutputType { get; set; }
      
    }
}