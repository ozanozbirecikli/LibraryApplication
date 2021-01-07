using CS434.API.Interfaces;

using CS434.API.MODELS.Database;
using CS434.API.MODELS.Response;
using CS434.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS434.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ItemsController:ControllerBase
	{
		private IItemService _itemService;
		

		public ItemsController(IItemService itemService)
		{
			_itemService = itemService;

		}

		/// <summary>
		/// Get All Items
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ItemsModel Get()
		{
			return _itemService.GetAllItems();

		}

		/// <summary>
		/// Get Item By id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public ItemsModel Get(int id)
		{
			return _itemService.GetItemById(id);

		}

		/// <summary>
		/// Create new Item
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		[HttpPost("AddItem")]
		public MessageModel Post([FromBody] Items item)
		{
			return _itemService.CreateItem(item);
			

		}

		/// <summary>
		/// Update Item
		/// </summary>
		/// <param name="items"></param>
		/// <returns></returns>
		[HttpPut("UpdateItem")]
		public MessageModel Put([FromBody] Items item)
		{
			
			return _itemService.UpdateItem(item);
			
		}

		/// <summary>
		/// Delete item
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			if (_itemService.GetItemById(id) != null)
			{
				_itemService.DeleteItem(id);
				return Ok();
			}
			return NotFound();
		}


	}
}
