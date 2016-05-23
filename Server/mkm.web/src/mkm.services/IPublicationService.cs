using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mkm.services
{
    using mkm.model;

    public interface IPublicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<object> GetPublicationsForUser(string userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        Task<object> GetPublicationData(long postId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="publication"></param>
        /// <returns></returns>
        Task<object> AddPublication(string userId, Post publication);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="publication"></param>
        /// <returns></returns>
        Task<object> AddOfert(string userId, Ofert publication);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="postTitle"></param>
        /// <returns></returns>
        Task<object> VerifyPublication(string userId, string postTitle);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagTitle"></param>
        /// <returns></returns>
        Task<List<object>> VerifyTag(string tagTitle);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="tagName"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        Task<object> InsertTag(string userId, string tagName, long parentId = -1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="userId"></param>
        /// <param name="publicationId"></param>
        /// <param name="parentCommentId"></param>
        /// <returns></returns>
        Task<object> InsertComment(string comment, string userId, long publicationId, long parentCommentId = -1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="publicationId"></param>
        /// <returns></returns>
        Task<List<object>> GetComments(string userId, long publicationId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="publicationId"></param>
        /// <returns></returns>
        Task<object> AddPublicationLike(string userId, long publicationId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="publicationId"></param>
        /// <returns></returns>
        Task<object> RemovePublicationLike(string userId, long publicationId);
    }
}
