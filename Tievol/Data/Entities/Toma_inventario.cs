using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tievol.Data.Entities
{
    public class Toma_inventario
    {
        [Key]
        public int ID_TomaInventario { get; set; }
        public string N_funcionario { get; set; }
        public DateTime Fecha_Creacion { get; set; } = DateTime.Now;

        public int StockIngresado { get; set; }
        public int StockActual { get; set; }
        public int StockSolicitado { get; set; }

        [ForeignKey("ID_Producto")]
        public virtual Producto Producto { get; set; }

        [ForeignKey("ID_Estado")]
        [Required]
        public virtual Estado Estado { get; set; }



    }
}
