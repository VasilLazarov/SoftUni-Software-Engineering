using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVCWebApp.Models;
using System.Text;
using System.Text.Json;

namespace MVCWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> logger;

        private IEnumerable<ProductViewModel> products = new List<ProductViewModel>()
        {
            new ProductViewModel()
            {
                Id = 1,
                Name = "Cheese",
                Price = 7.00
            },
            new ProductViewModel()
            {
                Id = 2,
                Name = "Ham",
                Price = 5.50
            },
            new ProductViewModel()
            {
                Id = 3,
                Name = "Bread",
                Price = 1.50
            },
        };

        public ProductController(ILogger<ProductController> _logger)
        {
            logger = _logger;
        }

        public IActionResult Index()
        {
            return View(products);
        }

        [HttpGet]
        public IActionResult ById(int id)
        {
            var product = products
                .FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                TempData["Error"] = "Invalid id!";
                return RedirectToAction(nameof(Index));
                //return BadRequest();
            }

            return View(product);
        }


        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            return Json(products, options);
        }


        public IActionResult AllAsText()
        {
            return Content(getAllProductsAsString());
        }

        public IActionResult AllAsTextFile()
        {
            Response.Headers.Add(HeaderNames.ContentDisposition,
                @"attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(getAllProductsAsString()), "text/plain");
        }

        public IActionResult Filtered(string? keyword)// If dont work we need to se default value for keyword with "= null"
        {
            if(keyword == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var model = products
                .Where(p => p.Name.ToLower().Contains(keyword.ToLower()))
                .ToList();

            return View(nameof(Index), model);
        }


        private string getAllProductsAsString()
        {
            StringBuilder resultText = new();
            foreach (var product in products)
            {
                resultText.AppendLine($"Product {product.Id}: {product.Name} - {product.Price:f2} lv.");
            }

            return resultText.ToString().Trim();
        }
    }
}
