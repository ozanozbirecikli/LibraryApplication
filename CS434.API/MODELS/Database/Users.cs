using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS434.API.MODELS.Database
{
    [Table("USERS")]
    public class Users
    {
        [Key]
        public int ID_USERS { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public int? ID_ROLE { get; set; }
    }
}