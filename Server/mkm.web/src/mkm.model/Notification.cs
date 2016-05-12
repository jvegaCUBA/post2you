using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Text { get; set; }

        public bool IsViewed { get; set; }

        [Timestamp]
        public byte[] Created { get; set; }

        [Timestamp]
        public byte[] Updated { get; set; }

        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
