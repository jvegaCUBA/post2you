using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.model
{
    public class Ofert : Post
    {
        public int Capacity { get; set; }

        public DateTime DueDate { get; set; } 

        public bool IsActive { get; set; }

        public int? RealPrice { get; set; }

        public decimal? DiscountPrice { get; set; }

        public int? DiscountPercent { get; set; }

        public int RealCupons { get; set; }

        public int ReservedCupons { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }
        
        public virtual ICollection<Cupon> Cupons { get; set; } 
    }
}
