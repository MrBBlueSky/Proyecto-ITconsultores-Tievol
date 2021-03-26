using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tievol.Data.Entities
{
    public class Bodega
    {
        [Key]
        public int ID_Bodega { get; set; }

        [MaxLength(75)]
        [Required]
        public string N_Bodega { get; set; }

       
        [ForeignKey("ID_Sucursal")]
        public virtual Sucursal Sucursal { get; set; }

       
        [ForeignKey("ID_Estado")]
        public virtual Estado Estado { get; set; }

        public virtual ICollection<Ubicacion> Ubicacion { get; set; }



    }
}
