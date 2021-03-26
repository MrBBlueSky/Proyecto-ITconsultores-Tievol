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
    public class UbicacionesServices
    {
        private readonly ApplicationDbContext db;

        public UbicacionesServices(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<List<Ubicacion>> GetUbicaciones()
        {
            return await db.Ubicaciones
                .Include("Bodega")
                .Include("Estado")
                .AsNoTracking().ToListAsync();
        }
        public async Task<Ubicacion> GetUbicacion(int pnIDUbicacion)
        {
            return await db.Ubicaciones.AsNoTracking().FirstOrDefaultAsync(ub => ub.ID_Ubicacion == pnIDUbicacion);
        }
        public async Task<Response<Ubicacion>> CreateAsync(Ubicacion modelo)
        {
            var response = new Response<Ubicacion>();
            response.IsSuccess = false;
            try
            {
                Bodega bodega = await db.Bodegas.FirstOrDefaultAsync(b => b.ID_Bodega == modelo.Bodega.ID_Bodega);
                modelo.Bodega = bodega;
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;

                if (modelo == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Ubicaciones.AsNoTracking().AnyAsync(ub => ub.ID_Ubicacion == modelo.ID_Ubicacion))
                {
                    response.Message = "Error el identificador ya existe...";
                    return response;
                }

                if (await db.Ubicaciones.AsNoTracking().AnyAsync(ub => ub.N_Ubicacion.ToLower() == modelo.N_Ubicacion.ToLower()))
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
        public async Task<Response<Ubicacion>> UpdateAsync(Ubicacion modelo)
        {
            var response = new Response<Ubicacion>();
            response.IsSuccess = false;
            try
            {
                Ubicacion ubicacion = await db.Ubicaciones.FirstOrDefaultAsync(u => u.ID_Ubicacion == modelo.ID_Ubicacion);
                Bodega bodega = await db.Bodegas.FirstOrDefaultAsync(b => b.ID_Bodega == modelo.Bodega.ID_Bodega);
                modelo.Bodega = bodega;
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;

                if (ubicacion == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Ubicaciones.AsNoTracking().AnyAsync(ub => ub.N_Ubicacion.ToLower() == modelo.N_Ubicacion.ToLower() && ub.ID_Ubicacion != modelo.ID_Ubicacion))
                {
                    response.Message = "Error la descripcón ya existe...";
                    return response;
                }

                //Asignación de nuevos atributos
                ubicacion.N_Ubicacion = modelo.N_Ubicacion;
                ubicacion.Bodega = bodega;
                ubicacion.Estado = estado; 

                //Referenciacion de tablas anexas
                db.Ubicaciones.Update(ubicacion);
                await db.SaveChangesAsync();
                db.Entry(ubicacion).State = EntityState.Detached;
                db.Entry(ubicacion.Bodega).State = EntityState.Detached;
                db.Entry(ubicacion.Estado).State = EntityState.Detached;

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
        public async Task<Response<Ubicacion>> DeleteAsync(Ubicacion modelo)
        {
            var response = new Response<Ubicacion>();
            response.IsSuccess = false;
            try
            {
                Ubicacion ubicacion = await db.Ubicaciones.FirstOrDefaultAsync(u => u.ID_Ubicacion == modelo.ID_Ubicacion);
                Bodega bodega = await db.Bodegas.FirstOrDefaultAsync(b => b.ID_Bodega == modelo.Bodega.ID_Bodega);
                modelo.Bodega = bodega;
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (ubicacion == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                //
                db.Remove(ubicacion);
                await db.SaveChangesAsync();

                //
                response.IsSuccess = true;
                response.Result = ubicacion;
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

