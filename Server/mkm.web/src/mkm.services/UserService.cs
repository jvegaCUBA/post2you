using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mkm.model;

namespace mkm.Services
{
    using System.Data;

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
            return await this._context.Favorities.Where(m => m.UserId == userId)
                .Select(m => m.Post)
                .OrderByDescending(m => m.Created)
                .ToListAsync<object>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="publicationId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<object> InserPublicationToFavorite(long publicationId, string userId)
        {
            try
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
                        post.SharesCount++;
                        int saved = await this._context.SaveChangesAsync();
                        return saved > 0 ? true : false;
                    }
                    else
                    {
                        /*TODO: Devolver objeto con formato standard de respuestas*/
                    }
                }

                return false;
            }
            catch (OptimisticConcurrencyException)
            {
                //TODO:Devolver respuesta para los problemas de concurencia
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="publicationId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<object> DeletePublicationFromFavorite(long publicationId, string userId)
        {
            try
            {
                var user = await this.FindUser(userId);
                if (user != null)
                {
                    var pubInFavorite = user.Favorites.FirstOrDefault(m => m.PostId == publicationId);
                    //TODO: Cambiar el tipo de retorno por un objeto generico que devuelva un codigo y un mensaje en cada camino 
                    if (pubInFavorite == null)
                    {
                        return false;
                    }
                    this._context.Favorities.Remove(pubInFavorite);
                    pubInFavorite.Post.FavoritesCount--;
                    return await this._context.SaveChangesAsync() > 0 ? true : false;
                }
                else
                {
                    //TODO: Cambiar la respuesta por un formato de respueta standard
                    return false;
                }

            }
            catch (OptimisticConcurrencyException)
            {
                //TODO:Devolver respuesta para los problemas de concurencia
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> FindUser(string userId)
        {
            var user = await this._context.Users.FirstOrDefaultAsync(m => m.Id == userId);
            return user;
        }

        public Task<object> FindUser(string userName, string email)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetUserProfileData(string userId, string userName, string email)
        {
            throw new NotImplementedException();
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
            var user = await this.FindUser(userId);
            if (user != null)
            {
                return await this._context.Relations
                     .Where(m => m.UserFollowId == user.Id)
                     .Select(m => m.UserFollowed).ToListAsync<object>();
            }

            throw new ObjectNotFoundException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<object>> GetUserFollowers(string userId)
        {
            var user = await this.FindUser(userId);
            if (user != null)
            {
                return await this._context.Relations
                     .Where(m => m.UserFollowedId == user.Id)
                     .Select(m => m.UserFollow).ToListAsync<object>();
            }

            throw new ObjectNotFoundException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userFollowId"></param>
        /// <param name="userFollowedId"></param>
        /// <returns></returns>
        public async Task<object> AddUserFollow(string userFollowId, string userFollowedId)
        {
            var userFollow = await this.FindUser(userFollowId);
            var userFollowed = await this.FindUser(userFollowedId);

            if (userFollowed == null || userFollow == null)
            {
                throw new ObjectNotFoundException();
            }
            var existRelation = await this._context.Relations
                                          .AnyAsync(m => m.UserFollowId == userFollow.Id && m.UserFollowedId == userFollowed.Id);
            if (existRelation)
            {
                //TODO:Cambiar respuesta por formato standard de respuestas
                return false;
            }
            else
            {
                var relation = new Relation()
                {
                    Created = DateTime.UtcNow,
                    UserFollow = userFollow,
                    UserFollowed = userFollowed
                };
                userFollow.FollowsCount++;
                userFollowed.FollowersCount++;
                this._context.Relations.Add(relation);
                return await this._context.SaveChangesAsync() > 0 ? true : false;
            }
        }
    }
}
