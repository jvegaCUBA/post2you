using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mkm.model;

namespace mkm.Services
{
    using Microsoft.Data.Entity;

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public UserService(ApplicationDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<object>> GetUserFavorites(string userId)
        {
            return await this._context.Favorities.Where(m => m.UserId == userId).OrderByDescending(m => m.Created).ToListAsync<object>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="publicationId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<object> InserPublicationToFavorite(long publicationId, string userId)
        {
            //TODO: Cambiar el tipo de retorno por un objeto generico que devuelva un codigo y un mensaje en cada camino
            var user = await this._context.Users.FirstOrDefaultAsync(m => m.Id == userId);
            var post = await this._context.Posts.FirstOrDefaultAsync(m => m.Id == publicationId);

            if (post != null && user != null)
            {
                var isAlredyInFavorite = user.Favorites.Any(m => m.PostId == post.Id);
                if (!isAlredyInFavorite)
                {
                    var favorite = new Favorite() { Created = DateTime.UtcNow, Post = post, User = user };
                    this._context.Add(favorite);
                    int saved = await this._context.SaveChangesAsync();
                    return saved > 0 ? true : false;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="publicationId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<object> DeletePublicationFromFavorite(long publicationId, string userId)
        {
            var user = await this.FindUser(userId);

            var pubInFavorite = user?.Favorites.FirstOrDefault(m => m.PostId == publicationId);
            //TODO: Cambiar el tipo de retorno por un objeto generico que devuelva un codigo y un mensaje en cada camino 
            if (pubInFavorite == null)
            {
                return false;
            }
            this._context.Favorities.Remove(pubInFavorite);
            return await this._context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<User> FindUser(string userId)
        {
            var user = await this._context.Users.FirstOrDefaultAsync(m => m.Id == userId);
            return user;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<object>> GetUserPublications(string userId)
        {
            /*TODO: Cambiar el tipo de retorno por un objeto generico
            que devuelva un codigo y un mensaje en cada camino*/

            var user = await this.FindUser(userId);
            if (user != null)
            {
                var publications = await this._context.Posts.Where(m => m.Author == user).ToListAsync();
                var listReturn = new List<object>();
                foreach (var pub in publications)
                {
                    if (pub is Ofert)
                    {
                        listReturn.Add((pub as Ofert));
                    }
                    listReturn.Add(pub);
                }

                return listReturn;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<object>> GetUserFollows(string userId)
        {

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<object>> GetUserFollowers(string userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> AddUserFollow(string userFollow, string userFollowed)
        {
            throw new NotImplementedException();
        }
    }
}
