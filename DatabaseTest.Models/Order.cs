using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseTest.Models
{
	public class Order
	{
		[Key]
		public Guid OrderId { get; set; }
		public String BuyerName { get; set; }
		public DateTime OrderTime { get; set; }
		public Decimal Subtotal { get; set; }

		public ICollection<Product> Products { get; set; }
	}

}
