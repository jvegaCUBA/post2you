using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using mkm.model;


namespace mkm.model
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryPost> CategoryPosts { get; set; }
        public DbSet<Favorite> Favorities { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<PostDenounce> PostDenounces { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<SharedPost> SharedPost { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // create post entity
            builder.Entity<User>(m => m.HasBaseType<IdentityUser>());
            builder.Entity<Post>();
            builder.Entity<Comment>();
            builder.Entity<Category>();
            builder.Entity<CategoryPost>();
            builder.Entity<SharedPost>();
            builder.Entity<PostDenounce>();
            builder.Entity<Notification>();
            builder.Entity<Like>();
            builder.Entity<Favorite>();
            builder.Entity<Relation>();

        }
    }
}
