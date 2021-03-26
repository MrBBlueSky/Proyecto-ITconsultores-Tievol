using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tievol.Data.Entities
{
    public class Estado
    {

        [Key]
        public int ID_Estado { get; set; }

        [MaxLength(75)]
        [Required]
        public string N_Estado { get; set; }

        public virtual ICollection<Sucursal> Sucursal { get; set; }

        public virtual ICollection<Bodega> Bodega { get; set; }

        public virtual ICollection<Familia> Familia{ get; set; }

        public virtual ICollection<Unidad> Unidad { get; set; }

        public virtual ICollection<Ubicacion> Ubicacion { get; set; }

        public virtual ICollection<Tipo_producto> Tipo_producto { get; set; }

        public virtual ICollection<Tipo_documento> Tipo_documento { get; set; }
        public virtual ICollection<TipoDescuento> Tipo_descuento { get; set; }
        public virtual ICollection<Tipo_inventario> Tipo_inventario { get; set; }
        public virtual ICollection<Tipo_pago> Tipo_pago { get; set; }

        public virtual ICollection<Toma_inventario> Toma_inventario { get; set; }

        public virtual ICollection<Tipo_cliente_proveedor> Tipo_cliente_proveedor { get; set; }
        
        public virtual ICollection<Perfil> Perfil { get; set; }

        public virtual ICollection<Empresa> Empresa { get; set; }
        public virtual ICollection<ClienteProveedor> ClienteProveedors { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }



    }
}

