using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        
        public string Text { get; set; }

        public DateTime Created { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        [ForeignKey("Author")]
        public string UserId { get; set; }
        
        public User Author { get; set; }

        [ForeignKey("ParentCategory")]
        public long? CategoryId { get; set; }
        
        public Category ParentCategory { get; set; }

        public virtual ICollection<Category> SubCategories { get; set; } 
    }
}
