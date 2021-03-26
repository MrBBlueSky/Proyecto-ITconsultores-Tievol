using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tievol.Data.Entities
{
    public class Comuna
    {
        [Key]
        public int ID_Comuna { get; set; }

        [MaxLength(75)]
        [Required]
        public string N_Comuna { get; set; }

   
        [ForeignKey("ID_Region")]
        public virtual Region Region { get; set; }

        public virtual ICollection<Sucursal> Sucursal { get; set; }
    }
}
