using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.model
{
    public class Client : User
    {
        public int ActiveReservations { get; set; }

        public int ReservationsCount { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; } 
    }
}
