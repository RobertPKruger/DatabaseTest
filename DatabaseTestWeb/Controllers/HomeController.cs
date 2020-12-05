using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseTest.Models;
using DatabaseTest.Models.Context;

namespace DatabaseTestWeb.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var products = new List<Product>();
			using (var context = new StoreContext())
			{
				products = context.Products.ToList();
			}

			return View(products);
		}

		[HttpPost]
		public JsonResult Query(string qry)
		{
			var products = new List<Product>();
			using (var context = new StoreContext())
			{
				if (string.IsNullOrEmpty(qry) == false)
				{
					products = context.Products.Where(x => x.Name.Contains(qry)).ToList();
				}
				else
				{
					products = context.Products.ToList();
				}
			}

			return Json(products);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}