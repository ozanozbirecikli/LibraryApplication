using CS434.API.Interfaces;
using CS434.API.MODELS.Database;
<<<<<<< HEAD
using LibraryApplication.Models;
=======
>>>>>>> main
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS434.API.Services
{
	public class ItemService : IItemService
	{
		IConfiguration configuration;

		public ItemService(IConfiguration configuration)
		{
			this.configuration = configuration;
		}
		public Items CreateItem(Items item)
		{
			using (var itemDbContext = new DEV_Context())
			{
				itemDbContext.Items.Add(item);
				itemDbContext.SaveChanges();
				return item;
			}
		}

		public void DeleteItem(int id)
		{
			using (var itemDbContext = new DEV_Context())
			{
				var deletedItem = GetItemById(id);
				itemDbContext.Items.Remove(deletedItem);
				itemDbContext.SaveChanges();
			}
		}

		public List<Items> GetAllItems()
		{
			using (var itemDbContext = new DEV_Context())
			{
				return itemDbContext.Items.ToList();
			}
		}

		public Items GetItemById(int id)
		{
			using (var itemDbContext = new DEV_Context())
			{
				return itemDbContext.Items.Find(id);
			}
<<<<<<< HEAD

=======
			
>>>>>>> main
		}

		public Items UpdateItem(Items item)
		{
			using (var itemDbContext = new DEV_Context())
			{
				itemDbContext.Items.Update(item);
				itemDbContext.SaveChanges();
				return item;
			}
		}
	}
}