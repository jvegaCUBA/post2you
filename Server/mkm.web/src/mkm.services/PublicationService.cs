using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.services
{
    using System.Data;

    using mkm.model;
    using mkm.Services;

    using Microsoft.Data.Entity;

    public class PublicationService : IPublicationService
    {
        private readonly ApplicationDbContext _context;

        public readonly IUserService _userService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userService"></param>
        public PublicationService(ApplicationDbContext context, IUserService userService)
        {
            this._context = context;
            this._userService = userService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<object> GetPublicationsForUser(string userId)
        {
            var user = await this._userService.FindUserById(userId);
            if (user == null)
            {
                return false;//TODO:Sustituir por una respuesta para este caso
            }
            var pubs = await this._context.Posts
                .Where(m => m.Author.Id == user.Id
                || (user.Following.Any(follw => follw.UserFollowedId == m.Author.Id))
                || (m.Likes.Any(like => like.User.Id != user.Id && user.Following.Any(following => following.UserFollowedId == like.UserId)))
                )
                .Distinct()
                .OrderByDescending(m => m.Created)
                .ToListAsync();
            return pubs;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public async Task<object> GetPublicationData(long postId)
        {
            var post = await this._context.Posts.FirstOrDefaultAsync(m => m.Id == postId);
            if (post == null)
            {
                return null; //TODO:Sustituir por una respuesta para este caso
            }
            if (post is Ofert)
                return post as Ofert;
            return post;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="publication"></param>
        /// <returns></returns>
        public async Task<object> AddPublication(string userId, Post publication)
        {
            //TODO: Preparar en la respuesta las notificaciones pertinentes
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="publication"></param>
        /// <returns></returns>
        public async Task<object> AddOfert(string userId, Ofert publication)
        {
            //TODO: Preparar en la respuesta las notificaciones pertinentes
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="postTitle"></param>
        /// <returns></returns>
        public async Task<object> VerifyPublication(string userId, string postTitle)
        {
            var user = await this._userService.FindUserById(userId);
            if (user != null)
            {
                return
                    await
                    this._context.Posts.FirstOrDefaultAsync(m => m.UserId == user.Id && m.Title.Contains(postTitle));
            }
            return false;//TODO:Sustituir por una respuesta para este caso
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagTitle"></param>
        /// <returns></returns>
        public async Task<List<object>> VerifyTag(string tagTitle)
        {
            if (tagTitle == null)
                return null;

            return await this._context.Categories
                .Where(m => m.Text.Contains(tagTitle))
                .ToListAsync<object>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="tagName"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public async Task<object> InsertTag(string userId, string tagName, long parentId = -1)
        {
            try
            {
                var tag = this._context.Categories.FirstOrDefaultAsync(m => m.Text == tagName).Result;
                var user = this._userService.FindUserById(userId).Result;
                if (tag != null)
                    return false;
                tag = new Category()
                {
                    Author = user,
                    Text = tagName,
                    Created = DateTime.UtcNow
                };
                this._context.Categories.Add(tag);
                //TODO:Sustituir por una respuesta para este caso
                //TODO: Preparar en la respuesta las notificaciones pertinentes
                return await this._context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (OptimisticConcurrencyException)
            {
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
        /// <param name="comment"></param>
        /// <param name="userId"></param>
        /// <param name="publicationId"></param>
        /// <param name="parentCommentId"></param>
        /// <returns></returns>
        public async Task<object> InsertComment(string comment, string userId, long publicationId, long parentCommentId = -1)
        {
            if (string.IsNullOrEmpty(comment))
                return false; //TODO:Sustituir por una respuesta para este caso

            var user = await this._userService.FindUserById(userId);
            var pub = await this._context.Posts.FirstOrDefaultAsync(m => m.Id == publicationId);
            if (user == null || pub == null)
                return false;//TODO:Sustituir por una respuesta para este caso
            if (parentCommentId <= 0)
            {
                return false;//TODO:Sustituir por una respuesta para este caso
            }
            var parentComment = await this._context.Comments.FirstOrDefaultAsync(m => m.Id == parentCommentId);
            if (parentComment == null)
                return false;//TODO: Sustituir por una respuesta para este caso
            try
            {
                var newComment = new Comment()
                {
                    Created = DateTime.UtcNow,
                    Author = user,
                    ParentComment = parentComment,
                    Post = pub,
                    Text = comment
                };
                this._context.Comments.Add(newComment);
                //TODO: Preparar en la respuesta las notificaciones pertinentes
                return await this._context.SaveChangesAsync() > 0 ? true : false;
                //TODO:Sustituir por una respuesta para este caso
            }
            catch (OptimisticConcurrencyException)
            {
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
        /// <param name="userId"></param>
        /// <param name="publicationId"></param>
        /// <returns></returns>
        public async Task<List<object>> GetComments(string userId, long publicationId)
        {
            var user = await this._userService.FindUserById(userId);
            var pub = await this._context.Posts.FirstOrDefaultAsync(m => m.Id == publicationId);

            if (user != null && pub != null)
            {
                return await this._context.Comments
                    .Where(m => m.PostId == publicationId)
                    .ToListAsync<object>();
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="publicationId"></param>
        /// <returns></returns>
        public async Task<object> AddPublicationLike(string userId, long publicationId)
        {
            var pub = await this._context.Posts.FirstOrDefaultAsync(m => m.Id == publicationId);
            var user = await this._userService.FindUserById(userId);

            if (pub == null || user == null)
            {
                return false; //TODO:Sustituir por una respuesta para este caso
            }
            try
            {
                var like = new Like() { Created = DateTime.UtcNow, User = user, Post = pub };

                this._context.Likes.Add(like);
                pub.LikesCount++;
                //TODO:Sustituir por una respuesta para este caso
                //TODO: Preparar en la respuesta las notificaciones pertinentes
                return await this._context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (OptimisticConcurrencyException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="publicationId"></param>
        /// <returns></returns>
        public async Task<object> RemovePublicationLike(string userId, long publicationId)
        {
            var pub = await this._context.Posts.FirstOrDefaultAsync(m => m.Id == publicationId);
            var user = await this._userService.FindUserById(userId);

            if (pub == null || user == null)
            {
                return false; //TODO:Sustituir por una respuesta para este caso
            }

            var pubLike = await this._context.Likes.FirstOrDefaultAsync(m => m.UserId == user.Id && m.PostId == pub.Id);
            if (pubLike == null)
                return false;
            try
            {
                this._context.Likes.Remove(pubLike);
                pub.LikesCount--;

                //TODO:Sustituir por una respuesta para este caso
                //TODO: Preparar en la respuesta las notificaciones pertinentes
                return await this._context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (OptimisticConcurrencyException)
            {
                throw; //TODO:Sustituir por una respuesta para este caso
            }
            catch (Exception)
            {
                //TODO:Sustituir por una respuesta para este caso
                throw;
            }

        }
    }
}
