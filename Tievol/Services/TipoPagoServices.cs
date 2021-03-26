using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tievol.Data;
using Tievol.Data.Entities;
using Tievol.Data.Models;

namespace Tievol.Services
{
    public class TipoPagoServices
    {
        private readonly ApplicationDbContext db;

        public TipoPagoServices(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<List<Tipo_pago>> GetTipoPagos()
        {
            return await db.Tipo_Pago.Include("Estado").
                AsNoTracking().ToListAsync();
        }

        public async Task<Tipo_pago> GetTipoPago(int pnIDTipomaterial)
        {
            return await db.Tipo_Pago.AsNoTracking().FirstOrDefaultAsync(tm => tm.ID_Tipo_Pago == pnIDTipomaterial);
        }
        public async Task<Response<Tipo_pago>> CreateAsync(Tipo_pago modelo)
        {
            var response = new Response<Tipo_pago>();
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

                if (await db.Tipo_Pago.AsNoTracking().AnyAsync(tm => tm.ID_Tipo_Pago == modelo.ID_Tipo_Pago))
                {
                    response.Message = "Error el identificador ya existe...";
                    return response;
                }

                if (await db.Tipo_Pago.AsNoTracking().AnyAsync(tm => tm.N_Tipo_Pago.ToLower() == modelo.N_Tipo_Pago.ToLower()))
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
        public async Task<Response<Tipo_pago>> UpdateAsync(Tipo_pago modelo)
        {
            var response = new Response<Tipo_pago>();
            response.IsSuccess = false;
            try
            {
                Tipo_pago tipo_Pago = await db.Tipo_Pago.FirstOrDefaultAsync(tipo_Pago => tipo_Pago.ID_Tipo_Pago == modelo.ID_Tipo_Pago) ;
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (tipo_Pago == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Tipo_Pago.AsNoTracking().AnyAsync(tm => tm.N_Tipo_Pago.ToLower() == modelo.N_Tipo_Pago.ToLower() && tm.ID_Tipo_Pago != modelo.ID_Tipo_Pago))
                {
                    response.Message = "Error la descripcón ya existe...";
                    return response;
                }

                //Asignació  nuevos atributos 
                tipo_Pago.N_Tipo_Pago = modelo.N_Tipo_Pago;
                tipo_Pago.Estado = estado; 

                db.Tipo_Pago.Update(tipo_Pago);
                await db.SaveChangesAsync();
                db.Entry(tipo_Pago).State = EntityState.Detached;
                db.Entry(tipo_Pago.Estado).State = EntityState.Detached;

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
        public async Task<Response<Tipo_pago>> DeleteAsync(Tipo_pago modelo)
        {
            var response = new Response<Tipo_pago>();
            response.IsSuccess = false;
            try
            {
                Tipo_pago tipo_Pago = await db.Tipo_Pago.FirstOrDefaultAsync(tipo_Pago => tipo_Pago.ID_Tipo_Pago == modelo.ID_Tipo_Pago);
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (tipo_Pago == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                //
                db.Remove(tipo_Pago);
                await db.SaveChangesAsync();

                //
                response.IsSuccess = true;
                response.Result = tipo_Pago;
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
