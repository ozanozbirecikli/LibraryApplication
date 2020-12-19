using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelFinder.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HotelsController : ControllerBase
	{
		private IHotelService _hotelService;
		public HotelsController(IHotelService hotelService)
		{
			_hotelService = hotelService;
		}

		/// <summary>
		/// Get All Hotels
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Get()
		{

			var hotels = _hotelService.GetAllHotels();
			return Ok(hotels);
		}

		/// <summary>
		/// Get Hotel By id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{

			var hotel = _hotelService.GetHotelById(id);
			if(hotel != null)
			{
				return Ok(hotel);
			}
			return NotFound();
		}

		/// <summary>
		/// Create a hotel 
		/// </summary>
		/// <param name="hotel"></param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Post([FromBody] Hotel hotel)
		{
			
			var createdHotel = _hotelService.CreateHotel(hotel);
			return CreatedAtAction("Get", new {id = createdHotel.Id }, createdHotel);
			
		}

		/// <summary>
		/// Update a hotel
		/// </summary>
		/// <param name="hotel"></param>
		/// <returns></returns>
		[HttpPut]
		public IActionResult Put([FromBody] Hotel hotel)
		{
			if(_hotelService.GetHotelById(hotel.Id)!= null)
			{
				return Ok(_hotelService.UpdateHotel(hotel));
			}
			return NotFound();
			
		}

		/// <summary>
		/// Delete a Hotel
		/// </summary>
		/// <param name="id"></param>
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			if (_hotelService.GetHotelById(id) != null)
			{
				_hotelService.DeleteHotel(id);
				return Ok();
			}
			return NotFound();
		}
	}
}
