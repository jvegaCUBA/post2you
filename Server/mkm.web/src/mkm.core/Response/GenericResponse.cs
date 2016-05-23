using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.core.Response
{
    public class GenericResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string[] NotifyUsers { get; set; }
         
    }
}
