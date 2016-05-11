using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.model
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        public long Id { get; set; }
        
        public string Text { get; set; }

        public TimeSpan Created { get; set; }

        public TimeSpan Updated { get; set; }

        public long? UserId { get; set; }

        [ForeignKey("UserId")]
        public User Author { get; set; }

        public long? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category ParentCategory { get; set; }

        public ICollection<Category> SubCategories { get; set; } 
    }
}
