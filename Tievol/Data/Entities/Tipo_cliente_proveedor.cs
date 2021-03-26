using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tievol.Data.Entities
{
    public class Tipo_cliente_proveedor
    {
        [Key]
        [Required]
        public int ID_Tipo_Cliente_Proveedor { get; set; }

        [MaxLength(75)]
        [Required]
        public string N_Tipo_Cliente_Proveedor { get; set; }

        [ForeignKey("ID_Estado")]
        public virtual Estado Estado { get; set; }
    }
}

