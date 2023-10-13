using BNo_Face.DataAccess.Data;
using BNo_Face.Model;
using Microsoft.AspNetCore.Mvc;
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
		public IActionResult Index()
		{
			IEnumerable<User> userlist = _db.Users.ToList();
			return View(userlist);
		}
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
			else
			{
				Console.WriteLine("Create user fail");
			}
			
			return View(user);
		}
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
			Console.WriteLine("t vo r ma dm");
			//lấy chuỗi số sau dấu / trong url
			String? idString = HttpContext.Request.Path.Value?.Split("/").Last();
			if (!int.TryParse(idString, out int ID))
			{
				return View();
			}
			if (user.UserName == user.Password)
			{
				ModelState.AddModelError("UserName", "Tên và mật khẩu không được trùng"); 
			}
			
			if (ModelState.IsValid)
			{
				Console.WriteLine("HI");
				var userFromDb = _db.Users.Find(ID);
				userFromDb.UserName = user.UserName;
				userFromDb.Password = user.Password;
				userFromDb.Name = user.Name;
				userFromDb.NumberPhone = user.NumberPhone;
				userFromDb.Sex = user.Sex;
				userFromDb.Position = user.Position;
				_db.Users.Update(userFromDb);
				_db.SaveChanges();
				//TempData["Message"] = "Category updated successfully";
				return RedirectToAction("Index");
			}
			return View(user);
		}
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

			//lấy chuỗi số sau dấu / trong url
			String? idString = HttpContext.Request.Path.Value?.Split("/").Last();
			if (!int.TryParse(idString, out int ID))
			{
				return View();
			}

			if (ModelState.IsValid)
			{
				Console.WriteLine("HI");
				var userFromDb = _db.Users.Find(ID);
				
				_db.Users.Remove(userFromDb);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("Index");
		}
	}
}
