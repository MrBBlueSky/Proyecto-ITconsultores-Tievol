using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tievol.Data.Entities
{
    public class Tipo_empresa
    {
        [Key]
        [Required]
        public int ID_Tipo_Empresa { get; set; }

        public string N_Tipo_Empresa { get; set; }

        [ForeignKey("ID_Estado")]
        public virtual Estado Estado { get; set; }

        public virtual ICollection<Empresa> Empresa { get; set; }
    }
}
