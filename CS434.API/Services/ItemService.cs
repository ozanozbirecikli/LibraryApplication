using CS434.API.Interfaces;
using CS434.API.MODELS.Database;
using CS434.API.MODELS.Response;
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
		public MessageModel CreateItem(Items item)
		{
			using (var itemDbContext = new DEV_Context())
			{
				MessageModel model = new MessageModel();

				itemDbContext.Items.Add(item);
				itemDbContext.SaveChanges();

				model.Result = true;
				model.Message = "Item Created Successfully";
				return model;
			}
		}

		public void DeleteItem(int id)
		{
			using (var itemDbContext = new DEV_Context())
			{
				var deletedItem = GetItemById(id);
				itemDbContext.Items.Remove(itemDbContext.Items.Find(id));
				itemDbContext.SaveChanges();
			}
		}

		public ItemsModel GetAllItems()
		{
			using (var itemDbContext = new DEV_Context())
			{
				ItemsModel model = new ItemsModel();
				List<Items> allItems = itemDbContext.Items.ToList();
			
				if(allItems.Count != 0)
				{
					model.Result = true;
					model.Message = "All Items Fetched Successfully!";
					model.objects = allItems;
				}
				else
				{
					model.Result = false;
					model.Message = "There is no Item!";
					model.objects = null;
				}

				return model;
			}
		}

		public ItemsModel GetItemById(int id)
		{
			using (var itemDbContext = new DEV_Context())
			{
				ItemsModel model = new ItemsModel();

				Items getItem = itemDbContext.Items.Find(id);

				if(getItem != null)
				{
					model.Result = true;
					model.Message = "Item Fetched Successfully!";
					model.objects = getItem;
				}
				else
				{
					model.Result = false;
					model.Message = "There is no Item with Selected Id!";
					model.objects = null;
				}

				return model;
			}
		}

		public MessageModel UpdateItem(Items item)
		{
			using (var itemDbContext = new DEV_Context())
			{

				MessageModel model = new MessageModel();
				if (itemDbContext.Items.Find(item.Id) != null)
				{

					itemDbContext.Items.Update(item);
					itemDbContext.SaveChanges();
					model.Result = true;
					model.Message = "Item Updated Successfully";
				}
				else
				{
					model.Result = false;
					model.Message = "Item Doesn't Exist";
				}
				return model;
			}
		}
	}
}