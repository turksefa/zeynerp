using Microsoft.AspNetCore.Mvc;
using zeynerp.Application.Services;
using zeynerp.Infrastructure.Services;

namespace zeynerp.Web.Controllers;

public class HomeController : Controller
{
    private readonly ITenantService _tenantService;

    public HomeController(ITenantService tenantService)
    {
        _tenantService = tenantService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }
}
