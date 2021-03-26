using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tievol.Data.Entities
{
    public class Region
    {
        [Key]
        public int ID_Region { get; set; }

        [MaxLength(75)]
        [Required]
        public string N_Region { get; set; }

        public virtual ICollection<Comuna> Comuna { get; set; }

        public virtual ICollection<Ciudad> Ciudad { get; set; }

       public virtual ICollection<Sucursal> Sucursal { get; set; }
    }
}
