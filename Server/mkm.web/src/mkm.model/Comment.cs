using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace mkm.model
{
    using Microsoft.Data.Entity.Metadata.Internal;

    public class Comment
    {
        public long Id { get; set; }

        public string Text { get; set; }

        public string Emoticons { get; set; }

        public TimeSpan Created { get; set; }

        public long PostId { get; set; }

        public Post Post { get; set; }

        public long ApplicationUserId { get; set; }

        public ApplicationUser User { get; set; }

        public long? ParentCommentId { get; set; }

        public Comment ParentComment { get; set; }

        public ICollection<Comment> SubComments { get; set; } 
    }
}
