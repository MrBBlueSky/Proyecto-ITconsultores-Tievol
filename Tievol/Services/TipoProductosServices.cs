using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tievol.Data;
using Tievol.Data.Entities;
using Tievol.Data.Models;

namespace Tievol.Services
{
    public class TipoProductosServices
    {
        private readonly ApplicationDbContext db;

        public TipoProductosServices(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<List<Tipo_producto>> GetTipoProductos()
        {
            return await db.Tipo_Productos.Include("Estado").
                AsNoTracking().ToListAsync();
        }


        public async Task<Tipo_producto> GetTipoProducto(int pnIDTipoproducto)
        {
            return await db.Tipo_Productos.AsNoTracking().FirstOrDefaultAsync(tp => tp.ID_Tipo_Producto == pnIDTipoproducto);
        }
        public async Task<Response<Tipo_producto>> CreateAsync(Tipo_producto modelo)
        {
            var response = new Response<Tipo_producto>();
            response.IsSuccess = false;
            try
            {
                Tipo_producto TProducto = await db.Tipo_Productos.FirstOrDefaultAsync(tp => tp.ID_Tipo_Producto == modelo.ID_Tipo_Producto);
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (modelo == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Tipo_Productos.AsNoTracking().AnyAsync(tp => tp.ID_Tipo_Producto == modelo.ID_Tipo_Producto))
                {
                    response.Message = "Error el identificador ya existe...";
                    return response;
                }

                if (await db.Tipo_Productos.AsNoTracking().AnyAsync(tp => tp.N_Tipo_Producto.ToLower() == modelo.N_Tipo_Producto.ToLower()))
                {
                    response.Message = "Error el registro ya existe...";
                    return response;
                }
                //

                db.Add(modelo);

                await db.SaveChangesAsync();





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
        public async Task<Response<Tipo_producto>> UpdateAsync(Tipo_producto modelo)
        {
            var response = new Response<Tipo_producto>();
            response.IsSuccess = false;
            try
            {
                Tipo_producto TProducto = await db.Tipo_Productos.FirstOrDefaultAsync(tp => tp.ID_Tipo_Producto == modelo.ID_Tipo_Producto);
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (TProducto == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Tipo_Productos.AsNoTracking().AnyAsync(tp => tp.N_Tipo_Producto.ToLower() == modelo.N_Tipo_Producto.ToLower() && tp.ID_Tipo_Producto != modelo.ID_Tipo_Producto))
                {
                    response.Message = "Error la descripcón ya existe...";
                    return response;
                }

                //Asignación de nuevos atributos
                TProducto.N_Tipo_Producto = modelo.N_Tipo_Producto;
                TProducto.Estado = estado;
                
                //Referenciación a tablas anexas
                db.Tipo_Productos.Update(TProducto);
                await db.SaveChangesAsync();
                db.Entry(TProducto).State = EntityState.Detached;
                db.Entry(TProducto.Estado).State = EntityState.Detached;

                //
                response.IsSuccess = true;
                response.Result = TProducto;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            //
            return response;
        }
        public async Task<Response<Tipo_producto>> DeleteAsync(Tipo_producto modelo)
        {
            var response = new Response<Tipo_producto>();
            response.IsSuccess = false;
            try
            {
                Tipo_producto TProducto = await db.Tipo_Productos.FirstOrDefaultAsync(tp => tp.ID_Tipo_Producto == modelo.ID_Tipo_Producto);
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (TProducto == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                //
                db.Remove(TProducto);
                await db.SaveChangesAsync();

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

    }

}



