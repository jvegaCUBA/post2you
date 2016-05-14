using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.model
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public bool? IsDenounced { get; set; }

        public bool? IsConfirmedDenounce { get; set; }

        [DefaultValue(0)]
        public int CommentsCount { get; set; }

        [DefaultValue(0)]
        public int LikesCount { get; set; }

        public string Categories { get; set; }

        [DefaultValue(0)]
        public int LinksCount { get; set; }

        [DefaultValue(0)]
        public int SharesCount { get; set; }

        [DefaultValue(0)]
        public int ViewsCount { get; set; }

        [ForeignKey("Author")]
        public string UserId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; }

        public virtual ICollection<PostDenounce> Denounces { get; set; }

        //public virtual ICollection<Resource> Resources { get; set; }

        public virtual ICollection<SharedPost> Shares { get; set; }

        public virtual ICollection<CategoryPost> CategoriesCollection { get; set; }

    }
}
