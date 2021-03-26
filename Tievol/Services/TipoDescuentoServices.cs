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
    public class TipoDescuentoServices
    {
        private readonly ApplicationDbContext db;

        public TipoDescuentoServices(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<List<TipoDescuento>> GetTipoDescuento()
        {
            return await db.Tipo_Descuentos.Include("Estado").
                AsNoTracking().ToListAsync();
        }

        public async Task<TipoDescuento> GetTipoDescuento(int IDTipoDescuento)
        {
            return await db.Tipo_Descuentos.AsNoTracking().FirstOrDefaultAsync(tp => tp.ID_Tipo_Descuento == IDTipoDescuento);
        }
        public async Task<Response<TipoDescuento>> CreateAsync(TipoDescuento modelo)
        {
            var response = new Response<TipoDescuento>();
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

                if (await db.Tipo_Descuentos.AsNoTracking().AnyAsync(tp => tp.ID_Tipo_Descuento == modelo.ID_Tipo_Descuento))
                {
                    response.Message = "Error el identificador ya existe...";
                    return response;
                }

                if (await db.Tipo_Descuentos.AsNoTracking().AnyAsync(tp => tp.N_Tipo_Descuento.ToLower() == modelo.N_Tipo_Descuento.ToLower()))
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
        public async Task<Response<TipoDescuento>> UpdateAsync(TipoDescuento modelo)
        {
            var response = new Response<TipoDescuento>();
            response.IsSuccess = false;
            try
            {
                TipoDescuento tp = await db.Tipo_Descuentos.FirstOrDefaultAsync( tp => tp.ID_Tipo_Descuento == modelo.ID_Tipo_Descuento);
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (tp == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Tipo_Descuentos.AsNoTracking().AnyAsync(tp => tp.N_Tipo_Descuento.ToLower() == modelo.N_Tipo_Descuento.ToLower() && tp.ID_Tipo_Descuento != modelo.ID_Tipo_Descuento))
                {
                    response.Message = "Error la descripcón ya existe...";
                    return response;
                }

                //Asignación de atributos nuevos 

                tp.N_Tipo_Descuento = modelo.N_Tipo_Descuento;
                tp.Estado = estado; 

                //Asignación de tablas anexas
                db.Tipo_Descuentos.Update(tp);
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
        public async Task<Response<TipoDescuento>> DeleteAsync(TipoDescuento modelo)
        {
            var response = new Response<TipoDescuento>();
            response.IsSuccess = false;
            try
            {
                TipoDescuento tp = await db.Tipo_Descuentos.FirstOrDefaultAsync(tp => tp.ID_Tipo_Descuento == modelo.ID_Tipo_Descuento);
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

