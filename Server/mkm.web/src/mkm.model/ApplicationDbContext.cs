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
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // User builder
            var userBuilder = builder.Entity<User>();
            userBuilder.HasBaseType<IdentityUser>();
            userBuilder.HasMany(user => user.Following).WithOne(relation => relation.UserFollow);
            userBuilder.HasMany(user => user.Followers).WithOne(relation => relation.UserFollowed);
            userBuilder.HasMany(user => user.Comments).WithOne(comment => comment.Author);
            userBuilder.HasMany(user => user.Likes).WithOne(like => like.User);
            userBuilder.HasMany(user => user.Favorites).WithOne(favorite => favorite.User);
            userBuilder.HasMany(user => user.Denounces).WithOne(denounce => denounce.User);
            userBuilder.HasMany(user => user.SharedPosts).WithOne(shared => shared.User);
            userBuilder.HasMany(user => user.Notifications).WithOne(notif => notif.User);
            userBuilder.HasMany(user => user.Categories).WithOne(category => category.Author);

            var businessBuilder = builder.Entity<Business>();
            businessBuilder.HasBaseType<User>();
            businessBuilder.HasMany(business => business.Oferts).WithOne(post => (Business)post.Author);

            var clientBuilder = builder.Entity<Client>();
            clientBuilder.HasBaseType<User>();
            clientBuilder.HasMany(client => client.Posts).WithOne(post => (Client)post.Author);
            clientBuilder.HasMany(client => client.Reservations).WithOne(reserv => reserv.Client);

            // Relation builder
            var relationEntity = builder.Entity<Relation>();
            //relationEntity.HasOne(m => m.UserFollow).WithMany(m => m.Following);
            //relationEntity.HasOne(m => m.UserFollowed).WithMany(m => m.Followers);

            var postBuilder = builder.Entity<Post>();
            postBuilder.Property(post => post.RowVersion).IsConcurrencyToken();
            postBuilder.HasMany(post => post.CategoriesCollection).WithOne(postCat => postCat.Post);

            var ofertBuilder = builder.Entity<Ofert>();
            ofertBuilder.HasBaseType<Post>();
            ofertBuilder.HasMany(ofert => ofert.Cupons).WithOne(cupon => cupon.Ofert);

            var commentBuilder = builder.Entity<Comment>();
            commentBuilder.Property(entity => entity.RowVersion).IsConcurrencyToken();
            commentBuilder.HasOne(comment => comment.ParentComment).WithMany(comment => comment.SubComments);

            var categoryBuilder = builder.Entity<Category>();
            categoryBuilder.HasMany(category => category.SubCategories).WithOne(cat => cat.ParentCategory);

            var categoryPost = builder.Entity<CategoryPost>();

            builder.Entity<SharedPost>();

            builder.Entity<PostDenounce>();

            builder.Entity<Notification>();

            // Like builder
            var likeBuilder = builder.Entity<Like>();
            likeBuilder.Property(entity => entity.RowVersion).IsConcurrencyToken();

            //Favorite builder
            var fovoriteBuilder = builder.Entity<Favorite>();
            fovoriteBuilder.Property(entity => entity.RowVersion).IsConcurrencyToken();


        }
    }
}
