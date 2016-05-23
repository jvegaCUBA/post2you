using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using mkm.services;

namespace mkm.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;


        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public async Task<IActionResult> GetPostById(int id)
        {
            var post = await _postService.FindByIdAsync(id);

            return Json(post);
        }
        public async Task<IActionResult> GetAllPosts()
        {
            var post = await _postService.GetAllPosts();

            return Json(post);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
