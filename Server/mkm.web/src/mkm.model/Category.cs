using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.model
{
    public class Category
    {
        public long Id { get; set; }
        
        public string Text { get; set; }

        public TimeSpan Created { get; set; }

        public TimeSpan Updated { get; set; }

        public long? ApplicationUserId { get; set; }

        public ApplicationUser Author { get; set; }

        public long? CatgoryId { get; set; }

        public Category ParentCategory { get; set; }

        public ICollection<Category> SubCategories { get; set; } 
    }
}
