using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tievol.Data.Entities
{
    public class Perfil
    {
        [Key]
        public int ID_Perfil { get; set; }

        [Required]
        public string N_Perfil { get; set; }
        [ForeignKey("ID_Estado")]
        public virtual Estado Estado { get; set; }
    }
}
