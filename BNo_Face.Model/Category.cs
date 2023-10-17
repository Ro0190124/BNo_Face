using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNo_Face.Model
{
	public class Category
	{
		[Key]
		[Display(Name ="Mã Danh Mục")]
		public int CategoryID { get; set; }
		[RegularExpression(@"^[\p{L}0-9\s]+$",
			ErrorMessage = "Tên danh mục không chứa ký tự đặc biệt")]
		[Required(ErrorMessage = "Tên danh mục không được để trống.")]
		[MaxLength(30, ErrorMessage = "Tên danh mục phải nhỏ hơn 30 ký tự")]
		[MinLength(1, ErrorMessage = "Tên danh mục phải lớn hơn 1 ký tự")]
		[Display(Name = "Tên Danh Mục")]
		public string CategoryName { get; set; }
	}
}
