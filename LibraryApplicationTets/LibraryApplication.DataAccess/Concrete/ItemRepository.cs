using LibraryApplication.DataAccess.Abstract;
using LibraryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryApplication.DataAccess.Concrete
{
	public class ItemRepository : IItemRepository
	{
		public Item CreateItem(Item item)
		{
			using (var itemDbContext = new LibraryDbContext())
			{
				itemDbContext.Items.Add(item);
				itemDbContext.SaveChanges();
				return item;
			}
		}

		public void DeleteItem(int id)
		{
			using (var itemDbContext = new LibraryDbContext())
			{
				var deletedItem = GetItemById(id);
				itemDbContext.Items.Remove(deletedItem);
				itemDbContext.SaveChanges();
			}
		}

		public List<Item> GetAllItems()
		{
			using (var itemDbContext = new LibraryDbContext())
			{
				return itemDbContext.Items.ToList();
			}

		}

		public Item GetItemById(int id)
		{
			using (var itemDbContext = new LibraryDbContext())
			{
				return itemDbContext.Items.Find(id);	
			}
		}

		public Item UpdateItem(Item item)
		{
			using (var itemDbContext = new LibraryDbContext())
			{
				itemDbContext.Items.Update(item);
				itemDbContext.SaveChanges();
				return item;
			}
		}
	}
}
