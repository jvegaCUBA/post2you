using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.model
{
    public class Resource
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public bool IsPrincipal { get; set; }
        public bool Order { get; set; }
        public byte[] Created { get; set; }
        public byte[] Updated { get; set; }
    }
}
