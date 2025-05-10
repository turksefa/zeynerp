using Microsoft.AspNetCore.Mvc;

namespace zeynerp.Web.Controllers
{
    public class SatinalmaYonetimiController : Controller
    {
        public IActionResult MalzemeTalepler()
        {
            return View();
        }

        public IActionResult MalzemeTalepleri()
        {
            return View();
        }
    }
}