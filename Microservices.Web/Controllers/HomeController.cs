using Microservices.Web.Models;
using Microservices.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Microservices.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAll().GetAwaiter().GetResult();

            var model = products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price
            }).ToList();

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
