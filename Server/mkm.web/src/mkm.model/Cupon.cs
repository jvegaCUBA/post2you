using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.model
{
    using System.ComponentModel.DataAnnotations;

    public class Cupon
    {
        public long Id { get; set; }

        public string Code { get; set; }

        [Timestamp]
        public byte[] Created { get; set; }

        [Timestamp]
        public byte[] Updated { get; set; }

        public bool InUse { get; set; }

        public long OfertId { get; set; }

        public virtual Ofert Ofert { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
