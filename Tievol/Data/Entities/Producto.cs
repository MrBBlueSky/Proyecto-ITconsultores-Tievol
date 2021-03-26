using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tievol.Data.Entities
{
    public class Producto
    {
        [Key]
        public int ID_Producto { get; set; }

        [MaxLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres") ]
        [Required(ErrorMessage = "Ingrese Nombre")]
        public string N_Producto { get; set; }
        [MaxLength(100, ErrorMessage = "La Descripcion no puede superar los 100 caracteres")]
        [Required(ErrorMessage = "Ingrese Descripción")]
        public string Descripcion { get; set; }
        [MaxLength(100, ErrorMessage = "La Observacion no puede superar los 100 caracteres")]
        [Required(ErrorMessage = "Ingrese Observación")]
        public string Observaciones { get; set; }
        [Required]
        public long Codigo_Barra { get; set; }
        [Required]
        public long Codigo_Interno { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "El Codigo Parte no puede superar los 10 caracteres")]
        public string Codigo_Parte { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "El Codigo de Proveedor no puede superar los 10 caracteres")]
        public string Codigo_Proveedor { get; set; }

        // Valores
        public double Precio_Venta { get; set; }
        public double Precio_Web { get; set; }

        public double Valor_Compra { get; set; }
        public double Valor_Flete { get; set; }
        public double Valor_Costo { get; set; }
        public double Valor_Margen { get; set; }
        [Required]
        [Range(0, 100, ErrorMessage = "El numero no puede ser negativo ni mayor a 100")]
        public double Valor_Descuento { get; set; }

        // Historico
        public DateTime Fecha_Creacion { get; set; }
        public DateTime Ult_Inventario { get; set; }
        public DateTime Ult_Reposicion { get; set; }

        //Retorna la lista completa
        public virtual ICollection<Toma_inventario> Toma_inventario { get; set; }


        // Relaciones - ForeignKey
        [ForeignKey("ID_Tipo_Descuento")]
        public virtual TipoDescuento TipoDescuento { get; set; }

        [ForeignKey("ID_Unidad")]
        [Required]
        public virtual Unidad Unidad { get; set; }

        [ForeignKey("ID_Marca")]
        public virtual Marca Marca { get; set; }

        [ForeignKey("ID_Familia")]
        [Required]
        public virtual Familia Familia { get; set; }

        [ForeignKey("ID_SubFamilia")]
        [Required]
        public virtual Subfamilia SubFamilia { get; set; }

        [ForeignKey("ID_Tipo_Producto")]
        public virtual Tipo_producto TipoProducto { get; set; }

        [ForeignKey("ID_Tipo_Inventario")]
        public virtual Tipo_inventario TipoInventario { get; set; }

        [ForeignKey("ID_Tipo_Material")]
        public virtual Tipo_material TipoMaterial { get; set; }

        [ForeignKey("ID_Cliente_Proveedor")]
        [Required]
        public virtual ClienteProveedor ClienteProveedor { get; set; }

        [ForeignKey("ID_Estado")]
        [Required]
        public virtual Estado Estado { get; set; }

        // Ultima actualizacion
        public string ID_Usuario { get; set; }
        public DateTime Ult_Actualizacion { get; set; } = DateTime.Now;
        //public object Producto { get; internal set; }
    }
}
