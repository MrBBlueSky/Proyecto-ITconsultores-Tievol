using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tievol.Data;
using Tievol.Data.Entities;
using Tievol.Data.Models;

namespace Tievol.Services
{
    public class EstadosServices
    {
        private readonly ApplicationDbContext db;

        public EstadosServices(ApplicationDbContext context)
        {
            db = context;
            //db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<List<Estado>> GetEstados()
        {
            return await db.Estados.AsNoTracking().ToListAsync();
        }
        public async Task<Estado> GetEstado(int pnIDEstado)
        {
            return await db.Estados.AsNoTracking().FirstOrDefaultAsync(e => e.ID_Estado == pnIDEstado);
        }
        public async Task<Response<Estado>> CreateAsync(Estado modelo)
        {
            var response = new Response<Estado>();
            response.IsSuccess = false;
            try
            {

                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.ID_Estado);

                if (modelo == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Estados.AsNoTracking().AnyAsync(e => e.ID_Estado == modelo.ID_Estado))
                {
                    response.Message = "Error el identificador ya existe...";
                    return response;
                }

                if (await db.Estados.AsNoTracking().AnyAsync(e => e.N_Estado.ToLower() == modelo.N_Estado.ToLower()))
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
        public async Task<Response<Estado>> UpdateAsync(Estado modelo)
        {
            var response = new Response<Estado>();
            response.IsSuccess = false;
            try
            {

                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.ID_Estado);
                if (estado == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Estados.AsNoTracking().AnyAsync(u => u.N_Estado.ToLower() == modelo.N_Estado.ToLower() && u.ID_Estado != modelo.ID_Estado))
                {
                    response.Message = "Error la descripcón ya existe...";
                    return response;
                }

                estado.N_Estado = modelo.N_Estado;

                //
                db.Estados.Update(estado);
                await db.SaveChangesAsync();
                db.Entry(estado).State = EntityState.Detached;

                //
                response.IsSuccess = true;
                response.Result = estado;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            //
            return response;
        }
        public async Task<Response<Estado>> DeleteAsync(Estado modelo)
        {
            var response = new Response<Estado>();
            response.IsSuccess = false;
            try
            {
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.ID_Estado);

                if (estado == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                //
                db.Remove(estado);
                await db.SaveChangesAsync();

                //
                response.IsSuccess = true;
                response.Result = estado;
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

