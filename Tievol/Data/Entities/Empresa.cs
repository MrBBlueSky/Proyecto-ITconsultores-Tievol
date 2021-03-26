using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tievol.Data.Entities
{
    public class Empresa
    {
        [Key]
        public int ID_Empresa { get; set; }


        [MaxLength(75)]
        [Required]
        public string N_Empresa { get; set; }

        [MaxLength(15)]
        [Required]
        public string Rut { get; set; }


        [MaxLength(75)]
        [Required]
        public string Razon_Social { get; set; }


        [MaxLength(90)]
        [Required]
        public string Giro { get; set; }

        [MaxLength(90)]
        [Required]
        public string Direccion { get; set; }

        [MaxLength(20)]
        [Required]
        public string Telefono1 { get; set; }

        [MaxLength(20)]
        [Required]
        public string Telefono2 { get; set; }


        [MaxLength(20)]
        [Required]
        public string Movil { get; set; }


        [MaxLength(75)]
        [Required]
        public string Direccion_Correo { get; set; }


        [MaxLength(95)]
        [Required]
        public string Web { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_Antiguedad { get; set; }


        [MaxLength(95)]
        [Required]
        public string Observaciones { get; set; }
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

        [ForeignKey("ID_Tipo_Empresa")]
        public virtual Tipo_empresa Tipo_Empresa { get; set; }
        public virtual ICollection<Sucursal> Sucursal { get; set; }




    }
}
