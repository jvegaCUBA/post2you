using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Relation
    {
        public long Id { get; set; }

        [Timestamp]
        public byte[] Created { get; set; }

        public long UserFollowId { get; set; }

        [ForeignKey("UserFollowId")]
        public User UserFollow { get; set; }

        public long UserFollowedId { get; set; }

        [ForeignKey("UserFollowedId")]
        public User UserFollowed { get; set; }
    }
}
