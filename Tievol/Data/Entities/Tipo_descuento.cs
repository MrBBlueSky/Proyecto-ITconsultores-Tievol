using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tievol.Data.Entities
{
    public class TipoDescuento
    {
        [Key]
        public int ID_Tipo_Descuento { get; set; }

        [MaxLength(150)]
        [Required]
        public string N_Tipo_Descuento { get; set; }

        // Relaciones - ForeignKey

        [ForeignKey("ID_Estado")]
        public virtual Estado Estado { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
