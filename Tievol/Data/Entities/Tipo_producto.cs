using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tievol.Data.Entities
{
    public class Tipo_producto
    {
        [Key]
        [Required]
        public int ID_Tipo_Producto { get; set; }
        [Required]
        public string N_Tipo_Producto { get; set; }

        [ForeignKey("ID_Estado")]
        public virtual Estado Estado { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
