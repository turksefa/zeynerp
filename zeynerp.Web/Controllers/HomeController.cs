using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zeynerp.Core.Entities;
using zeynerp.Infrastructure.Data.Contexts;

namespace zeynerp.Web.Controllers;

public class HomeController : Controller
{
    // private readonly UserManager<ApplicationUser> _userManager;

    // public HomeController(UserManager<ApplicationUser> userManager)
    // {
    //     _userManager = userManager;
    // }

    public IActionResult Index()
    {
        // var users = _userManager.Users.Include(u => u.Tenant).ToList();
        // foreach (var user in users)
        // {
        //     var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();
        //     optionsBuilder.UseSqlServer(user.Tenant.ConnectionString);

        //     using var context = new TenantDbContext(optionsBuilder.Options);
        //     await context.Database.MigrateAsync();
        // }
        return View();
    }

    public IActionResult About()
    {
        return View();
    }
}
