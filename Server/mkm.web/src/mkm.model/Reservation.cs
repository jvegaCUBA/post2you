using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Reservation
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public DateTime Created { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public bool IsActive { get; set; }

        public bool IsCanceled { get; set; }

        public DateTime CancelationDate { get; set; }

        public string Status { get; set; }

        [ForeignKey("Client")]
        public string ClientId { get; set; }

        public virtual Client Client { get; set; }

        [ForeignKey("Cupon")]
        public long CuponId { get; set; }

        public virtual Cupon Cupon { get; set; }
    }
}
