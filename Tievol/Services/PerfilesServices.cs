using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tievol.Data;
using Tievol.Data.Entities;
using Tievol.Data.Models;
using Tievol.Pages.Referencias;

namespace Tievol.Services
{
    public class PerfilesServices
    {
        private readonly ApplicationDbContext db;

        public PerfilesServices(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<List<Perfil>> GetPerfiles()
        {
            return await db.Perfiles.Include("Estado").
            AsNoTracking().ToListAsync();
        }

        public async Task<Perfil> GetPerfil(int pnIDPerfil)
        {
            return await db.Perfiles.AsNoTracking().FirstOrDefaultAsync(pf => pf.ID_Perfil == pnIDPerfil);
        }
        public async Task<Response<Perfil>> CreateAsync(Perfil modelo)
        {
            var response = new Response<Perfil>();
            response.IsSuccess = false;
            try
            {
                Perfil perfil = await db.Perfiles.FirstOrDefaultAsync(p => p.ID_Perfil == modelo.ID_Perfil);
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (modelo == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Perfiles.AsNoTracking().AnyAsync(pf => pf.ID_Perfil == modelo.ID_Perfil))
                {
                    response.Message = "Error el identificador ya existe...";
                    return response;
                }

                if (await db.Perfiles.AsNoTracking().AnyAsync(pf => pf.N_Perfil.ToLower() == modelo.N_Perfil.ToLower()))
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
        public async Task<Response<Perfil>> UpdateAsync(Perfil modelo)
        {
            var response = new Response<Perfil>();
            response.IsSuccess = false;
            try
            {
                Perfil perfil = await db.Perfiles.FirstOrDefaultAsync(p => p.ID_Perfil == modelo.ID_Perfil);
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;


                if (perfil == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Perfiles.AsNoTracking().AnyAsync(pf => pf.N_Perfil.ToLower() == modelo.N_Perfil.ToLower() && pf.ID_Perfil != modelo.ID_Perfil))
                {
                    response.Message = "Error la descripcón ya existe...";
                    return response;
                }
                
                //asignación de nuevos atributos.
                perfil.N_Perfil = modelo.N_Perfil;
                perfil.Estado = estado;

                //Referencia a otras tablas.
                db.Perfiles.Update(perfil);
                await db.SaveChangesAsync();
                db.Entry(perfil).State = EntityState.Detached;
                db.Entry(perfil.Estado).State = EntityState.Detached;

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
        public async Task<Response<Perfil>> DeleteAsync(Perfil modelo)
        {
            var response = new Response<Perfil>();
            response.IsSuccess = false;
            try
            {
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                Perfil perfil = await db.Perfiles.FirstOrDefaultAsync(p => p.ID_Perfil == modelo.ID_Perfil);
                if (perfil == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                //entra a la excepcion si elimino por segunda vez
                db.Remove(perfil);
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
