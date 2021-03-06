﻿namespace Raiduga.Models
{
	using Raiduga.Interface;
	using Raiduga.Models.Interfaces;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Address : IKey<int>, IEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Name { get; set; }

		public double Latitude { get; set; }

		public double Longitude { get; set; }
	}
}
