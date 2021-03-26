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
    public class BodegasServices
    {

        private readonly ApplicationDbContext db;

        public BodegasServices(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<List<Bodega>> GetBodegas()
        {
            return await db.Bodegas
                .Include("Sucursal")
                .Include("Estado")
                .AsNoTracking().ToListAsync();
        }


        public async Task<Bodega> GetBodega(int pnIDBodega)
        {
            return await db.Bodegas.AsNoTracking().FirstOrDefaultAsync(b => b.ID_Bodega == pnIDBodega);
        }
        public async Task<Response<Bodega>> CreateAsync(Bodega modelo)
        {
            var response = new Response<Bodega>();
            response.IsSuccess = false;
            try
            {

                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                Sucursal sucursal = await db.Sucursales.FirstOrDefaultAsync(s => s.ID_Sucursal == modelo.Sucursal.ID_Sucursal);
                modelo.Sucursal = sucursal;
                Bodega bodega = await db.Bodegas.FirstOrDefaultAsync(b => b.ID_Bodega == modelo.ID_Bodega);
                if (modelo == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Bodegas.AsNoTracking().AnyAsync(b => b.ID_Bodega == modelo.ID_Bodega))
                {
                    response.Message = "Error el identificador ya existe...";
                    return response;
                }

                if (await db.Bodegas.AsNoTracking().AnyAsync(b => b.N_Bodega.ToLower() == modelo.N_Bodega.ToLower()))
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
        public async Task<Response<Bodega>> UpdateAsync(Bodega modelo)
        {
            var response = new Response<Bodega>();
            response.IsSuccess = false;
            try
            {
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                Bodega bodega = await db.Bodegas.FirstOrDefaultAsync(b => b.ID_Bodega == modelo.ID_Bodega);
                Sucursal sucursal = await db.Sucursales.FirstOrDefaultAsync(s => s.ID_Sucursal == modelo.Sucursal.ID_Sucursal);
             

                if (bodega == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Bodegas.AsNoTracking().AnyAsync(u => u.N_Bodega.ToLower() == modelo.N_Bodega.ToLower() && u.ID_Bodega != modelo.ID_Bodega))
                {
                    response.Message = "Error la descripcón ya existe...";
                    return response;
                }

                bodega.N_Bodega = modelo.N_Bodega;
                bodega.Sucursal = sucursal;
                bodega.Estado = estado;

                //
                db.Bodegas.Update(bodega);
                await db.SaveChangesAsync();
                db.Entry(bodega).State = EntityState.Detached;
                db.Entry(bodega.Sucursal).State = EntityState.Detached;
                db.Entry(bodega.Estado).State = EntityState.Detached;

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
        public async Task<Response<Bodega>> DeleteAsync(Bodega modelo)
        {
            var response = new Response<Bodega>();
            response.IsSuccess = false;
            try
            {
                Bodega bodega = await db.Bodegas.FirstOrDefaultAsync(b => b.ID_Bodega == modelo.ID_Bodega);

                if (bodega == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                //
                db.Remove(bodega);
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