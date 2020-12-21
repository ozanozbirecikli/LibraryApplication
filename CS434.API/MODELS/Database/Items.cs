﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LibraryApplication.Models
{
	public class Items
	{
		[Key]
		public int Id { get; set; }

		
		public string Name { get; set; }

		public string Type { get; set; }

		public int Year { get; set; }
		
		
		public string Author { get; set; }
		public int Amount { get; set; }

	}
}