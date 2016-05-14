using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using mkm.model;

namespace mkm.web.Controllers
{
    using mkm.Services;

    using Microsoft.AspNet.Authorization;

    [Produces("application/json")]
    [Route("api/user")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}",Name = "favorites")]
        public async Task<IActionResult> GetFavorites([FromForm]string id)
        {
            var favoriteList = await this._userService.GetUserFavorites(id);
            return this.Json(favoriteList);
        } 
        
    }
}