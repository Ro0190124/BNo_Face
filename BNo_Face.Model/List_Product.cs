using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNo_Face.Model
{
	public class List_Product
	{
		[Display(Name = "Mã Sản Phẩm")]
		public int ProductID { get; set; }
		[ForeignKey("ProductID")]
		
		public Product Product { get; set; }
		[Display(Name = "Mã Hóa Đơn")]
		public int BillID { get; set; }
		[ForeignKey("BillID")]
		public Bill Bill { get; set; }
		[Required]
		[Display(Name = "Số Lượng")]
		public int Quantity { get; set; }
	}
}
