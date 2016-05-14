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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTime Created { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        [ForeignKey("UserFollow")]
        public string UserFollowId { get; set; }
        
        public virtual User UserFollow { get; set; }

        [ForeignKey("UserFollowed")]
        public string UserFollowedId { get; set; }
        
        public virtual User UserFollowed { get; set; }
    }
}
