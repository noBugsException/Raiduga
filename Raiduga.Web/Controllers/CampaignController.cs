﻿namespace Raiduga.Web.Controllers
{
	using Autofac;
	using Raiduga.Web.Models.Campaign;
	using System.Data.Entity;
	using System.Linq;
	using System.Threading.Tasks;
	using System.Web.Mvc;

	public class CampaignController : BaseController
	{
		public CampaignController(IComponentContext componentContext)
			: base(componentContext)
		{
		}

		[Route("Акції/{compaignName}")]
		public async Task<ActionResult> Index(string compaignName)
		{
			try
			{
				var entity = await DbContext.Campaigns
					.Where(c => c.Name == c.Name && c.IsActive)
					.FirstOrDefaultAsync();

				var viewModel = _modelTransformer.GetViewModel<CampaignViewModel>(entity);

				return View(viewModel);
			}
			catch
			{
				return RedirectToAction("Index", "Home");
			}
		}

        public ActionResult Index() {

            return View();

        }
	}
}