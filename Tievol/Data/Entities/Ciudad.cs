using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Tievol.Data.Entities;

namespace Tievol.Data.Entities
{
    public class Ciudad
    {
        [Key]
        public int ID_Ciudad { get; set; }


        [MaxLength(75)]
        [Required(ErrorMessage = "Ingrese un Nombre para la Ciudad")]
        public string N_Ciudad { get; set; }


        [Required]
        [ForeignKey("ID_Region")]
        public virtual Region Region { get; set; }

        public virtual ICollection<Sucursal> Sucursal { get; set; }

    }
}
