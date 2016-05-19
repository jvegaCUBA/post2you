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
        Task<object> GetUserFavorites(string userId);

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
        Task<object> GetUserPublications(string userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<object> GetUserFollows(string userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<object> GetUserFollowers(string userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userFollow"></param>
        /// <param name="userFollowed"></param>
        /// <returns></returns>
        Task<object> AddUserFollow(string userFollow, string userFollowed);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<User> FindUserById(string userId);

        /// <summary>
        /// Verify if anyone has the same user name or email
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<object> FindUser(string userName, string email);

        /// <summary>
        /// Return user profile data
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<object> GetUserProfileData(string userId, string userName, string email);
    }
}