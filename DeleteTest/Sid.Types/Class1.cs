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


    public class ResponseObject : IPipelineObject
    {
        public object Output { get; set; }
        public object OutputType { get; set; }
    }

    public class FormatResponse : IPipelineObject
    {
        public FormatResponse(ResponseObject responseObject)
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
