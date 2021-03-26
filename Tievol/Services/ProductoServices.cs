using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tievol.Data;
using Tievol.Data.Entities;
using Tievol.Data.Models;
using Tievol.Pages.Referencias;

namespace Tievol.Services
{
    public class ProductoServices
    {
        private readonly ApplicationDbContext db;

        public ProductoServices(ApplicationDbContext context)
        {
            db = context;
        }
        public async Task<List<Data.Entities.Producto>> GetProductos()
        {
            return await db.Productos
                .Include("Estado")
                .Include("TipoDescuento")
                .Include("Unidad")
                .Include("Marca")
                .Include("Familia")
                .Include("SubFamilia")
                .Include("TipoProducto")
                .Include("TipoInventario")
                .Include("TipoMaterial")
                .Include("ClienteProveedor")
            .AsNoTracking().ToListAsync();
        }
        public async Task<Data.Entities.Producto> GetProducto(int pnIDProducto)
        {
            return await db.Productos
                .Include("Estado")
                .Include("TipoDescuento")
                .Include("Unidad")
                .Include("Marca")
                .Include("Familia")
                .Include("SubFamilia")
                .Include("TipoProducto")
                .Include("TipoInventario")
                .Include("TipoMaterial")
                .Include("ClienteProveedor")
                .AsNoTracking().FirstOrDefaultAsync(p => p.ID_Producto == pnIDProducto);
        }
        public async Task<Response<Data.Entities.Producto>> CreateAsync(Data.Entities.Producto modelo)
        {
            var response = new Response<Data.Entities.Producto>();
            response.IsSuccess = false;
            try
            {
                Estado estado = db.Estados.Find(modelo.Estado.ID_Estado);
                TipoDescuento tipo_Descuento = db.Tipo_Descuentos.Find(modelo.TipoDescuento.ID_Tipo_Descuento);
                Unidad unidad = db.Unidades.Find(modelo.Unidad.ID_Unidad);
                Marca marca = db.Marca.Find(modelo.Marca.ID_Marca);
                Familia familia = db.Familias.Find(modelo.Familia.ID_Familia);
                Subfamilia subfamilia = db.Subfamilia.Find(modelo.SubFamilia.ID_Subfamilia);
                Tipo_producto tipoProducto = db.Tipo_Productos.Find(modelo.TipoProducto.ID_Tipo_Producto);
                Tipo_inventario tipoInventario = db.Tipo_Inventario.Find(modelo.TipoInventario.ID_Tipo_Inventario);
                Tipo_material tipoMaterial = db.Tipo_Material.Find(modelo.TipoMaterial.ID_Tipo_Material);
                Data.Entities.ClienteProveedor clienteProveedor = db.ClienteProveedors.Find(modelo.ClienteProveedor.ID_Cliente_Proveedor);

                modelo.Estado = estado;
                modelo.TipoDescuento = tipo_Descuento;
                modelo.Unidad = unidad;
                modelo.Marca = marca;
                modelo.Familia = familia;
                modelo.SubFamilia = subfamilia;
                modelo.TipoProducto = tipoProducto;
                modelo.TipoInventario = tipoInventario;
                modelo.TipoMaterial = tipoMaterial;
                modelo.ClienteProveedor = clienteProveedor;

                if (modelo == null)
                {
                    response.Message = "Se debe ingresar la información";
                    return response;
                }

                if (tipo_Descuento == null && tipoInventario == null && tipoMaterial == null && tipoProducto == null && marca == null
                    && unidad == null && familia == null && subfamilia == null && clienteProveedor == null && estado == null)
                {
                    response.Message = "Debe asignar un estado";
                    return response;
                }

                if (tipo_Descuento == null)
                {
                    response.Message = "Debe asignar un tipo de descuento";
                    return response;
                }

                //if (tipoInventario == null)
                //{
                //    response.Message = "Debe asignar un tipo de inventario válido";
                //    return response;
                //}

                if (tipoMaterial == null)
                {
                    response.Message = "Debe asignar un tipo de material";
                    return response;
                }

                if (tipoProducto == null)
                {
                    response.Message = "Debe asignar un tipo de producto";
                    return response;
                }

                if (marca == null)
                {
                    response.Message = "Debe asignar una marca válida";
                    return response;
                }

                if (unidad == null)
                {
                    response.Message = "Debe asignar una unidad";
                    return response;
                }

                if (familia == null)
                {
                    response.Message = "Debe asignar una familia de productos";
                    return response;
                }

                if (subfamilia == null)
                {
                    response.Message = "Debe asignar una subfamilia correspondiente";
                    return response;
                }

                if (clienteProveedor == null)
                {
                    response.Message = "Debe asignar un cliente o proveedor";
                    return response;
                }

                if (estado == null)
                {
                    response.Message = "Debe asignar un estado";
                    return response;
                }

                if (await db.Productos.AsNoTracking().AnyAsync(p => p.ID_Producto == modelo.ID_Producto))
                {
                    response.Message = "Error el identificador ya existe...";
                    return response;
                }

                //if (await db.Productos.AsNoTracking().AnyAsync(p => p.N_Producto.ToLower() == modelo.N_Producto.ToLower()))
                //{
                //    response.Message = "Error el registro ya existe...";
                //    return response;
                //}

                db.Add(modelo);
                db.SaveChanges();
                //
                response.IsSuccess = true;
                response.Result = modelo;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            //
            return response;
        }
        public Task<Response<Data.Entities.Producto>> UpdateAsync(Data.Entities.Producto modelo)
        {
            var response = new Response<Data.Entities.Producto>();
            response.IsSuccess = false;
            try
            {
                Data.Entities.Producto producto = db.Productos.Find(modelo.ID_Producto);
                Estado estado = db.Estados.Find(modelo.Estado.ID_Estado);
                TipoDescuento tipo_Descuento = db.Tipo_Descuentos.Find(modelo.TipoDescuento.ID_Tipo_Descuento);
                Unidad unidad = db.Unidades.Find(modelo.Unidad.ID_Unidad);
                Marca marca = db.Marca.Find(modelo.Marca.ID_Marca);
                Familia familia = db.Familias.Find(modelo.Familia.ID_Familia);
                Subfamilia subfamilia = db.Subfamilia.Find(modelo.SubFamilia.ID_Subfamilia);
                Tipo_producto tipoProducto = db.Tipo_Productos.Find(modelo.TipoProducto.ID_Tipo_Producto);
                //TipoInventario tipoInventario = db.Tipo_Inventario.Find(modelo.Tipo_inventario.ID_Tipo_Inventario);
                Tipo_material tipoMaterial = db.Tipo_Material.Find(modelo.TipoMaterial.ID_Tipo_Material);
                Data.Entities.ClienteProveedor clienteProveedor = db.ClienteProveedors.Find(modelo.ClienteProveedor.ID_Cliente_Proveedor);

                modelo.Estado = estado;
                modelo.TipoDescuento = tipo_Descuento;
                modelo.Unidad = unidad;
                modelo.Marca = marca;
                modelo.Familia = familia;
                modelo.SubFamilia = subfamilia;
                modelo.TipoProducto = tipoProducto;
                //modelo.Tipo_inventario = tipoInventario;
                modelo.TipoMaterial = tipoMaterial;
                modelo.ClienteProveedor = clienteProveedor;


                if (producto == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return Task.FromResult(response);
                }

                if (tipo_Descuento == null &&  tipoMaterial == null && tipoProducto == null && marca == null
                    && unidad == null && familia == null && subfamilia == null && clienteProveedor == null && estado == null)
                {
                    response.Message = "Debe asignar un estado";
                    return Task.FromResult(response);
                }

                if (tipo_Descuento == null)
                {
                    response.Message = "Debe asignar un tipo de descuento";
                    return Task.FromResult(response);
                }

                //if (tipoInventario == null)
                //{
                //    response.Message = "Debe asignar un tipo de inventario válido";
                //    return response;
                //}

                if (tipoMaterial == null)
                {
                    response.Message = "Debe asignar un tipo de material";
                    return Task.FromResult(response);
                }

                if (tipoProducto == null)
                {
                    response.Message = "Debe asignar un tipo de producto";
                    return Task.FromResult(response);
                }

                if (marca == null)
                {
                    response.Message = "Debe asignar una marca válida";
                    return Task.FromResult(response);
                }

                if (unidad == null)
                {
                    response.Message = "Debe asignar una unidad";
                    return Task.FromResult(response);
                }

                if (familia == null)
                {
                    response.Message = "Debe asignar una familia de productos";
                    return Task.FromResult(response);
                }

                if (subfamilia == null)
                {
                    response.Message = "Debe asignar una subfamilia correspondiente";
                    return Task.FromResult(response);
                }

                if (clienteProveedor == null)
                {
                    response.Message = "Debe asignar un cliente o proveedor";
                    return Task.FromResult(response);
                }

                if (estado == null)
                {
                    response.Message = "Debe asignar un estado";
                    return Task.FromResult(response);
                }

                //if (await db.Productos.AsNoTracking().AnyAsync(p => p.N_Producto.ToLower() == modelo.N_Producto.ToLower()))
                //{
                //    response.Message = "Error el registro ya existe...";
                //    return response;
                //}

                //Asignación de nuevos atributos



                producto.N_Producto = modelo.N_Producto;
                producto.Descripcion = modelo.Descripcion;
                producto.Observaciones = modelo.Observaciones;
                producto.Precio_Venta = modelo.Precio_Venta;
                producto.Precio_Web = modelo.Precio_Web;
                producto.Valor_Compra = modelo.Valor_Compra;
                producto.Valor_Costo = modelo.Valor_Costo;
                producto.Valor_Flete = modelo.Valor_Flete;
                producto.Valor_Margen = modelo.Valor_Margen;
                producto.Valor_Descuento = modelo.Valor_Descuento;
                producto.Codigo_Barra = modelo.Codigo_Barra;
                producto.Codigo_Interno = modelo.Codigo_Interno;
                producto.Codigo_Parte = modelo.Codigo_Parte;
                producto.Codigo_Proveedor = modelo.Codigo_Proveedor;
                producto.TipoDescuento = tipo_Descuento;
                //producto.Tipo_inventario = tipoInventario;
                producto.TipoMaterial = tipoMaterial;
                producto.TipoProducto = tipoProducto;
                producto.Unidad = unidad;
                producto.Marca = marca;
                producto.Familia = familia;
                producto.SubFamilia = subfamilia;
                producto.ClienteProveedor = clienteProveedor;
                producto.Estado = estado;

                //Referenciación a tablas anexas. 
                db.Productos.Update(producto);
                db.SaveChanges();
                db.Entry(producto).State = EntityState.Detached;
                db.Entry(producto.TipoProducto).State = EntityState.Detached;
                db.Entry(producto.TipoDescuento).State = EntityState.Detached;
                //db.Entry(producto.Tipo_inventario).State = EntityState.Detached;
                db.Entry(producto.TipoMaterial).State = EntityState.Detached;
                db.Entry(producto.Unidad).State = EntityState.Detached;
                db.Entry(producto.Marca).State = EntityState.Detached;
                db.Entry(producto.Familia).State = EntityState.Detached;
                db.Entry(producto.SubFamilia).State = EntityState.Detached;
                db.Entry(producto.ClienteProveedor).State = EntityState.Detached;
                db.Entry(producto.Estado).State = EntityState.Detached;

                //
                response.IsSuccess = true;
                response.Result = producto;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            //
            return Task.FromResult(response);
        }
        public async Task<Response<Data.Entities.Producto>> DeleteAsync(Data.Entities.Producto modelo)
        {
            var response = new Response<Data.Entities.Producto>();
            response.IsSuccess = false;
            try
            {

                Data.Entities.Producto producto = db.Productos.Find(modelo.ID_Producto);

                if (producto == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                //
                db.Remove(producto);
                db.SaveChanges();

                //
                response.IsSuccess = true;
                response.Result = producto;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            //
            return response;
        }



    }

}
