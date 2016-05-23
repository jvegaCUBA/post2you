using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.model
{
    public class Business : User
    {
        public string ActivityDescription { get; set; }

        public int OfertCount { get; set; }

        public int ActiveOfertCount { get; set; }

        public virtual ICollection<Ofert> Oferts { get; set; } 
    }
}
