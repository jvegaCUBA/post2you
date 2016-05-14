namespace mkm.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using mkm.model;

    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<object>> GetUserFavorites(string userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="publicationId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<object> InserPublicationToFavorite(long publicationId, string userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="publicationId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<object> DeletePublicationFromFavorite(long publicationId, string userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<object>> GetUserPublications(string userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<object>> GetUserFollows(string userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<object>> GetUserFollowers(string userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> AddUserFollow(string userFollow, string userFollowed);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<User> FindUser(string userId);
    }
}