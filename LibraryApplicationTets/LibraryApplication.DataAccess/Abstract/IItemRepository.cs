using LibraryApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApplication.DataAccess.Abstract
{
	public interface IItemRepository
	{
		List<Item> GetAllItems();
		Item GetItemById(int id);
		Item CreateItem(Item item);
		Item UpdateItem(Item item);
		void DeleteItem(int id);

	}
}
