using LibraryApplication.Business.Abstract;
using LibraryApplication.DataAccess.Abstract;
using LibraryApplication.DataAccess.Concrete;
using LibraryApplication.Models;
using System;
using System.Collections.Generic;

namespace LibraryApplication.Business.Concrete
{
	public class ItemService : IItemService
	{
		private IItemRepository _itemRepository;

		public ItemService(IItemRepository itemRepository)
		{
			_itemRepository = itemRepository;
		}
		public Item CreateItem(Item item)
		{
			return _itemRepository.CreateItem(item);
		}

		public void DeleteItem(int id)
		{
			_itemRepository.DeleteItem(id);
		}

		public List<Item> GetAllItems()
		{

			return _itemRepository.GetAllItems();
		}

		public Item GetItemById(int id)
		{
			if (id > 0)
			{
				return _itemRepository.GetItemById(id);
			}
			throw new Exception("Id must be bigger than 0");
		}

		public Item UpdateItem(Item item)
		{
			return _itemRepository.UpdateItem(item);
		}
	}
}
