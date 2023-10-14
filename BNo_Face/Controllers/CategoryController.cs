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
		public IActionResult Index(string searchString)
		{
			var categorys = from u in _db.Categories // lấy toàn bộ liên kết
						select u;

			if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
			{
				categorys = categorys.Where(c=> c.CategoryName.Contains(searchString) ); //lọc theo chuỗi tìm kiếm
			}
			return View(categorys);
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
				
				_db.Categories.Add(category);
				_db.SaveChanges();
				return RedirectToAction("Index");

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
			if (ModelState.IsValid)
			{
				_db.Categories.Update(category);
				_db.SaveChanges();
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
			
			if (ModelState.IsValid)
			{
				_db.Categories.Remove(category);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			
			return View(category);

			
		}

	}
}
