using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.core.Response
{
    public class CollectionResponse : GenericResponse
    {
        public IList<object> Data { get; set; } 
    }
}
