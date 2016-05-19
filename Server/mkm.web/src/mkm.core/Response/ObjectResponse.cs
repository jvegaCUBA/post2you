using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.core.Response
{
    public class ObjectResponse : GenericResponse
    {
        public object Data { get; set; }
    }
}
