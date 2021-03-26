using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tievol.Data;
using Tievol.Data.Entities;
using Tievol.Data.Models;

namespace Tievol.Services
{
    public class SubfamiliaServices
    {
        private readonly ApplicationDbContext db;

        public SubfamiliaServices(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<List<Subfamilia>> GetSubfamilia()
        {
            return await db.Subfamilia.Include("Estado").Include("Familia").
                AsNoTracking().ToListAsync();
        }

        public async Task<Subfamilia> GetSubfamilia(int pnIDSubfamilia)
        {
            return await db.Subfamilia.AsNoTracking().FirstOrDefaultAsync(sf => sf.ID_Subfamilia == pnIDSubfamilia);
        }

        public async Task<Response<Subfamilia>> CreateAsync(Subfamilia modelo)
        {
            var response = new Response<Subfamilia>();
            response.IsSuccess = false;
            try
            {
            
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;

                Familia familia = await db.Familias.FirstOrDefaultAsync(f => f.ID_Familia == modelo.Familia.ID_Familia);
                modelo.Familia = familia;

                if (modelo == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Subfamilia.AsNoTracking().AnyAsync(tm => tm.ID_Subfamilia == modelo.ID_Subfamilia))
                {
                    response.Message = "Error el identificador ya existe...";
                    return response;
                }

                if (await db.Subfamilia.AsNoTracking().AnyAsync(tm => tm.N_Subfamilia.ToLower() == modelo.N_Subfamilia.ToLower()))
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

        public async Task<Response<Subfamilia>> UpdateAsync(Subfamilia modelo)
        {
            var response = new Response<Subfamilia>();
            response.IsSuccess = false;
            try
            {
                Subfamilia subfamilia = await db.Subfamilia.FirstOrDefaultAsync(Sb => Sb.ID_Subfamilia == modelo.ID_Subfamilia);
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;

                Familia familia = await db.Familias.FirstOrDefaultAsync(f => f.ID_Familia == modelo.Familia.ID_Familia);
                modelo.Familia = familia;

                if (subfamilia == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Subfamilia.AsNoTracking().AnyAsync(sf => sf.N_Subfamilia.ToLower() == modelo.N_Subfamilia.ToLower() && sf.ID_Subfamilia != modelo.ID_Subfamilia))
                {
                    response.Message = "Error la descripcón ya existe...";
                    return response;
                }

                //Asignación de nuevos atributos. 
                subfamilia.N_Subfamilia = modelo.N_Subfamilia;
                subfamilia.Estado = estado;
                subfamilia.Familia = familia; 

                //Reasignación de tablas anexas
                db.Subfamilia.Update(subfamilia);
                await db.SaveChangesAsync();
                db.Entry(subfamilia).State = EntityState.Detached;
                db.Entry(subfamilia.Estado).State = EntityState.Detached;
                db.Entry(subfamilia.Familia).State = EntityState.Detached;
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

        public async Task<Response<Subfamilia>> DeleteAsync(Subfamilia modelo)
        {
            var response = new Response<Subfamilia>();
            response.IsSuccess = false;
            try
            {
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                Subfamilia subfamilia = await db.Subfamilia.FirstOrDefaultAsync(Sb => Sb.ID_Subfamilia == modelo.ID_Subfamilia);
                Familia familia = await db.Familias.FirstOrDefaultAsync(f => f.ID_Familia == modelo.Familia.ID_Familia);
                modelo.Familia = familia;

                if (subfamilia == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                //
                db.Remove(subfamilia);
                await db.SaveChangesAsync();

                //
                response.IsSuccess = true;
                response.Result = subfamilia;
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
