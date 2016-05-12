using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.model
{
    using System.ComponentModel.DataAnnotations;

    public class Reservation
    {
        public long Id { get; set; }

        public string Code { get; set; }

        [Timestamp]
        public byte[] Created { get; set; }

        [Timestamp]
        public byte[] Updated { get; set; }

        public bool IsActive { get; set; }

        public bool IsCanceled { get; set; }

        public DateTime CancelationDate { get; set; }

        public string Status { get; set; }

        public long ClientId { get; set; }

        public virtual Client Client { get; set; }

        public long CuponId { get; set; }

        public virtual Cupon Cupon { get; set; }
    }
}
