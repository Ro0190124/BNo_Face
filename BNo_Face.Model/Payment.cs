using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNo_Face.Model
{
	public class Payment
	{
		[Key]
		public int PaymentID { get; set; }
		public int UserID { get; set; }
		[ForeignKey("UserID")]
		public User User { get; set; }
		[MaxLength(80)]
		public string Note { get; set; }
		[Required]
		[MaxLength(100)]
		public string Content { get; set; }
		[Required]
		public int TotalPrice { get; set; }
		public DateTime DateOfPayment { get; private set; } = DateTime.Now;
	}
}
