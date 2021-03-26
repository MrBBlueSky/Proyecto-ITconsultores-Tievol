using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tievol.Data.Entities
{
    public class Tipo_pago
    {
        [Key]
        [Required]
        public int ID_Tipo_Pago { get; set; }

        public string N_Tipo_Pago { get; set; }

        [ForeignKey("ID_Estado")]
        public virtual Estado Estado { get; set; }
    }
}
