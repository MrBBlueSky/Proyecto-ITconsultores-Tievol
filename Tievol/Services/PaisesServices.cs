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
    public class PaisesServices
    { 
            private readonly ApplicationDbContext db;

            public PaisesServices(ApplicationDbContext context)
            {
                db = context;
            }

            public async Task<List<Pais>> GetPaises()
            {
                return await db.Paises.AsNoTracking().ToListAsync();
            }


            public async Task<Pais> GetPais(int pnIDPais)
            {
                return await db.Paises.AsNoTracking().FirstOrDefaultAsync(ps => ps.ID_Pais == pnIDPais);
            }
            public async Task<Response<Pais>> CreateAsync(Pais modelo)
            {
                var response = new Response<Pais>();
                response.IsSuccess = false;
                try
                {

                Pais pais = await db.Paises.FirstOrDefaultAsync(p => p.ID_Pais == modelo.ID_Pais);

                    if (modelo == null)
                    {
                        response.Message = "Debe proveer la información solicitada...";
                        return response;
                    }

                    if (await db.Paises.AsNoTracking().AnyAsync(ps => ps.ID_Pais == modelo.ID_Pais))
                    {
                        response.Message = "Error el identificador ya existe...";
                        return response;
                    }

                    if (await db.Paises.AsNoTracking().AnyAsync(ps => ps.N_Pais.ToLower() == ps.N_Pais.ToLower()))
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
            public async Task<Response<Pais>> UpdateAsync(Pais modelo)
            {
                var response = new Response<Pais>();
                response.IsSuccess = false;
                try
                {

                Pais pais = await db.Paises.FirstOrDefaultAsync(p => p.ID_Pais == modelo.ID_Pais);
                if (modelo == null)
                    {
                        response.Message = "Debe proveer la información solicitada...";
                        return response;
                    }

                    if (await db.Paises.AsNoTracking().AnyAsync(ps => ps.N_Pais.ToLower() == modelo.N_Pais.ToLower() && ps.ID_Pais != modelo.ID_Pais))
                    {
                        response.Message = "Error la descripcón ya existe...";
                        return response;
                    }

                //

                     pais.N_Pais = modelo.N_Pais;

                    db.Paises.Update(pais);
                    await db.SaveChangesAsync();
                    db.Entry(pais).State = EntityState.Detached;

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
            public async Task<Response<Pais>> DeleteAsync(Pais modelo)
            {
                var response = new Response<Pais>();
                response.IsSuccess = false;
                try
                {

                Pais pais = await db.Paises.FirstOrDefaultAsync(p => p.ID_Pais == modelo.ID_Pais);
                if (pais == null)
                    {
                        response.Message = "Debe proveer la información solicitada...";
                        return response;
                    }

                    //
                    db.Remove(pais);
                    await db.SaveChangesAsync();

                    //
                    response.IsSuccess = true;
                    response.Result = pais;
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
