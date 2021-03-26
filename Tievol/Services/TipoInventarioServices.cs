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
    public class TipoInventarioServices
    {
        private readonly ApplicationDbContext db;

        public TipoInventarioServices(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<List<Tipo_inventario>> GetTipoInventario()
        {
            return await db.Tipo_Inventario.Include("Estado").
                AsNoTracking().ToListAsync();
        }

        public async Task<Tipo_inventario> GetTipoInventario(int pnIDTipoinventario)
        {
            return await db.Tipo_Inventario.AsNoTracking().FirstOrDefaultAsync(ti => ti.ID_Tipo_Inventario == pnIDTipoinventario);
        }
        public async Task<Response<Tipo_inventario>> CreateAsync(Tipo_inventario modelo)
        {
            var response = new Response<Tipo_inventario>();
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

                if (await db.Tipo_Inventario.AsNoTracking().AnyAsync(ti => ti.ID_Tipo_Inventario == modelo.ID_Tipo_Inventario))
                {
                    response.Message = "Error el identificador ya existe...";
                    return response;
                }

                if (await db.Tipo_Inventario.AsNoTracking().AnyAsync(ti => ti.N_Tipo_Inventario.ToLower() == modelo.N_Tipo_Inventario.ToLower()))
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
        public async Task<Response<Tipo_inventario>> UpdateAsync(Tipo_inventario modelo)
        {
            var response = new Response<Tipo_inventario>();
            response.IsSuccess = false;
            try
            {
                Tipo_inventario ti = await db.Tipo_Inventario.FirstOrDefaultAsync(ti => ti.ID_Tipo_Inventario == modelo.ID_Tipo_Inventario);
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (ti == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Tipo_Inventario.AsNoTracking().AnyAsync(ti => ti.N_Tipo_Inventario.ToLower() == modelo.N_Tipo_Inventario.ToLower() && ti.ID_Tipo_Inventario != modelo.ID_Tipo_Inventario))
                {
                    response.Message = "Error la descripcón ya existe...";
                    return response;
                }

                //Asignación nuevos atributos 

                ti.N_Tipo_Inventario = modelo.N_Tipo_Inventario;
                ti.Estado = estado;

                //Asignación tablas anexas
                db.Tipo_Inventario.Update(ti);
                await db.SaveChangesAsync();
                db.Entry(ti).State = EntityState.Detached;
                db.Entry(ti.Estado).State = EntityState.Detached;

                //
                response.IsSuccess = true;
                response.Result = ti;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            //
            return response;
        }
        public async Task<Response<Tipo_inventario>> DeleteAsync(Tipo_inventario modelo)
        {
            var response = new Response<Tipo_inventario>();
            response.IsSuccess = false;
            try
            {
                Tipo_inventario ti = await db.Tipo_Inventario.FirstOrDefaultAsync(ti => ti.ID_Tipo_Inventario == modelo.ID_Tipo_Inventario);
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (ti == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                //
                db.Remove(ti);
                await db.SaveChangesAsync();

                //
                response.IsSuccess = true;
                response.Result = ti;
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
