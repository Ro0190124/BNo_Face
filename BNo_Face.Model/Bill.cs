using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNo_Face.Model
{
	public class Bill
	{
		[Key]
		public int BillID { get; set; }
		
		public int UserID { get; set; }
		[ForeignKey("UserID")]
		public User User { get; set; }
		[Required]
		public int TotalPrice { get; set; }
		public DateTime DateOfBill { get; private set; } = DateTime.Now;
	}
}
