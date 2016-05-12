using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PostDenounce
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Comment { get; set; }

        [Timestamp]
        public byte[] Created { get; set; }

        [Timestamp]
        public byte[] Updated { get; set; }

        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public long PostId { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }
    }
}
