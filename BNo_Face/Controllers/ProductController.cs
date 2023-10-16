using BNo_Face.DataAccess.Data;
using BNo_Face.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BNo_Face.Controllers
{
	public class ProductController : Controller
	{
		private readonly ApplicationDbContext _db;
		public ProductController(ApplicationDbContext db)
		{
			_db = db;
			_db.Products.Include(u => u.Category);
		}
		public void LoadCategory()
		{
			//ViewBag.CategoryID = new SelectList(_db.Categories, "CategoryID", "CategoryName");
			IEnumerable<SelectListItem> categoryList = _db.Categories.Select(
				u => new SelectListItem()
				{
					Text = u.CategoryName,
					Value = u.CategoryID.ToString()
				}
				).ToList();
			ViewBag.CategoryList = categoryList;
		}
		public IActionResult Index(string searchString)
		{
			
			// get cookies
			var cookie = Request.Cookies["userID"];
			
			// check cookie
			if (cookie == null)
			{
				return RedirectToAction("Index", "Home");
			}
			
			
			//show the list of products with Name of category

			var products = _db.Products.Include(u => u.Category).ToList();
			//searching
			if (!string.IsNullOrEmpty(searchString))
			{
				products = products.Where(u => u.ProductName.ToLower().Contains(searchString.ToLower())).ToList();
			}
			
			return View(products);
		}
		
		public IActionResult Create()
		{
			
			LoadCategory();
			return View();
		}
			
		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Product product)
		{
			

			if (ModelState.IsValid)
			{
				Console.WriteLine(product.CategoryID);
				_db.Products.Add(product);
				_db.SaveChanges();
				return RedirectToAction("Index");
				
			}
			else
			{
				LoadCategory();
				return View(product);
			}
		}

		public IActionResult Edit(int? ID)
		{
			LoadCategory();
			if (ID == null || ID == 0)
			{
				return NotFound();
			}
			var s = _db.Products.FirstOrDefault(u => u.ProductID == ID);
			if (s == null)
			{
				return NotFound();
			}
			return View(s);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Product product)
		{
			LoadCategory();
			if (ModelState.IsValid)
			{
				_db.Products.Update(product);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(product);


		}
		public IActionResult Delete(int? ID)
		{

			if (ID == null || ID == 0)
			{
				return NotFound();
			}
			//var s = _db.Products.FirstOrDefault(u => u.ProductID == ID);
			var s = _db.Products.Include(p => p.Category).FirstOrDefault(u => u.ProductID == ID);
			if (s == null)
			{
				return NotFound();
			}
			return View(s);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(Product product)
		{

			if (ModelState.IsValid)
			{
				_db.Products.Remove(product);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(product);


		}
	}
}
