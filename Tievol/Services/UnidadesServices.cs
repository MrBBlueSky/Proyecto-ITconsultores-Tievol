using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tievol.Data;
using Tievol.Data.Entities;
using Tievol.Data.Models;

namespace Tievol.Services
{
    public class UnidadesServices
    {
        private readonly ApplicationDbContext db;

        public UnidadesServices(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<List<Unidad>> GetUnidades()
        {
            return await db.Unidades.Include("Estado")
            .AsNoTracking().ToListAsync();
        }
        public async Task<Unidad> GetUnidad(int pnIDUnidad)
        {
            return await db.Unidades.AsNoTracking().FirstOrDefaultAsync(un => un.ID_Unidad == pnIDUnidad);
        }
        public async Task<Response<Unidad>> CreateAsync(Unidad modelo)
        {
            var response = new Response<Unidad>();
            response.IsSuccess = false;
            try
            {
                Unidad unidad = await db.Unidades.FirstOrDefaultAsync(u => u.ID_Unidad == modelo.ID_Unidad);
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (modelo == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Unidades.AsNoTracking().AnyAsync(un => un.ID_Unidad == modelo.ID_Unidad))
                {
                    response.Message = "Error el identificador ya existe...";
                    return response;
                }

                if (await db.Unidades.AsNoTracking().AnyAsync(un => un.N_Unidad.ToLower() == modelo.N_Unidad.ToLower()))
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
        public async Task<Response<Unidad>> UpdateAsync(Unidad modelo)
        {
            var response = new Response<Unidad>();
            response.IsSuccess = false;
            try
            {
                Unidad unidad = await db.Unidades.FirstOrDefaultAsync(u => u.ID_Unidad == modelo.ID_Unidad);
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (unidad == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Unidades.AsNoTracking().AnyAsync(un => un.N_Unidad.ToLower() == modelo.N_Unidad.ToLower() && un.ID_Unidad != modelo.ID_Unidad))
                {
                    response.Message = "Error la descripcón ya existe...";
                    return response;
                }

                //Nuevos atributos
                unidad.N_Unidad = modelo.N_Unidad;
                unidad.Estado = estado;

                //Referencias
                db.Unidades.Update(unidad);
                await db.SaveChangesAsync();
                db.Entry(unidad).State = EntityState.Detached;
                db.Entry(unidad.Estado).State = EntityState.Detached;

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
        public async Task<Response<Unidad>> DeleteAsync(Unidad modelo)
        {
            var response = new Response<Unidad>();
            response.IsSuccess = false;
            try
            {
                Unidad unidad = await db.Unidades.FirstOrDefaultAsync(u => u.ID_Unidad == modelo.ID_Unidad);
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                
                if (unidad == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                //
                db.Remove(unidad);
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

