using Microsoft.AspNetCore.Mvc;

namespace zeynerp.Web.Controllers
{
    public class ProcurementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}