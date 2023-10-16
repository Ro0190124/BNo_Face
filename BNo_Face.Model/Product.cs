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
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        [Display(Name = "Tên Sản Phẩm")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Trạng Thái")]
        public bool Status { get; set; }
        [Required]
        [Display(Name = "Số Lượng")]
        public int Quantity { get; set; }
        [Required]
        [MaxLength(5)]
        [Display(Name = "Size")]
        public string Size { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(Name = "Màu Sắc")]
        public string Color { get; set; }
        [Display(Name = "Giá")]
        [Required]
		public int Price { get; set; }
        [Display(Name = "Ghi Chú")]		
        [MaxLength(80)]
		public string Note { get; set; }
        [Required]
		
		public int CategoryID { get; set; }
        [ValidateNever]
		[ForeignKey("CategoryID")]
		public Category Category { get; set; }
        public DateTime DateOfProduct { get; private set; } = DateTime.Now;
	}

}

