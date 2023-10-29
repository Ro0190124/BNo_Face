using BNo_Face.DataAccess.Data;
using BNo_Face.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BNo_Face.Controllers
{
    public class List_ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public List_ProductController(ApplicationDbContext db)
        {
            _db = db;
        }

     
  /*      public void LoadCategory()
        {
            IEnumerable<SelectListItem> Category = _db.Categories.Select(
                u => new SelectListItem()
                {
                    Text = u.CategoryName,
                    Value = u.CategoryID.ToString()
                }).ToList();
            ViewBag.Category = Category;
        }*/
        public void LoadProduct()
        {
            IEnumerable<SelectListItem> Product = _db.Products.Select(
                u => new SelectListItem()
                {
                    Text = u.ProductName,
                    Value = u.ProductID.ToString()
                }).ToList();

            ViewBag.Product = Product;
        }

        public IActionResult Index()
        {
            LoadProduct();
            return View();
        }

        public IActionResult Create()
        {
            LoadProduct();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(List_Product list_Product)
        {
            LoadProduct();
            if (ModelState.IsValid)
            {

                _db.List_Products.Add(list_Product);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(list_Product);
        }


    }
}
