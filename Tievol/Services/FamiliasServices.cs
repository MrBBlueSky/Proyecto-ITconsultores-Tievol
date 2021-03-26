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
    public class FamiliasServices
    {
        private readonly ApplicationDbContext db;

        public FamiliasServices(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<List<Familia>> GetFamilias()
        {
            return await db.Familias.Include("Estado")
            .AsNoTracking().ToListAsync();
        }


        public async Task<Familia> GetFamilia(int pnIDFamilia)
        {
            return await db.Familias.AsNoTracking().FirstOrDefaultAsync(f => f.ID_Familia == pnIDFamilia);
        }
        public async Task<Response<Familia>> CreateAsync(Familia modelo)
        {
            var response = new Response<Familia>();
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

                if (await db.Familias.AsNoTracking().AnyAsync(f => f.ID_Familia == modelo.ID_Familia))
                {
                    response.Message = "Error el identificador ya existe...";
                    return response;
                }

                if (await db.Familias.AsNoTracking().AnyAsync(f => f.N_Familia.ToLower() == modelo.N_Familia.ToLower()))
                {
                    response.Message = "Error el registro ya existe...";
                    return response;
                }

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
        public async Task<Response<Familia>> UpdateAsync(Familia modelo)
        {
            var response = new Response<Familia>();
            response.IsSuccess = false;
            try
            {
                Familia familia = await db.Familias.FirstOrDefaultAsync( f => f.ID_Familia == modelo.ID_Familia); 
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;

                if (familia == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Familias.AsNoTracking().AnyAsync(f => f.N_Familia.ToLower() == modelo.N_Familia.ToLower() && f.ID_Familia != modelo.ID_Familia))
                {
                    response.Message = "Error la descripcón ya existe...";
                    return response;
                }

                //Asignación de nuevos atributos

                familia.N_Familia = modelo.N_Familia;
                familia.Estado = estado; 

                //Referenciación a tablas anexas. 
                db.Familias.Update(familia);
                await db.SaveChangesAsync();
                db.Entry(familia).State = EntityState.Detached;
                db.Entry(familia.Estado).State = EntityState.Detached;

                //
                response.IsSuccess = true;
                response.Result = familia;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            //
            return response;
        }
        public async Task<Response<Familia>> DeleteAsync(Familia modelo)
        {
            var response = new Response<Familia>();
            response.IsSuccess = false;
            try
            {
                Familia familia = await db.Familias.FirstOrDefaultAsync(f => f.ID_Familia == modelo.ID_Familia);
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;

                if (familia == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                //
                db.Remove(familia);
                await db.SaveChangesAsync();

                //
                response.IsSuccess = true;
                response.Result = familia;
            }
            catch (Exception ex) // Al momento de volver a crear luego de editar o eliminar, extra la excepción del doble hilo
            {
                response.Message = ex.Message;
            }
            //
            return response;

        }

    }

}

