using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace mkm.model
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        [DefaultValue(0)]
        public int FollowsCount { get; set; }

        [DefaultValue(0)]
        public int FollowersCount { get; set; }
        
        public DateTime Created { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<PostDenounce> Denounces { get; set; }

        public virtual ICollection<Relation> Following { get; set; }

        public virtual ICollection<Relation> Followers { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }

        public virtual ICollection<SharedPost> SharedPosts { get; set; }

        public virtual ICollection<Category> Categories { get; set; } 
    }
}
