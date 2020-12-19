using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.DataAccess
{
	public class HotelDbContext:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("Server=DESKTOP-IO4LGA6; Database=HotelDb; Trusted_Connection=true");
		}

		public DbSet<Hotel> Hotels { get; set; }



	}
}
