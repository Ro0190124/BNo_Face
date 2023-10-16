using BNo_Face.DataAccess.Data;
using BNo_Face.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BNo_Face.Controllers
{
	public class BillController : Controller
	{
		private readonly ApplicationDbContext _db;
		public BillController(ApplicationDbContext db)
		{
			_db = db;
		}
		public void LoadProduct()
		{
			IEnumerable<SelectListItem> productList = _db.Products.Select(
				u => new SelectListItem()
				{
					Text = u.ProductName,
					Value = u.ProductID.ToString()
				}
				).ToList();
			ViewBag.ProductList = productList;
		
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
			var bills = from u in _db.Bills 
							select u;
			
			if (!String.IsNullOrEmpty(searchString)) 
			{
				bills = bills.Where(c => c.BillID.ToString().Contains(searchString)); 
			}
			return View(bills);
		}
		public IActionResult Create()
		{
			LoadProduct();
			return View();

		}

		

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Bill bill)
		{
			LoadProduct();
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
