using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseTest.Models;
using DatabaseTest.Models.Context;

namespace DatabaseTest
{
	public class Program
	{

		static void Main(string[] args)
		{
			var instance = new Program();
			instance.GetInput();
		}

		public void GetInput() {

			Console.WriteLine("List of Products:\n");

			using (var context = new StoreContext())
			{
				foreach (var product in context.Products)
				{
					Console.WriteLine(product.ProductId.ToString() + ", " + product.Name + ": " + product.Description);
				}
			}

			Console.Write("\nPress any key to exit...");
			Console.ReadKey(true);
		}
	}
}
