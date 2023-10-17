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
		[MaxLength(50, ErrorMessage = "Họ tên phải bé hơn 50 ký tự")]
		[MinLength (1, ErrorMessage = "Họ tên phải lớn hơn 1 ký tự")]
		[Display(Name = "Họ Tên")]
		[RegularExpression(@"^[\p{L}\s]+$",
			ErrorMessage = "Họ tên chỉ được chứa" +
			" các ký tự chữ và khoảng trắng.")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Vui lòng chọn ngày sinh.")]
		[Display(Name = "Ngày Sinh")]
		public DateTime Birthday { get; set; }
		[Display(Name = "Giới Tính")]
		public bool Sex { get; set; }
		[Required(ErrorMessage = "Số điện thoại không được để trống.")]
		[StringLength(10, ErrorMessage = "số điện thoại có 10 số")]
		[Display(Name = "SĐT")]
		[RegularExpression(@"^\d{10}$", ErrorMessage =
			"Số điện thoại phải gồm 10 số.")]
		public string NumberPhone { get; set; }
		[MinLength(5, ErrorMessage ="Tên tài khoản phải lớn hơn 5 ký tự") ] 
		[MaxLength(40, ErrorMessage = "Tên tài khoản phải nhỏ hơn 40 ký tự")]
		[Display(Name = "Tên Tài Khoản")]
		[Required(ErrorMessage = "Tên tài khoản không được để trống.")]
		public string UserName { get; set; }
		[Required(ErrorMessage = "Mật khẩu không được để trống.")]
		[MinLength(5, ErrorMessage = "Mật khẩu phải lớn hơn 5 ký tự")]
		[MaxLength(30, ErrorMessage = "Mật khẩu phải nhỏ hơn 30 ký tự")]
		[Display(Name = "Mật Khẩu")]
		public string Password { get; set; }
		[Required]
		[Display(Name = "Chức Vụ")]
		public byte Position { get; set; }

		// ngày lập tài khoản
		public DateTime DateOfAccount { get; private set; } = DateTime.Now;
	}

}
