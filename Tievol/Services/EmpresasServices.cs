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
    public class EmpresasServices
    {

        private readonly ApplicationDbContext db;

        public EmpresasServices(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<List<Empresa>> GetEmpresas()
        {
            return await db.Empresas
                .Include("Region")
                .Include("Comuna")
                .Include("Ciudad")
                .Include("Pais")
                .Include("Estado")
                .Include("Tipo_Empresa")
                .AsNoTracking().ToListAsync();


        }
        public async Task<Empresa> GetEmpresa(int pnIDEmpresa)
        {
            return await db.Empresas.AsNoTracking().FirstOrDefaultAsync(e => e.ID_Empresa == pnIDEmpresa);
        }
        public async Task<Response<Empresa>> CreateAsync(Empresa modelo)
        {
            var response = new Response<Empresa>();
            response.IsSuccess = false;
            try
            {
                Empresa empresa = await db.Empresas.FirstOrDefaultAsync(e => e.ID_Empresa == modelo.ID_Empresa);
                Region region = await db.Regiones.FirstOrDefaultAsync(r => r.ID_Region == modelo.Region.ID_Region);
                modelo.Region = region;
                Comuna comuna = await db.Comunas.FirstOrDefaultAsync(co => co.ID_Comuna == modelo.Comuna.ID_Comuna);
                modelo.Comuna = comuna;
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                Pais pais = await db.Paises.FirstOrDefaultAsync(p => p.ID_Pais == modelo.Pais.ID_Pais);
                modelo.Pais = pais;
                Ciudad ciudad = await db.Ciudades.FirstOrDefaultAsync(ci => ci.ID_Ciudad == modelo.Ciudad.ID_Ciudad);
                modelo.Ciudad = ciudad;
                Tipo_empresa tipo_Empresa = await db.Tipo_Empresa.FirstOrDefaultAsync(te => te.ID_Tipo_Empresa == modelo.Tipo_Empresa.ID_Tipo_Empresa);
                modelo.Tipo_Empresa = tipo_Empresa;
                if (empresa == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Empresas.AsNoTracking().AnyAsync(e => e.ID_Empresa == modelo.ID_Empresa))
                {
                    response.Message = "Error el identificador ya existe...";
                    return response;
                }

                if (await db.Empresas.AsNoTracking().AnyAsync(e => e.Rut.ToLower() == modelo.Rut.ToLower()))
                {
                    response.Message = "Error el registro ya existe...";
                    return response;
                }
                //
                db.Add(empresa);
                await db.SaveChangesAsync();
                db.Entry(empresa).State = EntityState.Detached;


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
        public async Task<Response<Empresa>> UpdateAsync(Empresa modelo)
        {
            var response = new Response<Empresa>();
            response.IsSuccess = false;
            try
            {
                Empresa empresa = await db.Empresas.FirstOrDefaultAsync(e => e.ID_Empresa == modelo.ID_Empresa);
                Region region = await db.Regiones.FirstOrDefaultAsync(r => r.ID_Region == modelo.Region.ID_Region);
                modelo.Region = region;
                Comuna comuna = await db.Comunas.FirstOrDefaultAsync(co => co.ID_Comuna == modelo.Comuna.ID_Comuna);
                modelo.Comuna = comuna;
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                Pais pais = await db.Paises.FirstOrDefaultAsync(p => p.ID_Pais == modelo.Pais.ID_Pais);
                modelo.Pais = pais;
                Ciudad ciudad = await db.Ciudades.FirstOrDefaultAsync(ci => ci.ID_Ciudad == modelo.Ciudad.ID_Ciudad);
                modelo.Ciudad = ciudad;
                Tipo_empresa tipo_Empresa = await db.Tipo_Empresa.FirstOrDefaultAsync(te => te.ID_Tipo_Empresa == modelo.Tipo_Empresa.ID_Tipo_Empresa);
                modelo.Tipo_Empresa = tipo_Empresa;
                if (empresa == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Empresas.AsNoTracking().AnyAsync(u => u.Rut.ToLower() == modelo.Rut.ToLower() && u.ID_Empresa != modelo.ID_Empresa))
                {
                    response.Message = "Error la descripcón ya existe...";
                    return response;
                }

                //

                empresa.N_Empresa = modelo.N_Empresa;
                empresa.Rut = modelo.Rut;
                empresa.Giro = modelo.Giro;
                empresa.Razon_Social = modelo.Razon_Social;
                empresa.Observaciones = modelo.Observaciones;
                empresa.Movil = modelo.Movil;
                empresa.Telefono1 = modelo.Telefono1;
                empresa.Telefono2 = modelo.Telefono2;
                empresa.Direccion = modelo.Direccion;
                empresa.Web = modelo.Web;
                empresa.Direccion_Correo = modelo.Direccion_Correo;
                empresa.Ciudad = ciudad;
                empresa.Comuna = comuna;
                empresa.Region = region;
                empresa.Pais = pais;
                empresa.Estado = estado;
                empresa.Tipo_Empresa = tipo_Empresa;

                db.Empresas.Update(empresa);
                await db.SaveChangesAsync();
                db.Entry(empresa).State = EntityState.Detached;
                db.Entry(empresa.Ciudad).State = EntityState.Detached;
                db.Entry(empresa.Comuna).State = EntityState.Detached;
                db.Entry(empresa.Region).State = EntityState.Detached;
                db.Entry(empresa.Pais).State = EntityState.Detached;
                db.Entry(empresa.Estado).State = EntityState.Detached;
                db.Entry(empresa.Tipo_Empresa).State = EntityState.Detached;

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
        public async Task<Response<Empresa>> DeleteAsync(Empresa modelo)
        {
            var response = new Response<Empresa>();
            response.IsSuccess = false;
            try
            {
                Empresa empresa = await db.Empresas.FirstOrDefaultAsync(e => e.ID_Empresa == modelo.ID_Empresa);
                Region region = await db.Regiones.FirstOrDefaultAsync(r => r.ID_Region == modelo.Region.ID_Region);
                modelo.Region = region;
                Comuna comuna = await db.Comunas.FirstOrDefaultAsync(co => co.ID_Comuna == modelo.Comuna.ID_Comuna);
                modelo.Comuna = comuna;
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                Pais pais = await db.Paises.FirstOrDefaultAsync(p => p.ID_Pais == modelo.Pais.ID_Pais);
                modelo.Pais = pais;
                Ciudad ciudad = await db.Ciudades.FirstOrDefaultAsync(ci => ci.ID_Ciudad == modelo.Ciudad.ID_Ciudad);
                modelo.Ciudad = ciudad;
                Tipo_empresa tipo_Empresa = await db.Tipo_Empresa.FirstOrDefaultAsync(te => te.ID_Tipo_Empresa == modelo.Tipo_Empresa.ID_Tipo_Empresa);
                modelo.Tipo_Empresa = tipo_Empresa;
                if (empresa == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                //
                db.Remove(empresa);
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
