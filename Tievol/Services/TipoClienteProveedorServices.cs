using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tievol.Data;
using Tievol.Data.Entities;
using Tievol.Data.Models;

namespace Tievol.Services
{
    public class TipoClienteProveedorServices
    {
        private readonly ApplicationDbContext db;

        public TipoClienteProveedorServices(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<List<Tipo_cliente_proveedor>> GetTipoClienteProveedor()
        {
            return await db.Tipo_Cliente_Proveedor.Include("Estado").
                AsNoTracking().ToListAsync();
        }

        public async Task<Tipo_cliente_proveedor> GetTipoClienteProveedor(int pnIDTipoclienteproveedor)
        {
            return await db.Tipo_Cliente_Proveedor.AsNoTracking().FirstOrDefaultAsync(tp => tp.ID_Tipo_Cliente_Proveedor == pnIDTipoclienteproveedor);
        }
        public async Task<Response<Tipo_cliente_proveedor>> CreateAsync(Tipo_cliente_proveedor modelo)
        {
            var response = new Response<Tipo_cliente_proveedor>();
            response.IsSuccess = false;
            try
            {   
                
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (modelo == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Tipo_Cliente_Proveedor.AsNoTracking().AnyAsync(tp => tp.ID_Tipo_Cliente_Proveedor == modelo.ID_Tipo_Cliente_Proveedor))
                {
                    response.Message = "Error el identificador ya existe...";
                    return response;
                }

                if (await db.Tipo_Cliente_Proveedor.AsNoTracking().AnyAsync(tp => tp.N_Tipo_Cliente_Proveedor.ToLower() == modelo.N_Tipo_Cliente_Proveedor.ToLower()))
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
        public async Task<Response<Tipo_cliente_proveedor>> UpdateAsync(Tipo_cliente_proveedor modelo)
        {
            var response = new Response<Tipo_cliente_proveedor>();
            response.IsSuccess = false;
            try
            {
                Tipo_cliente_proveedor tp = await db.Tipo_Cliente_Proveedor.FirstOrDefaultAsync( tp => tp.ID_Tipo_Cliente_Proveedor == modelo.ID_Tipo_Cliente_Proveedor);
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (tp == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Tipo_Cliente_Proveedor.AsNoTracking().AnyAsync(tp => tp.N_Tipo_Cliente_Proveedor.ToLower() == modelo.N_Tipo_Cliente_Proveedor.ToLower() && tp.ID_Tipo_Cliente_Proveedor != modelo.ID_Tipo_Cliente_Proveedor))
                {
                    response.Message = "Error la descripcón ya existe...";
                    return response;
                }

                //Asignación de atributos nuevos 

                tp.N_Tipo_Cliente_Proveedor = modelo.N_Tipo_Cliente_Proveedor;
                tp.Estado = estado; 

                //Asignación de tablas anexas
                db.Tipo_Cliente_Proveedor.Update(tp);
                await db.SaveChangesAsync();
                db.Entry(tp).State = EntityState.Detached;
                db.Entry(tp.Estado).State = EntityState.Detached;

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
        public async Task<Response<Tipo_cliente_proveedor>> DeleteAsync(Tipo_cliente_proveedor modelo)
        {
            var response = new Response<Tipo_cliente_proveedor>();
            response.IsSuccess = false;
            try
            {
                Tipo_cliente_proveedor tp = await db.Tipo_Cliente_Proveedor.FirstOrDefaultAsync(tp => tp.ID_Tipo_Cliente_Proveedor == modelo.ID_Tipo_Cliente_Proveedor);
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (tp == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                //
                db.Remove(tp);
                await db.SaveChangesAsync();

                //
                response.IsSuccess = true;
                response.Result = tp;
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

