using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CS434.API.MODELS.Database
{
	public class Items
	{
		[Key]
		public int Id { get; set; }
<<<<<<< HEAD:CS434.API/MODELS/Database/Items.cs

		
		public string Name { get; set; }

=======
		public string Name { get; set; }
>>>>>>> main:CS434.API/MODELS/Database/Item.cs
		public string Type { get; set; }
		public int Year { get; set; }
<<<<<<< HEAD:CS434.API/MODELS/Database/Items.cs
		
		
=======
>>>>>>> main:CS434.API/MODELS/Database/Item.cs
		public string Author { get; set; }
		public int Amount { get; set; }

	}
}
