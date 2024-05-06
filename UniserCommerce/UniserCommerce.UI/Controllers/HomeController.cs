using BusinessLogic.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UniserCommerce.UI.Models;

namespace UniserCommerce.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService; //new ProductService();
        }

        public async Task<IActionResult> IndexAsync()
        {

            var products = await _productService.GetProductListAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
