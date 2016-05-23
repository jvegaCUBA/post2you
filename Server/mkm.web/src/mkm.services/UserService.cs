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
        /// Return user publications favorites
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<object> GetUserFavorites(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return null;//TODO: Sustituir por una respuesta para esta situacion

            var favoritesPost = await this._context.Favorities
                .Where(m => m.UserId == userId
                && (m.Post.IsDeleted == null || m.Post.IsDeleted == false))
                .Select(m => m.Post)
                .OrderByDescending(m => m.Created)
                .ToListAsync();

            var favoriteList = new List<object>();
            foreach (var post in favoritesPost)
            {
                var ofert = post as Ofert;
                if (ofert != null)
                    favoriteList.Add(new
                    {
                        ofert.Id,
                        Author = $"{ofert.Author.Name} {ofert.Author.LastName}",
                        ofert.Categories,
                        ofert.CommentsCount,
                        ofert.Created,
                        ofert.LikesCount,
                        ofert.ViewsCount,
                        ofert.SharesCount,
                        ofert.Title,
                        ofert.Description,
                        ofert.Capacity,
                        ofert.DiscountPercent,
                        ofert.DiscountPrice,
                        ofert.DueDate,
                        ofert.FinishDate,
                        ofert.RealCupons,
                        ofert.RealPrice,
                        ofert.ReservedCupons,
                        ofert.StartDate,
                        ofert.LinksCount,
                        Type = ofert.GetType().Name,
                    });
                else
                    favoriteList.Add(new
                    {
                        post.Id,
                        Author = $"{post.Author.Name} {post.Author.LastName}",
                        post.Categories,
                        post.CommentsCount,
                        post.Created,
                        post.LikesCount,
                        post.ViewsCount,
                        post.SharesCount,
                        post.Title,
                        post.Description,
                    });
            }

            return favoriteList;
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

                if (post == null || user == null)
                {
                    return false;//TODO:Sustituir por una respuesta para este caso
                }
                var isAlredyInFavorite = user.Favorites.Any(m => m.PostId == post.Id);
                if (!isAlredyInFavorite)
                {
                    var favorite = new Favorite() { Created = DateTime.UtcNow, Post = post, User = user };
                    this._context.Add(favorite);
                    post.SharesCount++;
                    //TODO: Preparar las notificaciones pertinentes para este caso
                    int saved = await this._context.SaveChangesAsync();
                    return saved > 0 ? true : false;
                }
                else
                {
                    /*TODO: Devolver objeto con formato standard de respuestas*/
                }

                return false;
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
                var user = await this.FindUserById(userId);
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
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> FindUserById(string userId)
        {
            var user = await this._context.Users.FirstOrDefaultAsync(m => m.Id == userId);
            return user;
        }

        public async Task<object> FindUser(string userName, string email)
        {
            var user = await this._context.Users.FirstOrDefaultAsync(m => (userName == null || m.UserName == userName)
            && (email == null || m.Email == email));

            //TODO:Cambiar respuesta por formato standard de respuestas
            return user ?? null;
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
        public async Task<object> GetUserPublications(string userId)
        {
            /*TODO: Cambiar el tipo de retorno por un objeto generico
            que devuelva un codigo y un mensaje en cada camino*/

            var user = await this.FindUserById(userId);
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
        public async Task<object> GetUserFollows(string userId)
        {
            var user = await this.FindUserById(userId);
            if (user != null)
            {
                return await this._context.Relations
                     .Where(m => m.UserFollowId == user.Id)
                     .Select(m => m.UserFollowed).ToListAsync<object>();
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<object> GetUserFollowers(string userId)
        {
            var user = await this.FindUserById(userId);
            if (user != null)
            {
                return await this._context.Relations
                     .Where(m => m.UserFollowedId == user.Id)
                     .Select(m => m.UserFollow).ToListAsync<object>();
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userFollowId"></param>
        /// <param name="userFollowedId"></param>
        /// <returns></returns>
        public async Task<object> AddUserFollow(string userFollowId, string userFollowedId)
        {
            var userFollow = await this.FindUserById(userFollowId);
            var userFollowed = await this.FindUserById(userFollowedId);

            if (userFollowed == null || userFollow == null)
            {
                return null;
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
                //TODO: Create coresponding notifications to related users
                this._context.Relations.Add(relation);
                return await this._context.SaveChangesAsync() > 0 ? true : false;
            }
        }
    }
}
