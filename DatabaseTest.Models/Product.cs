using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseTest.Models
{
	public class Product
	{
		[Key]
		public Guid ProductId { get; set; }
		public String Name { get; set; }
		public String Description { get; set; }
		public Decimal Price { get; set; }

		public ICollection<Order> Orders { get; set; }
	}
}
