using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tievol.Data.Entities
{
    [Table("Clientes_Proveedores")]
    public class ClienteProveedor
    {
        [Key]
        public int ID_Cliente_Proveedor { get; set; }

        [MaxLength(250)]
        [Required]
        public string N_Cliente_Proveedor { get; set; }

        [Required]
        public int ID_Tipo_Cliente_Proveedor { get; set; }


        [MaxLength(15)]
        [Required]
        public string Rut { get; set; }

        [MaxLength(250)]
        [Required]
        public string Razon_Social { get; set; }

        [MaxLength(250)]
        [Required]
        public string Giro { get; set; }

        [MaxLength(250)]
        [Required]
        public string Direccion { get; set; }

        [Required]
        public int ID_Ciudad { get; set; }

        [Required]
        public int ID_Comuna { get; set; }

        [Required]
        public int ID_Region { get; set; }

        [Required]
        public int ID_Pais { get; set; }

        [MaxLength(25)]
        public string Telefono { get; set; }

        [MaxLength(25)]
        public string Movil { get; set; }

        [MaxLength(150)]
        public string Direccion_Correo { get; set; }

        //
        public DateTime Fecha_Ingreso { get; set; }
        //
        public int ID_Condicion_Venta { get; set; }
        public double Monto_Credito { get; set; }
        public string Observaciones { get; set; }

        // Relaciones - ForeignKey

        [ForeignKey("ID_Estado")]
        public virtual Estado Estado { get; set; }


        // Ultima actualizacion
        public string ID_Usuario { get; set; }
        public DateTime Ult_Actualizacion { get; set; } = DateTime.Now;

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
