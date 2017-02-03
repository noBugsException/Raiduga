﻿namespace Raiduga.Web
{
	using Autofac;
	using Autofac.Integration.Mvc;
	using System.Web.Mvc;
	using ModelTransformers;
	using Raiduga.Interface;


	public class AutofacConfig
	{
		public static void ConfigureContainer()
		{
			var builder = new ContainerBuilder();

			// Register dependencies in controllers
			builder.RegisterControllers(typeof(MvcApplication).Assembly);

			builder
				.RegisterGeneric(typeof(ModelTransformer<,>))
				.As(typeof(IModelTransformer<,>));


			// Register dependencies in filter attributes
			builder.RegisterFilterProvider();

			// Register dependencies in custom views
			builder.RegisterSource(new ViewRegistrationSource());

			// Register our Data dependencies
			//builder.RegisterModule(new DataModule("MVCWithAutofacDB"));

			var container = builder.Build();

			// Setup global sitemap loader (required)
			//MvcSiteMapProvider.SiteMaps.Loader = container.Resolve<ISiteMapLoader>();

			//XmlSiteMapController.RegisterRoutes(RouteTable.Routes);

			// Set MVC DI resolver to use our Autofac container
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}