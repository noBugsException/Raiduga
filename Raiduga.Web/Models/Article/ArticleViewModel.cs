﻿namespace Raiduga.Web.Models.Article
{
	using Raiduga.Interface;
	using Raiduga.Interface.Attribute;
	using Raiduga.Models.Interfaces;
	using Raiduga.Web.Localization;
	using Raiduga.Web.Models.Interfaces;
	using System.ComponentModel.DataAnnotations;
	using System.Web.Mvc;

	public class ArticleViewModel : AbstractFileViewModel, IDateExtented, IBodyHtml, IViewModel
	{
		[MapToEntityValue]
		public int Id { get; set; }

		[StringLength(100)]
		[Display(ResourceType = typeof(Translations), Name = "Article_Title")]
		[MapToEntityValue]
		public string Title { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Article_Author")]
		[MapToEntityValue]
		public string Author { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Article_Keywords")]
		[MapToEntityValue]
		public string Keywords { get; set; }

		[StringLength(500)]
		[Display(ResourceType = typeof(Translations), Name = "Article_Description")]
		[MapToEntityValue]
		public string Description { get; set; }

		[AllowHtml]
		[UIHint("tinymce_full_compressed")]
		[Display(ResourceType = typeof(Translations), Name = "Article_BodyHtml")]
		[MapToEntityValue]
		public string BodyHtml { get; set; }

		[Display(ResourceType = typeof(Translations), Name = "Article_IsPublished")]
		[MapToEntityValue]
		public bool IsPublished { get; set; }

		[MapToEntityValue]
		public System.DateTime? CreationDate { get; set; }

		[MapToEntityValue]
		public System.DateTime? UpdationDate { get; set; }
	}
}