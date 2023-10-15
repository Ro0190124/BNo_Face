using BNo_Face.DataAccess.Data;
using BNo_Face.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BNo_Face.Controllers
{
	public class ProductController : Controller
	{
		private readonly ApplicationDbContext _db;
		public ProductController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index(string searchString)
		{
			var products = from u in _db.Products // lấy toàn bộ liên kết
						   select u;

			if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
			{
				products = products.Where(c => c.ProductName.Contains(searchString) || c.Price.ToString().Contains(searchString)); //lọc theo chuỗi tìm kiếm
			}
			return View(products);
		}
		public IActionResult Create()
		{
			//Product product = new Product();
			IEnumerable<SelectListItem> categoryList = _db.Categories.Select(
				u => new SelectListItem()
				{

					Text = u.CategoryName,
					Value = u.CategoryID.ToString()
				}
				).ToList();
			ViewBag.CategoryList = categoryList;
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
				IEnumerable<SelectListItem> categoryList = _db.Categories.Select(
			u => new SelectListItem()
			{

				Text = u.CategoryName,
				Value = u.CategoryID.ToString()
			}
			).ToList();
				ViewBag.CategoryList = categoryList;
				return View(product);
			}
		}

		public IActionResult Edit(int? ID)
		{
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
			var s = _db.Products.FirstOrDefault(u => u.ProductID == ID);
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
