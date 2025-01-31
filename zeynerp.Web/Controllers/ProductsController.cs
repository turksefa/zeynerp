using Microsoft.AspNetCore.Mvc;
using zeynerp.Application.Interfaces;

namespace zeynerp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts(false);
            return View(products);
        }
    }
}