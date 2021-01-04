using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS434.API.MODELS.Database
{
    [Table("ROLES")]
    public class Roles
    {
        [Key]
        public int ID_ROLE { get; set; }
        public string ROLE_DESC { get; set; }
    }
}