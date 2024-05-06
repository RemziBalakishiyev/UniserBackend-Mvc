using BusinessLogic.Abstract;
using BusinessLogic.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace UniserCommerce.UI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AdminController : Controller
    {

        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public AdminController(ICategoryService categoryService,
                               IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var categoryList = await _categoryService.GetCategoriesAsync();
            return View(categoryList);
        }


        [HttpGet]
        public async Task<JsonResult> GetCategories()
        {
            var categoryList = await _categoryService.GetCategoriesAsync();
            return Json(categoryList);
        }
        [HttpPost]
        public async Task<JsonResult> AddCategory([FromBody] CategoryListDto categoryList)
        {

            _categoryService.AddCategoryAsync(categoryList);
            return Json(new { message = "Category added" });
        }


        public async Task<IActionResult> Product()
        {
            return View();

        }

        [HttpGet]
        public async Task<JsonResult> GetProducts()
        {
            var products = await _productService.GetProductListAsync();

            return Json(products);
        }

        [HttpPost]
        public async Task<JsonResult> AddProduct([FromBody] ProductAddDto product)
        {

            if (!ModelState.IsValid)
            {
                return Json(new { message = "Product wasn't added", status = false });
            }
            await _productService.AddAsync(product);
            return Json(new { message = "Category added", status = true });
        }
    }
}
