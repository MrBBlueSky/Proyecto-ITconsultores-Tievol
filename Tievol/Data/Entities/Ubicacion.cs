using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tievol.Data.Entities
{
    public class Ubicacion
    {

        [Key]
        [Required]
        public int ID_Ubicacion { get; set; }
        [Required]
        public string N_Ubicacion { get; set; }

        [ForeignKey("ID_Bodega")]
        public virtual Bodega Bodega { get; set; }
        [ForeignKey("ID_Estado")]
        public virtual Estado Estado { get; set; }
    }
}
