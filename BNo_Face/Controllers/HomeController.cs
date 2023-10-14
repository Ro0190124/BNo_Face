using BNo_Face.DataAccess.Data;
using BNo_Face.Model;
using Microsoft.AspNetCore.Mvc;

namespace BNo_Face.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext _db;
		public HomeController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Loggin(string userName, string password)
		{
			var user = _db.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
			if (user != null)
			{
				return RedirectToAction("Home", "Home");
			}
			return View();
		}
		public IActionResult Home()
		{
			return View();
		}
		public IActionResult SignIn()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult SignIn(User user)
		{
			if (user.UserName == user.Password)
			{
				ModelState.AddModelError("UserName", "Tên và mật khẩu không được trùng");
			}
			if (ModelState.IsValid)
			{
				Console.WriteLine("Create user");
				_db.Users.Add(user);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(user);
		}
	}
}
