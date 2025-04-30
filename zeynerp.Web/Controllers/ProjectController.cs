using Microsoft.AspNetCore.Mvc;

namespace zeynerp.Web.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateOffer()
        {
            return View();
        }
    }
}