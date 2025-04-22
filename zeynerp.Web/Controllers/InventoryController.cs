using Microsoft.AspNetCore.Mvc;

namespace zeynerp.Web.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}