using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.model
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Post
    {
        public long Id { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }

        public TimeSpan Created { get; set; }

        public TimeSpan Updated { get; set; }

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
        public ApplicationUser Author { get; set; }

        ICollection<Comment> Comments { get; set; } 

        ICollection<Like> Likes { get; set; }

        ICollection<Favorite> Favorites { get; set; }

        ICollection<PostDenounce> Denounces { get; set; }

    }
}
