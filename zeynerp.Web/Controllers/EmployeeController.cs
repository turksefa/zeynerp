using Microsoft.AspNetCore.Mvc;

namespace zeynerp.Web.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Employees()
        {
            return View();
        }
    }
}