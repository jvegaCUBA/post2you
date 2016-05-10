using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace mkm.model
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        ICollection<Post> Posts { get; set; }

        ICollection<Favorite> Favorites { get; set; }

        ICollection<Comment> Comments { get; set; }
    }
}
