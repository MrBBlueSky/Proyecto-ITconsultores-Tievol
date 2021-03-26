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
    public class RegionesServices
    {

            private readonly ApplicationDbContext db;

            public RegionesServices(ApplicationDbContext context)
            {
                db = context;
            }

            public async Task<List<Region>> GetRegiones()
            {
                return await db.Regiones.AsNoTracking().ToListAsync();
            }
            public async Task<Region> GetRegion(int pnIDRegion)
            {
                return await db.Regiones.AsNoTracking().FirstOrDefaultAsync(r => r.ID_Region == pnIDRegion);
            }
            public async Task<Response<Region>> CreateAsync(Region modelo)
            {
                var response = new Response<Region>();
                response.IsSuccess = false;
                try
                {

                Region region = await db.Regiones.FirstOrDefaultAsync(r => r.ID_Region == modelo.ID_Region);
                if (modelo == null)
                    {
                        response.Message = "Debe proveer la información solicitada...";
                        return response;
                    }

                    if (await db.Regiones.AsNoTracking().AnyAsync(r => r.ID_Region == modelo.ID_Region))
                    {
                        response.Message = "Error el identificador ya existe...";
                        return response;
                    }

                    if (await db.Regiones.AsNoTracking().AnyAsync(r => r.N_Region.ToLower() == modelo.N_Region.ToLower()))
                    {
                        response.Message = "Error el registro ya existe...";
                        return response;
                    }
                //
                
                db.Add(modelo);

                await db.SaveChangesAsync();

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
            public async Task<Response<Region>> UpdateAsync(Region modelo)
            {
                var response = new Response<Region>();
                response.IsSuccess = false;
                try
                {
                Region region = await db.Regiones.FirstOrDefaultAsync(r => r.ID_Region == modelo.ID_Region);

                if (region == null)
                    {
                        response.Message = "Debe proveer la información solicitada...";
                        return response;
                    }

                    if (await db.Regiones.AsNoTracking().AnyAsync(r => r.N_Region.ToLower() == modelo.N_Region.ToLower() && r.ID_Region != modelo.ID_Region))
                    {
                        response.Message = "Error la descripcón ya existe...";
                        return response;
                    }

                    //Asignación de nuevos atributos
                    region.N_Region = modelo.N_Region;
                    

                    //Referencias a otras tablas en caso de haberlas.
                    db.Regiones.Update(region);
                    await db.SaveChangesAsync();
                    db.Entry(region).State = EntityState.Detached;
                    
                    //Devuelve el objeto
                    response.IsSuccess = true;
                    response.Result = region;
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                }
                //
                return response;
            }
            public async Task<Response<Region>> DeleteAsync(Region modelo)
            {
                var response = new Response<Region>();
                response.IsSuccess = false;
                try
                {
                Region region = await db.Regiones.FirstOrDefaultAsync(r => r.ID_Region == modelo.ID_Region);
                    
                    if (region == null)
                    {
                        response.Message = "Debe proveer la información solicitada...";
                        return response;
                    }

                    //
                    db.Remove(region);
                    await db.SaveChangesAsync();

                    //
                    response.IsSuccess = true;
                    response.Result = region;
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
