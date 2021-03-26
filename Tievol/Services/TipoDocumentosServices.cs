using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tievol.Data;
using Tievol.Data.Entities;
using Tievol.Data.Models;

namespace Tievol.Services
{
    public class TipoDocumentosServices
    {
        private readonly ApplicationDbContext db;

        public TipoDocumentosServices(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<List<Tipo_documento>> GetTipoDocumentos()
        {
            return await db.Tipo_Documentos
            .Include("Estado")
            .AsNoTracking().ToListAsync();
        }


        public async Task<Tipo_documento> GetTipoDocumento(int pnIDTipodocumento)
        {
            return await db.Tipo_Documentos.AsNoTracking().FirstOrDefaultAsync(td => td.ID_Tipo_Documento == pnIDTipodocumento);
        }
        public async Task<Response<Tipo_documento>> CreateAsync(Tipo_documento modelo)
        {
            var response = new Response<Tipo_documento>();
            response.IsSuccess = false;
            try
            {

                Tipo_documento TDocumento = await db.Tipo_Documentos.FirstOrDefaultAsync(td => td.ID_Tipo_Documento == modelo.ID_Tipo_Documento);
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (modelo == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Tipo_Documentos.AsNoTracking().AnyAsync(td => td.ID_Tipo_Documento == modelo.ID_Tipo_Documento))
                {
                    response.Message = "Error el identificador ya existe...";
                    return response;
                }

                if (await db.Tipo_Documentos.AsNoTracking().AnyAsync(td => td.N_Tipo_Documento.ToLower() == modelo.N_Tipo_Documento.ToLower()))
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
        public async Task<Response<Tipo_documento>> UpdateAsync(Tipo_documento modelo)
        {
            var response = new Response<Tipo_documento>();
            response.IsSuccess = false;
            try
            {
                Tipo_documento TDocumento = await db.Tipo_Documentos.FirstOrDefaultAsync(td => td.ID_Tipo_Documento == modelo.ID_Tipo_Documento);
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (TDocumento == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Tipo_Documentos.AsNoTracking().AnyAsync(td => td.N_Tipo_Documento.ToLower() == modelo.N_Tipo_Documento.ToLower() && td.ID_Tipo_Documento != modelo.ID_Tipo_Documento))
                {
                    response.Message = "Error la descripcón ya existe...";
                    return response;
                }
                //Asignación nuevos atributos.
                TDocumento.N_Tipo_Documento = modelo.N_Tipo_Documento;
                TDocumento.Estado = estado;

                //Referencia a otras tablas. 
                db.Tipo_Documentos.Update(TDocumento);
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
        public async Task<Response<Tipo_documento>> DeleteAsync(Tipo_documento modelo)
        {
            var response = new Response<Tipo_documento>();
            response.IsSuccess = false;
            try
            {
                Tipo_documento TDocumento = await db.Tipo_Documentos.FirstOrDefaultAsync(td => td.ID_Tipo_Documento == modelo.ID_Tipo_Documento);
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (TDocumento == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                //
                db.Remove(TDocumento);
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


