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
    public class CiudadesServices
    {

        private readonly ApplicationDbContext db;

        public CiudadesServices(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<List<Ciudad>> GetCiudades()
        {
            return await db.Ciudades.Include("Region")
                .AsNoTracking().ToListAsync();
        }
        public async Task<Ciudad> GetCiudad(int pnIDCiudad)
        {
            return await db.Ciudades.AsNoTracking().FirstOrDefaultAsync(e => e.ID_Ciudad == pnIDCiudad);
        }
        public async Task<Response<Ciudad>> CreateAsync(Ciudad modelo)
        {
            var response = new Response<Ciudad>();
            response.IsSuccess = false;

            try
            {
                //Asignación de atributos. 
                Region region = await db.Regiones.FirstOrDefaultAsync(r => r.ID_Region == modelo.Region.ID_Region);
                modelo.Region = region;

                if (modelo == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Ciudades.AsNoTracking().AnyAsync(e => e.ID_Ciudad == modelo.ID_Ciudad))
                {
                    response.Message = "Error el identificador ya existe...";
                    return response;
                }

                if (await db.Ciudades.AsNoTracking().AnyAsync(e => e.N_Ciudad.ToLower() == modelo.N_Ciudad.ToLower()))
                {
                    response.Message = "Error el registro ya existe...";
                    return response;
                }

                //db.Add(modelo);
                var result = await db.AddAsync<Ciudad>(modelo);
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
        public async Task<Response<Ciudad>> UpdateAsync(Ciudad modelo)
        {
            var response = new Response<Ciudad>();
            response.IsSuccess = false;
            try
            {
                Ciudad ciudad = await db.Ciudades.FirstOrDefaultAsync(c => c.ID_Ciudad == modelo.ID_Ciudad);
                Region region = await db.Regiones.FirstOrDefaultAsync(r => r.ID_Region == modelo.Region.ID_Region);
                modelo.Region = region;

                if (ciudad == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Ciudades.AsNoTracking().AnyAsync(u => u.N_Ciudad.ToLower() == modelo.N_Ciudad.ToLower() && u.ID_Ciudad != modelo.ID_Ciudad))
                {
                    response.Message = "Error la descripcón ya existe...";
                    return response;
                }


                ciudad.N_Ciudad = modelo.N_Ciudad;
                ciudad.Region = region;

                //
                db.Ciudades.Update(ciudad);
                await db.SaveChangesAsync();
                db.Entry(ciudad).State = EntityState.Detached;
                db.Entry(ciudad.Region).State = EntityState.Detached;



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
        public async Task<Response<Ciudad>> DeleteAsync(Ciudad modelo)
        {
            var response = new Response<Ciudad>();
            response.IsSuccess = false;
            try
            {
                Ciudad ciudad = await db.Ciudades.FirstOrDefaultAsync(c => c.ID_Ciudad == modelo.ID_Ciudad);
                Region region = await db.Regiones.FirstOrDefaultAsync(r => r.ID_Region == modelo.Region.ID_Region);
                

                if (ciudad == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                //
                db.Remove(ciudad);
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
