using mkm.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace mkm.services
{
    public class PostService : IPostService
    {

        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            this._context = context;
        }


        public async Task<Post> FindByIdAsync(int id)
        {
            return await _context.Posts.FirstOrDefaultAsync(item => item.PostId == id);
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return await _context.Posts.ToListAsync();
        }

      

    }
}
