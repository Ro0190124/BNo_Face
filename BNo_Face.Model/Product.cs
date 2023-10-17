using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BNo_Face.Model
{
    public class Product
    {

        [Key]
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }

		[RegularExpression(@"^[\p{L}0-9\s]+$",
			ErrorMessage = "Tên sản phẩm không chứa ký tự đặc biệt")]
		[Required(ErrorMessage = "Tên sản phẩm không được để trống.")]
		[MaxLength(100, ErrorMessage = "Tên sản phẩm phải nhỏ hơn 100 ký tự")]
		[MinLength(1, ErrorMessage = "Tên sản phẩm phải lớn hơn 1 ký tự")]
		[Display(Name = "Tên Sản Phẩm")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Trạng Thái")]
        public bool Status { get; set; }

		[Display(Name = "Số Lượng")]
		[Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0.")]
		//[Required(ErrorMessage = "Size không được để trống.")]
		public int Quantity { get; set; }

        //[Required(ErrorMessage = "Size không được để trống.")]
		[MaxLength(5, ErrorMessage = "Size phải nhỏ hơn 5 ký tự")]
		[Display(Name = "Size")]
        public string Size { get; set; }

        [Required(ErrorMessage = "Màu sắc không được để trống.")]
		[MaxLength(20, ErrorMessage = "Màu sắc phải nhỏ hơn 20 ký tự")]
		[Display(Name = "Màu Sắc")]
        public string Color { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "Giá phải lớn hơn 0.")]
		[Display(Name = "Giá")]
		[Required(ErrorMessage = "Giá không được để trống.")]
		public int Price { get; set; }

        [Display(Name = "Ghi Chú")]
        [MaxLength(80)]
		[Required(AllowEmptyStrings = true)]
		public string Note { get; set; } 

        [Required]
		
		public int CategoryID { get; set; }
        [ValidateNever]
		[ForeignKey("CategoryID")]
		public Category Category { get; set; }
        public DateTime DateOfProduct { get; private set; } = DateTime.Now;
	}

}

