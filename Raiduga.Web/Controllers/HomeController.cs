﻿namespace Raiduga.Web.Controllers
{
	using Raiduga.Web.Models.Common;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.Mvc;

	public class HomeController : BaseController
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			var model = new List<AffiliateViewModel>();

			foreach (var affiliate in DbContext.Affiliates.OrderByDescending(a => a.IsPrimary).ToArray())
			{
				model.Add(new AffiliateViewModel().FromDbModel(affiliate));
			}

			return View(model);
		}
	}
}