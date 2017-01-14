﻿namespace Raiduga.Web.Areas.Admin.Controllers
{
	using Raiduga.Web.Areas.Admin.Controllers.Base;
	using Raiduga.Web.Models.Common;
	using Raiduga.Web.Models.UserFeedback;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using System.Web.Mvc;

	public class HtmlContentController : BaseAdminController
	{
		// GET: Admin/HtmlContent
		public ActionResult Index()
		{
			var dbData = DbContext.HtmlContents.ToArray();

			var model = new List<HtmlContentViewModel>();

			foreach (var dbItem in dbData)
			{
				model.Add(new HtmlContentViewModel().FromDbModel(dbItem));
			}

			return View(model);
		}

		// GET: Admin/HtmlContent/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Admin/HtmlContent/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Admin/HtmlContent/Create
		[HttpPost]
		public ActionResult Create(HtmlContentViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var item = model.ToDbModel();
					item.CreationDate = DateTime.Now;

					DbContext.HtmlContents.Add(item);
					DbContext.SaveChanges();

					return RedirectToAction("Index");
				}
			}
			catch (Exception e)
			{
				ModelState.AddModelError("", e.Message);
			}

			return View(model);
		}

		// GET: Admin/HtmlContent/Edit/5
		public ActionResult Edit(int id)
		{
			var originalItem = DbContext.HtmlContents.Find(id);

			return View(new HtmlContentViewModel().FromDbModel(originalItem));
		}

		// POST: Admin/HtmlContent/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, HtmlContentViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var item = model.ToDbModel();

					var originalItem = DbContext.HtmlContents.Find(id);

					originalItem.UpdationDate = DateTime.Now;
					originalItem.Name = item.Name;
					originalItem.BodyHtml = item.BodyHtml;

					DbContext.SaveChanges();

					return RedirectToAction("Index");
				}
			}
			catch (Exception e)
			{
				ModelState.AddModelError("", e.Message);
			}

			return View(model);
		}

		// GET: Admin/HtmlContent/Delete/5
		public ActionResult Delete(int id)
		{
			var originalItem = DbContext.HtmlContents.Find(id);

			return View(new HtmlContentViewModel().FromDbModel(originalItem));
		}

		// POST: Admin/HtmlContent/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, HtmlContentViewModel item)
		{
			try
			{
				var removableItem = DbContext.HtmlContents.Find(id);
				DbContext.HtmlContents.Remove(removableItem);
				DbContext.SaveChanges();

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
