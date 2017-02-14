﻿namespace Raiduga.Web.Controllers
{
	using Autofac;
	using Raiduga.Web.Models.Common;
	using Raiduga.Web.Models.Schedule;
	using Raiduga.Web.Models.Service;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web.Mvc;

	public class ScheduleController : BaseController
	{
		public ScheduleController(IComponentContext componentContext)
			: base(componentContext)
		{
		}

		// GET: Schedule
		[Route("Розклад")]
		public ActionResult Index()
		{
			var affiliates = DbContext.Affiliates.ToArray();

			var viewModel = new ScheduleViewModelBuilder().BuildSchedule(affiliates);

			return View(viewModel);
		}
	}
}