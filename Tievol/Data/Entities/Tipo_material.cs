using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tievol.Data.Entities
{
    public class Tipo_material
    {
        [Key]
        [Required]
        public int ID_Tipo_Material { get; set; }

        public string N_Tipo_Material { get; set; }

        [ForeignKey("ID_Estado")]
        public virtual Estado Estado { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
