using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CategoryPost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTime Created { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        [Required]
        [ForeignKey("Post")]
        public long PostId { get; set; }

        public Post Post { get; set; }

        [Required]
        [ForeignKey("Category")]
        public long CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
