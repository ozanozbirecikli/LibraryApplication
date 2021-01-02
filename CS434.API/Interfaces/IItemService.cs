using CS434.API.MODELS.Database;
using CS434.API.MODELS.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS434.API.Interfaces
{
	public interface IItemService
	{
		ItemsModel GetAllItems();
		ItemsModel GetItemById(int id);
		MessageModel CreateItem(Items item);
		MessageModel UpdateItem(Items item);
		void DeleteItem(int id);

	}
}
