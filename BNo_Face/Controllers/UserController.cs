using BNo_Face.DataAccess.Data;
using BNo_Face.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BNo_Face.Controllers
{
	
	public class UserController : Controller
	{
		private readonly ApplicationDbContext _db;
		public UserController(ApplicationDbContext db)
		{
			_db = db;
		}
		//tìm kiếm
		public IActionResult Index(string searchString)
		{
			// get cookies
			var cookie = Request.Cookies["userID"];
			// check cookie
			if (cookie == null)
			{
				return RedirectToAction("Index", "Home");
			}
			/*IEnumerable<User> userlist = _db.Users.ToList();
			return View(userlist);*/
			var users = from u in _db.Users // lấy toàn bộ liên kết
						select u;

			if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
			{
				users = users.Where(s => s.UserName.Contains(searchString) || s.NumberPhone.Contains(searchString)); //lọc theo chuỗi tìm kiếm
			}
			return View(users);
		}
		//tạo
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(User user)
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
		//sửa
		public IActionResult Edit(int? ID)
		{

			if (ID == null || ID == 0)
			{
				return NotFound();
			}
			var s = _db.Users.FirstOrDefault(u => u.UserID == ID);
			if (s == null)
			{
				return NotFound();
			}
			return View(s);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(User user)
		{
			if (ModelState.IsValid)
			{
				Console.WriteLine("Edit user");
				_db.Users.Update(user);
				_db.SaveChanges();
				return RedirectToAction("Index");

			}
			return View(user);
			
		}
		//xóa
		public IActionResult Delete(int? ID)
		{

			if (ID == null || ID == 0)
			{
				return NotFound();
			}
			var s = _db.Users.FirstOrDefault(u => u.UserID == ID);
			if (s == null)
			{
				return NotFound();
			}
			return View(s);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(User user)
		{
			if (ModelState.IsValid)
			{
				Console.WriteLine("Delete user");
				_db.Users.Remove(user);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(user);
		
		}
		

	}
}
