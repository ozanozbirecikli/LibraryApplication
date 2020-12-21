using LibraryApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS434.API.Interfaces
{
	public interface IItemService
	{
		List<Items> GetAllItems();
		Items GetItemById(int id);
		Items CreateItem(Items item);
		Items UpdateItem(Items item);
		void DeleteItem(int id);

	}
}
