using mkm.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.services
{
    public interface IPostService
    {
        Task<Post> FindByIdAsync(int id);

        Task<List<Post>> GetAllPosts();
    }
}
