using LibraryApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApplication.Business.Abstract
{
	public interface IItemService
	{
		List<Item> GetAllItems();
		Item GetItemById(int id);
		Item CreateItem(Item item);
		Item UpdateItem(Item item);
		void DeleteItem(int id);

	}
}
