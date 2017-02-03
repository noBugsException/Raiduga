﻿namespace Raiduga.Web.Areas.Admin.Controllers
{
	using Raiduga.Models;
	using Raiduga.Web.Areas.Admin.Controllers.Base;
	using System.Web.Mvc;
	using System.Linq;
	using Raiduga.Web.Models.Common;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using System;
	using Autofac;
	using Raiduga.Interface;

	public class MessagesController : BaseAdminController
	{
		private IModelTransformer<ContactRequest, ContactRequestViewModel> _crTransformer;

		public MessagesController(IComponentContext componentContext)
		{
			_crTransformer = componentContext.Resolve<IModelTransformer<ContactRequest, ContactRequestViewModel>>();
		}

		// GET: Admin/Admin
		public ActionResult Index()
		{
			var dbData = DbContext.ContactRequests.OrderByDescending(cr => cr.CreationDate);

			var model = new List<ContactRequestViewModel>();
			foreach (var dbItem in dbData)
			{
				model.Add(_crTransformer.GetViewModel(dbItem));
			}

			return View(model);
		}

		[HttpPost]
		public ActionResult MarkAsRead(FormCollection form)
		{
			var itemId = int.Parse(form["cr.Id"]);

			var dbItem = DbContext.ContactRequests.Find(itemId);
			dbItem.UpdationDate = DateTime.Now;

			DbContext.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}