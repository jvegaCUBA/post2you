using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SharedPost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string SocialNetwork { get; set; }

        public DateTime Created { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public User User { get; set; }

        [ForeignKey("PostId")]
        public long PostId { get; set; }
        
        public Post Post { get; set; }
    }
}
