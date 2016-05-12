using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }

        [Timestamp]
        public byte[] Created { get; set; }

        [Timestamp]
        public byte[] Updated { get; set; }

        public bool? IsDenounced { get; set; }

        public bool? IsConfirmedDenounce { get; set; }

        public int CommentsCount { get; set; }

        public int LikesCount { get; set; }

        public string Categories { get; set; }

        public int LinksCount { get; set; }

        public int SharesCount { get; set; }

        public int ViewsCount { get; set; }

        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User Author { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; }

        public virtual ICollection<PostDenounce> Denounces { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }

        public virtual ICollection<SharedPost> Shares { get; set; }

    }
}
