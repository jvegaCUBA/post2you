using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace mkm.model
{
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.Data.Entity.Metadata.Internal;

    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Text { get; set; }

        public string Emoticons { get; set; }

        [Timestamp]
        public byte[] Created { get; set; }

        [Timestamp]
        public byte[] Updated { get; set; }

        public long PostId { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }

        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public User Author { get; set; }

        public long? ParentCommentId { get; set; }

        [ForeignKey("ParentCommentId")]
        public Comment ParentComment { get; set; }

        public virtual ICollection<Comment> SubComments { get; set; } 
    }
}
