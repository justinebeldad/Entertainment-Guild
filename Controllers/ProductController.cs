using Entertainment_Guild.Models;
using Microsoft.AspNetCore.Mvc;

namespace Entertainment_Guild.Controllers
{
    public class ProductController : Controller
    {
        private StoreDBContext context { get; set; }
        public ProductController(StoreDBContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Genres = context.Product.OrderBy(g => g.Name).ToList();
            return View("Edit", new Product());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Product = context.Product.OrderBy(g => g.Name).ToList();
            var product = context.Product.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if(ModelState.IsValid)
            {
                if (product.ID == 0)
                    context.Product.Add(product);
                else
                    context.Product.Update(product);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (product.ID == 0) ? "Add" : "Edit";
                ViewBag.Product = context.Product.OrderBy(g => g.Name).ToList();
                return View(product);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = context.Product.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            context.Product.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


    }
}
