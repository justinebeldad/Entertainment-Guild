using Entertainment_Guild.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entertainment_Guild.Controllers
{
    public class ProductController : Controller
    {
        private StoreDBContext context { get; set; }
        public ProductController(StoreDBContext ctx)
        {
            context = ctx;
        }

        public async Task<ActionResult> Index(string searchQuery)
        {
            if (context.Product == null)
            {
                return Problem("Entity set is null.");
            }

            var product = from p in context.Product
                          select p;

            if (!String.IsNullOrEmpty(searchQuery))
            {
                product = product.Where(p => p.Name.Contains(searchQuery));
            }

            return View("~/Views/Home/Index.cshtml", await product.ToListAsync());
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

        public IActionResult Details(int id)
        {
            Product product = context.Product.FirstOrDefault(p => p.ID == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
