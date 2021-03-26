using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tievol.Data.Entities
{
    public class Tipo_documento
    {
        [Key]
        [Required]
        public int ID_Tipo_Documento { get; set; }

        public string N_Tipo_Documento { get; set; }

        [ForeignKey("ID_Estado")]
        public virtual Estado Estado { get; set; }

    }
}
