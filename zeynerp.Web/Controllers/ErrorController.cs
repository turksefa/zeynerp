using Microsoft.AspNetCore.Mvc;

namespace zeynerp.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult EntityNotFound()
        {
            return View();
        }
    }
}