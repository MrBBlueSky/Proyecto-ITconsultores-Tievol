
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tievol.Data.Entities
{
    public class Sucursal
    {
        [Key]
        [Required]
        public int ID_Sucursal { get; set;  }
        [MaxLength(75)]
        [Required]
        public string N_Sucursal { get; set; }
        [MaxLength(75)]
        [Required]
        public string Direccion { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Movil1 { get; set; }
        public string Movil2 { get; set; }
        public string Direccion_Correo { get; set; }


        //Claves foraneas
        [ForeignKey("ID_Empresa")]
        public virtual Empresa Empresa { get; set; }

        [ForeignKey("ID_Ciudad")]
        public virtual Ciudad Ciudad { get; set; }

        [ForeignKey("ID_Pais")]
        public virtual Pais Pais { get; set; }

        [ForeignKey("ID_Comuna")]
        public virtual Comuna Comuna { get; set; }

        [ForeignKey("ID_Region")]
        public virtual Region Region { get; set; }

        [ForeignKey("ID_Estado")]
        public virtual Estado Estado { get; set; }

        public virtual ICollection<Bodega> Bodega { get; set; }

        



    }
}
