using Microsoft.EntityFrameworkCore;
using Tievol.Data;
using Tievol.Data.Entities;
using Tievol.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tievol.Services
{
    public class ComunasServices
    {
        private readonly ApplicationDbContext db;

        public ComunasServices(ApplicationDbContext context)
        {
            db = context;
        }

        
        public async Task<List<Comuna>> GetComunas()
        {
            return await db.Comunas.Include("Region").AsNoTracking().ToListAsync();
        }
        public async Task<Comuna> GetComuna(int pnIDComuna)
        {
            return await db.Comunas.AsNoTracking().FirstOrDefaultAsync(co => co.ID_Comuna == pnIDComuna);
        }
        public async Task<Response<Comuna>> CreateAsync(Comuna modelo)
        {
            
            var response = new Response<Comuna>();
            response.IsSuccess = false;
            try
            {
                //Asignación de atributos 
                Comuna comuna = await db.Comunas.FirstOrDefaultAsync(c => c.ID_Comuna == modelo.ID_Comuna);
                Region region = await db.Regiones.FirstOrDefaultAsync(r => r.ID_Region == modelo.Region.ID_Region);
                modelo.Region = region;
                if (modelo == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Comunas.AsNoTracking().AnyAsync(co => co.ID_Comuna == modelo.ID_Comuna))
                {
                    response.Message = "Error el identificador ya existe...";
                    return response;
                }

                if (await db.Comunas.AsNoTracking().AnyAsync(co => co.N_Comuna.ToLower() == modelo.N_Comuna.ToLower()))
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
        public async Task<Response<Comuna>> UpdateAsync(Comuna modelo)
        {
            var response = new Response<Comuna>();
            response.IsSuccess = false;
            try
            {
                Comuna comuna = await db.Comunas.FirstOrDefaultAsync(co => co.ID_Comuna == modelo.ID_Comuna);
                Region region = await db.Regiones.FirstOrDefaultAsync(r => r.ID_Region == modelo.Region.ID_Region);

                if (comuna == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Comunas.AsNoTracking().AnyAsync(co => co.N_Comuna.ToLower() == modelo.N_Comuna.ToLower() && co.ID_Comuna != modelo.ID_Comuna))
                {
                    response.Message = "Error la descripcón ya existe...";
                    return response;
                }

                comuna.N_Comuna = modelo.N_Comuna;
                comuna.Region = region;// Error? problema al editar region. 

                //
                db.Comunas.Update(comuna);
                await db.SaveChangesAsync();
                db.Entry(comuna).State = EntityState.Detached;
                db.Entry(comuna.Region).State = EntityState.Detached;

                //
                response.IsSuccess = true;
                response.Result = comuna;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            //
            return response;
        }
        public async Task<Response<Comuna>> DeleteAsync(Comuna modelo)
        {
            var response = new Response<Comuna>();
            response.IsSuccess = false;
            try
            {
                Comuna comuna = await db.Comunas.FirstOrDefaultAsync(c => c.ID_Comuna == modelo.ID_Comuna);
                Region region = await db.Regiones.FirstOrDefaultAsync(r => r.ID_Region == modelo.Region.ID_Region);
        
                if (comuna == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                //
                db.Remove(comuna);
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
