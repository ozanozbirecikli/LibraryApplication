using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LibraryApplication.Models
{
	public class Item
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[StringLength(50)]
		[Required]
		public string Name { get; set; }

		[StringLength(50)]
		[Required]
		public string Type { get; set; }

		public int Year { get; set; }
		
		[StringLength(50)]
		[Required]
		public string Author { get; set; }
		public int Amount { get; set; }

	}
}
