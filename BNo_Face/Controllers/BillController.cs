using BNo_Face.DataAccess.Data;
using BNo_Face.Model;
using Microsoft.AspNetCore.Mvc;

namespace BNo_Face.Controllers
{
	public class BillController : Controller
	{
		private readonly ApplicationDbContext _db;
		public BillController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index(string searchString)
		{
			var bills = from u in _db.Bills // lấy toàn bộ liên kết
							select u;
			
			if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
			{
				bills = bills.Where(c => c.BillID.ToString().Contains(searchString)); //lọc theo chuỗi tìm kiếm
			}
			return View(bills);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Bill bill)
		{

			if (ModelState.IsValid)
			{

				_db.Bills.Add(bill);
				_db.SaveChanges();
				return RedirectToAction("Index");

			}
			return View(bill);
		}
		public IActionResult Edit(int? ID)
		{
			if (ID == null || ID == 0)
			{
				return NotFound();
			}
			var s = _db.Bills.FirstOrDefault(u => u.BillID == ID);
			if (s == null)
			{
				return NotFound();
			}
			return View(s);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Bill bill)
		{
			if (ModelState.IsValid)
			{
				_db.Bills.Update(bill);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(bill);


		}
		public IActionResult Delete(int? ID)
		{

			if (ID == null || ID == 0)
			{
				return NotFound();
			}
			var s = _db.Bills.FirstOrDefault(u => u.BillID == ID);
			if (s == null)
			{
				return NotFound();
			}
			return View(s);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(Bill bill)
		{
			
			if (ModelState.IsValid)
			{
				_db.Bills.Remove(bill);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(bill);


		}
	}
}
