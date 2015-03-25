
using System;
using System.Xml;
using Request.Formatter;
using Request.Requester;
using  Request.Pipeline.Core;
using Request.Types;

namespace Request.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //create a pipeline that would register multiple functions that it has to perform
            //the pipeline would resigter the module and the iniput and output types that the module requires.
            //we could add more modules to format and do data orchestration and get the filterd data if we would write 
            //another filter to the pipeline.
            var pipeline = new Pipeline.Core.Pipeline()
                .Register(new RestRequester<RequestObject, ResponseObject>())
                .Register(new Formatter<ResponseObject, FormatResponse<ResponseObject>>());

            // making a sample rest request which would return a XML result or a Json reseult
            //Some test's that i could have written testcases for 
            GetXMLResponse(pipeline);
            GetXMLResponseWithError(pipeline);
            GetJsonResponse(pipeline);

            Console.Read();
        }

        private static void GetXMLResponse(IPipeline pipeline)
        {
            try
            {
                Console.WriteLine("************ XML OUTPUT ************");
                var result = pipeline.Execute(new RequestObject("http://maps.googleapis.com/maps/api/geocode/json?address=Wakad", "XML"));
                Console.WriteLine((result.Output as XmlDocument).InnerXml);
           
            }
            catch (Exception)
            {
                //throw
                Console.WriteLine("oops Something went wrong");
                //this is just doing a fallback; could have actually 
                //tracked if the request failed and propogated teh error back

                //you could test this by altering the url :)
                    
            }
        }
        private static void GetXMLResponseWithError(IPipeline pipeline)
        {
            try
            {
                Console.WriteLine("************ XML OUTPUT ************");
                var result = pipeline.Execute(new RequestObject("http://maps.", "XML"));
                Console.WriteLine((result.Output as XmlDocument).InnerXml);

            }
            catch (Exception)
            {
                //throw
                Console.WriteLine("oops Something went wrong");
                
            }
        }

        private static void GetJsonResponse(IPipeline pipeline)
        {
            try
            {
                Console.WriteLine("************ JSON OUTPUT ************");
                var result = pipeline.Execute(new RequestObject("http://maps.googleapis.com/maps/api/geocode/json?address=Wakad", "json"));
                Console.WriteLine(result.Output);

            }
            catch (Exception)
            {
                    
//                throw;
                Console.WriteLine("oops Something went wrong");
                //Same as above 
            }
            

        }
    }
}
