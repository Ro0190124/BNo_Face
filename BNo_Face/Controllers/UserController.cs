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
			IEnumerable<User> userlist = _db.Users;
			return View(userlist);
		}
		public IActionResult Create()
		{
			return View();
		}
	}
}
