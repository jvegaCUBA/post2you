using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using mkm.model;

namespace mkm.web.Controllers
{
    using System.Security.Principal;

    using mkm.Services;

    using Microsoft.AspNet.Authorization;

    //[Produces("application/json")]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetFavorites()
        {
            
            //var favoriteList = await this._userService.GetUserFavorites("1");
            return this.Json(true);
        }
        
    }
}