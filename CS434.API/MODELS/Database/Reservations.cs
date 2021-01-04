using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CS434.API.MODELS.Database
{
    [Table("RESERVATIONS")]
    public class Reservations
    {
        [Key]
        public int REZ_ID { get; set; }
        public int USER_ID { get; set; }
        public int ITEM_ID { get; set; }
        public bool? IS_RETURNED { get; set; }
        public DateTime? REZ_DATE { get; set; }
        public DateTime? RETURN_DATE { get; set; }

    }
}
