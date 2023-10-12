using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNo_Face.Model
{
	public class User
	{
		[Key]
		[Display(Name = "User ID")]
		public int UserID { get; set; }
		[MaxLength(50)]
		[MinLength (1)]
		[Display(Name = "Full Name")]
		public string Name { get; set; }
		public DateTime Birthday { get; set; }
		public bool Sex { get; set; }
		
		[StringLength(10)]
		[Display(Name = "Number Phone")]
		public string NumberPhone { get; set; }
		
		[Required]
		[MinLength(5)]
		[MaxLength(40)]
		[Display(Name = "User Name")]
		public string UserName { get; set; }
		[Required]
		[MinLength(5)]
		[MaxLength(30)]
		public string Password { get; set; }
		[Required]
		public byte Position { get; set; }

		// ngày lập tài khoản
		public DateTime DateOfAccount { get; private set; } = DateTime.Now;
	}
}
