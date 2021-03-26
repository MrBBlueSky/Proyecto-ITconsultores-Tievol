using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tievol.Data.Entities
{
    public class Subfamilia
    {
        [Key]
        [Required]
        public int ID_Subfamilia { get; set; }

        public string N_Subfamilia { get; set; }

        [ForeignKey("ID_Estado")]
        public virtual Estado Estado { get; set; }

        [ForeignKey("ID_Familia")]
        public virtual Familia Familia { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }

    }
}
