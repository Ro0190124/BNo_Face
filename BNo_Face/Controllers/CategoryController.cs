using BNo_Face.DataAccess.Data;
using BNo_Face.Model;
using Microsoft.AspNetCore.Mvc;

namespace BNo_Face.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _db;
		public CategoryController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			IEnumerable<Category> userlist = _db.Categories.ToList();
			return View(userlist);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Category category)
		{
		
			if (ModelState.IsValid)
			{
				Console.WriteLine("Create user");
				_db.Categories.Add(category);
				_db.SaveChanges();
				return RedirectToAction("Index");

			}
			else
			{
				Console.WriteLine("Create user fail");
			}

			return View(category);
		}
		public IActionResult Edit(int? ID)
		{
			if (ID == null || ID == 0)
			{
				return NotFound();
			}
			var s = _db.Categories.FirstOrDefault(u => u.CategoryID == ID);
			if (s == null)
			{
				return NotFound();
			}
			return View(s);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Category category)
		{
			//Console.WriteLine("t vo r ma dm");
			//lấy chuỗi số sau dấu / trong url
			String? idString = HttpContext.Request.Path.Value?.Split("/").Last();
			Console.WriteLine("sao??"+idString);
			if (!int.TryParse(idString, out int ID))
			{
				return View();
			}
			/*if (ID != category.CategoryID)
			{
				return NotFound();
			}*/
			//Console.WriteLine("Lưu đc ch");
			if (ModelState.IsValid)
			{
				var categoryFromDb = _db.Categories.Find(ID);
				categoryFromDb.CategoryName = category.CategoryName;
				_db.Categories.Update(categoryFromDb);
				_db.SaveChanges();
				//TempData["Message"] = "Category updated successfully";
				//Console.WriteLine("Lưu đc r");
				return RedirectToAction("Index");
			}
			
			return View(category);
		}
		public IActionResult Delete(int? ID)
		{

			if (ID == null || ID == 0)
			{
				return NotFound();
			}
			var s = _db.Categories.FirstOrDefault(u => u.CategoryID == ID);
			if (s == null)
			{
				return NotFound();
			}
			return View(s);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(Category category)
		{

			//lấy chuỗi số sau dấu / trong url
			String? idString = HttpContext.Request.Path.Value?.Split("/").Last();
			if (!int.TryParse(idString, out int ID))
			{
				return View();
			}

			if (ModelState.IsValid)
			{
				//Console.WriteLine("HI");
				var categoryFromDb = _db.Categories.Find(ID);

				_db.Categories.Remove(categoryFromDb);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("Index");
		}

	}
}
