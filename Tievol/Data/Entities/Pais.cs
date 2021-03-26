using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tievol.Data.Entities
{
    public class Pais
    {
        [Key]
        public int ID_Pais { get; set; }

        [Required]
        public string N_Pais { get; set; }
        [Required]
        public string Referencia { get; set; }

        public virtual ICollection<Sucursal> Sucursal { get; set; }
    }
}
