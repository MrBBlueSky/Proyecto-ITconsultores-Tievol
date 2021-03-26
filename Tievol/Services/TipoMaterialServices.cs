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
    public class TipoMaterialServices
    {
        private readonly ApplicationDbContext db;

        public TipoMaterialServices(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<List<Tipo_material>> GetTipoMaterial()
        {
            return await db.Tipo_Material.Include("Estado").
                AsNoTracking().ToListAsync();
        }

        public async Task<Tipo_material> GetTipoMaterial(int pnIDTipomaterial)
        {
            return await db.Tipo_Material.AsNoTracking().FirstOrDefaultAsync(tm => tm.ID_Tipo_Material == pnIDTipomaterial);
        }
        public async Task<Response<Tipo_material>> CreateAsync(Tipo_material modelo)
        {
            var response = new Response<Tipo_material>();
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

                if (await db.Tipo_Material.AsNoTracking().AnyAsync(tm => tm.ID_Tipo_Material == modelo.ID_Tipo_Material))
                {
                    response.Message = "Error el identificador ya existe...";
                    return response;
                }

                if (await db.Tipo_Material.AsNoTracking().AnyAsync(tm => tm.N_Tipo_Material.ToLower() == modelo.N_Tipo_Material.ToLower()))
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
        public async Task<Response<Tipo_material>> UpdateAsync(Tipo_material modelo)
        {
            var response = new Response<Tipo_material>();
            response.IsSuccess = false;
            try
            {
                Tipo_material tipo_Material = await db.Tipo_Material.FirstOrDefaultAsync(tipo_Material => tipo_Material.ID_Tipo_Material == modelo.ID_Tipo_Material); 
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (tipo_Material == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Tipo_Material.AsNoTracking().AnyAsync(tm => tm.N_Tipo_Material.ToLower() == modelo.N_Tipo_Material.ToLower() && tm.ID_Tipo_Material != modelo.ID_Tipo_Material))
                {
                    response.Message = "Error la descripcón ya existe...";
                    return response;
                }

                //
                tipo_Material.N_Tipo_Material = modelo.N_Tipo_Material;
                tipo_Material.Estado = estado;

                //
                db.Tipo_Material.Update(tipo_Material);
                await db.SaveChangesAsync();
                db.Entry(tipo_Material).State = EntityState.Detached;
                db.Entry(tipo_Material.Estado).State = EntityState.Detached;

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
        public async Task<Response<Tipo_material>> DeleteAsync(Tipo_material modelo)
        {
            var response = new Response<Tipo_material>();
            response.IsSuccess = false;
            try
            {
                Tipo_material tipo_Material = await db.Tipo_Material.FirstOrDefaultAsync(tipo_Material => tipo_Material.ID_Tipo_Material == modelo.ID_Tipo_Material);
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (tipo_Material == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                //
                db.Remove(tipo_Material);
                await db.SaveChangesAsync();

                //
                response.IsSuccess = true;
                response.Result = tipo_Material;
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
