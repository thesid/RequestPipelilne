using System.Collections.Generic;

namespace Sid.Pipeline.Core
{
   public interface IPipelineObject
    {
       object Output { get; set; }
       object OutputType { get; set; }
    }
}
