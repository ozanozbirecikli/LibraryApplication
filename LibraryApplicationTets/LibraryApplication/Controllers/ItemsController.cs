using LibraryApplication.Business.Abstract;
using LibraryApplication.Business.Concrete;
using LibraryApplication.DataAccess.Abstract;
using LibraryApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ItemsController:ControllerBase
	{
		private IItemService _itemService;
		public ItemsController(IItemService ıtemService)
		{
			_itemService = ıtemService;

		}

		/// <summary>
		/// Get All Items
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Get()
		{
			var items = _itemService.GetAllItems();
			return Ok(items);

		}

		/// <summary>
		/// Get Item By id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var item = _itemService.GetItemById(id);
			if(item != null)
			{
				return Ok(item);
			}
			return NotFound();
		}

		/// <summary>
		/// Create new Item
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Post([FromBody] Item item)
		{
			var createdItem = _itemService.CreateItem(item);
			return CreatedAtAction("Get", new { id = createdItem.Id }, createdItem);

		}

		/// <summary>
		/// Update Item
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		[HttpPut]
		public IActionResult Put([FromBody] Item item)
		{
			if(_itemService.GetItemById(item.Id) != null)
			{
				return Ok(_itemService.UpdateItem(item));
			}
			return NotFound();

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
