using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tievol.Data;
using Tievol.Data.Entities;
using Tievol.Data.Models;

namespace Tievol.Services
{
    public class MarcaServices
    {
        private readonly ApplicationDbContext db;

        public MarcaServices(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<List<Marca>> GetMarca()
        {
            return await db.Marca.Include("Estado").
                AsNoTracking().ToListAsync();
        }

        public async Task<Marca> GetMarca(int pnIDMarca)
        {
            return await db.Marca.AsNoTracking().FirstOrDefaultAsync(tm => tm.ID_Marca == pnIDMarca);
        }
        public async Task<Response<Marca>> CreateAsync(Marca modelo)
        {
            var response = new Response<Marca>();
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

                if (await db.Marca.AsNoTracking().AnyAsync(tm => tm.ID_Marca == modelo.ID_Marca))
                {
                    response.Message = "Error el identificador ya existe...";
                    return response;
                }

                if (await db.Marca.AsNoTracking().AnyAsync(tm => tm.N_Marca.ToLower() == modelo.N_Marca.ToLower()))
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
        public async Task<Response<Marca>> UpdateAsync(Marca modelo)
        {
            var response = new Response<Marca>();
            response.IsSuccess = false;
            try
            {
                Marca marca = await db.Marca.FirstOrDefaultAsync(m => m.ID_Marca == modelo.ID_Marca);
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (marca == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Marca.AsNoTracking().AnyAsync(tm => tm.N_Marca.ToLower() == modelo.N_Marca.ToLower() && tm.ID_Marca != modelo.ID_Marca))
                {
                    response.Message = "Error la descripcón ya existe...";
                    return response;
                }

                //Asignación de atributos. 
                marca.N_Marca = modelo.N_Marca;
                marca.Estado = estado; 

                //Referienciación de tablas. 
                db.Marca.Update(marca);
                await db.SaveChangesAsync();
                db.Entry(modelo).State = EntityState.Detached;
                db.Entry(modelo.Estado).State = EntityState.Detached;

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
        public async Task<Response<Marca>> DeleteAsync(Marca modelo)
        {
            var response = new Response<Marca>();
            response.IsSuccess = false;
            try
            {
                Marca marca = await db.Marca.FirstOrDefaultAsync(m => m.ID_Marca == modelo.ID_Marca);
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (marca == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                //
                db.Remove(marca);
                await db.SaveChangesAsync();

                //
                response.IsSuccess = true;
                response.Result = marca;
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
