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
    public class TipoEmpresaServices
    {
        private readonly ApplicationDbContext db;

        public TipoEmpresaServices(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<List<Tipo_empresa>> GetTipoEmpresa()
        {
            return await db.Tipo_Empresa.Include("Estado").
                AsNoTracking().ToListAsync();
        }

        public async Task<Tipo_empresa> GetTipoEmpresa(int pnIDTipoempresa)
        {
            return await db.Tipo_Empresa.AsNoTracking().FirstOrDefaultAsync(te => te.ID_Tipo_Empresa == pnIDTipoempresa);
        }
        public async Task<Response<Tipo_empresa>> CreateAsync(Tipo_empresa modelo)
        {
            var response = new Response<Tipo_empresa>();
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

                if (await db.Tipo_Empresa.AsNoTracking().AnyAsync(te => te.ID_Tipo_Empresa == modelo.ID_Tipo_Empresa))
                {
                    response.Message = "Error el identificador ya existe...";
                    return response;
                }

                if (await db.Tipo_Empresa.AsNoTracking().AnyAsync(te => te.N_Tipo_Empresa.ToLower() == modelo.N_Tipo_Empresa.ToLower()))
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
        public async Task<Response<Tipo_empresa>> UpdateAsync(Tipo_empresa modelo)
        {
            var response = new Response<Tipo_empresa>();
            response.IsSuccess = false;
            try
            {
                Tipo_empresa te = await db.Tipo_Empresa.FirstOrDefaultAsync(te => te.ID_Tipo_Empresa == modelo.ID_Tipo_Empresa);
                Estado estado = await db.Estados.FirstOrDefaultAsync(te => te.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (te == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Tipo_Empresa.AsNoTracking().AnyAsync(te => te.N_Tipo_Empresa.ToLower() == modelo.N_Tipo_Empresa.ToLower() && te.ID_Tipo_Empresa != modelo.ID_Tipo_Empresa))
                {
                    response.Message = "Error la descripcón ya existe...";
                    return response;
                }

                //Asignación 

                te.N_Tipo_Empresa = modelo.N_Tipo_Empresa;
                te.Estado = estado;

                db.Tipo_Empresa.Update(te);
                await db.SaveChangesAsync();
                db.Entry(te).State = EntityState.Detached;
                db.Entry(te.Estado).State = EntityState.Detached;

                //
                response.IsSuccess = true;
                response.Result = te;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            //
            return response;
        }
        public async Task<Response<Tipo_empresa>> DeleteAsync(Tipo_empresa modelo)
        {
            var response = new Response<Tipo_empresa>();
            response.IsSuccess = false;
            try
            {
                Tipo_empresa te = await db.Tipo_Empresa.FirstOrDefaultAsync(te => te.ID_Tipo_Empresa == modelo.ID_Tipo_Empresa);
                Estado estado = await db.Estados.FirstOrDefaultAsync(te => te.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (te == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                //
                db.Remove(te);
                await db.SaveChangesAsync();

                //
                response.IsSuccess = true;
                response.Result = te;
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
