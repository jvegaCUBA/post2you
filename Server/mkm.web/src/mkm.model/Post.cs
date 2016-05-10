using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.model
{
    public class Post
    {
        public long Id { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }

        public TimeSpan Created { get; set; }

        public TimeSpan Updated { get; set; }

        public bool? IsDenounced { get; set; }

        public bool? IsConfirmedDenounce { get; set; }

        public int CantComments { get; set; }

        public int CantLikes { get; set; }

        public string Categories { get; set; }

        public int CantLinks { get; set; }

        public int CantShares { get; set; }

        public long ApplicationUserId { get; set; }

        public ApplicationUser Author { get; set; }

        ICollection<Comment> Comments { get; set; } 

    }
}
