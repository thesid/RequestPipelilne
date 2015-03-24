using Sid.Data.Formatter;
using Sid.Pipeline.Core.Pipeline;
using Sid.Rest.Caller;
using Sid.Types;

namespace DeleteTest
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var pipeline = new Pipeline()
                .Register(new RestRequester<RequestObject, ResponseObject>())
                .Register(new Formatter<ResponseObject, FormatResponse<ResponseObject>>());

            var result = pipeline.Execute(new RequestObject("http://maps.googleapis.com/maps/api/geocode/json?address=Kalewadi%20Phata", "XML"));
            var output = result.Output;

        }
    }

   

}
