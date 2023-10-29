using Entertainment_Guild.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Entertainment_Guild.Controllers
{
    public class HomeController : Controller
    {
        //public HomeController(ILogger<HomeController> logger);
        public HomeController(StoreDBContext ctx)
        {
            this.ctx = ctx;
        }

        public StoreDBContext ctx;
        public IActionResult Index()
        {
            List<Product> products = ctx.Product.ToList();
            List<Stocktake> prices = ctx.Stocktake.ToList();

            foreach (Product product in products)
            {
                foreach (Stocktake price in prices)
                {
                    if (price.ProductId == product.ID)
                    {
                        product.Price = price.Price;
                        break;
                    }
                }
            }

            return View(products);
        }

        public IActionResult AboutUs()
        {
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