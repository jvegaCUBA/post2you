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

        public DateTime Created { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        [ForeignKey("Post")]
        public long PostId { get; set; }
        
        public Post Post { get; set; }

        [ForeignKey("Author")]
        public string UserId { get; set; }

        public virtual User Author { get; set; }

        [ForeignKey("ParentComment")]
        public long? ParentCommentId { get; set; }
        
        public Comment ParentComment { get; set; }

        public virtual ICollection<Comment> SubComments { get; set; } 
    }
}
