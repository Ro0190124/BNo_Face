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
		[Required(ErrorMessage = "Họ tên không được để trống.")]
		[MaxLength(50)]
		[MinLength (1)]
		[Display(Name = "Họ Tên")]
		[RegularExpression(@"^[\p{L}\s]+$",
			ErrorMessage = "Họ tên chỉ được chứa" +
			" các ký tự chữ và khoảng trắng.")]
		public string Name { get; set; }
		[Display(Name = "Ngày Sinh")]
		public DateTime Birthday { get; set; }
		[Display(Name = "Giới Tính")]
		public bool Sex { get; set; }
		[Required(ErrorMessage = "Số điện thoại không được để trống.")]
		[StringLength(10)]
		[Display(Name = "SĐT")]
		public string NumberPhone { get; set; }
		
		[Required]
		[MinLength(5)]
		[MaxLength(40)]
		[Display(Name = "Tên Tài Khoản")]
		public string UserName { get; set; }
		[Required]
		[MinLength(5)]
		[MaxLength(30)]
		[Display(Name = "Mật Khẩu")]
		public string Password { get; set; }
		[Required]
		[Display(Name = "Chức Vụ")]
		public byte Position { get; set; }

		// ngày lập tài khoản
		public DateTime DateOfAccount { get; private set; } = DateTime.Now;
	}

}
