using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tievol.Data.Entities
{
    public class Familia
    {

        [Key]
        public int ID_Familia { get; set; }

        [Required]
        public string N_Familia { get; set;}

        [ForeignKey("ID_Estado")]
        public virtual Estado Estado { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
