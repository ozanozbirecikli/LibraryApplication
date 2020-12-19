using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementAPI.Models;
using UserManagementAPI.DummyData;

namespace UserManagementAPI.Controllers
{
	[Route("api/[controller]")]
	public class UsersContoller : ControllerBase
	{

		private List<User> _users = DummyData.DummyData.GetUsers(15);

		[HttpGet]
		public List<User> Get()
		{
			return _users;
		}

		[HttpGet("{id}")]
		public User Get(int id)
		{

			var user = _users.FirstOrDefault(x => x.Id == id);
			return user;
		}

		[HttpPost]
		public User Post([FromBody] User user)
		{
			_users.Add(user);
			return user;
		}

		[HttpPut]
		public User Put([FromBody] User user)
		{
			var editUser = _users.FirstOrDefault(x => x.Id == user.Id);
			editUser.Firstname = user.Firstname;
			editUser.Lastname = user.Lastname;
			editUser.Address = user.Address;
			return user;
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			var deletedUser = _users.FirstOrDefault(x => x.Id == id);
			_users.Remove(deletedUser);
		}
	}
}
