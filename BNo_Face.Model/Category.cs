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
		[Display(Name ="ID")]
		public int CategoryID { get; set; }
		[Required]
		[MaxLength(30)]
		[MinLength(1)]
		[Display(Name = "Tên Danh Mục")]
		public string CategoryName { get; set; }
	}
}
