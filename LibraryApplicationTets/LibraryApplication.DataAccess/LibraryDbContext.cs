using LibraryApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApplication.DataAccess
{
	public class LibraryDbContext:DbContext
	{

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("Server=DESKTOP-IO4LGA6; Database=LibraryDb; Trusted_Connection=true");

		}

		public DbSet<Item> Items { get; set; }

	}
}
