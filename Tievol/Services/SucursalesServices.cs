using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tievol.Data;
using Tievol.Data.Entities;
using Tievol.Data.Models;

namespace Tievol.Services
{
    public class SucursalesServices
    {
        private readonly ApplicationDbContext db;

        public SucursalesServices(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<List<Sucursal>> GetSucursales()
        {
            return await db.Sucursales
                .Include("Empresa")
                .Include("Comuna")
                .Include("Ciudad")
                .Include("Region")
                .Include("Pais")
                .Include("Estado")
                .AsNoTracking().ToListAsync();
        }


        public async Task<Sucursal> GetSucursal(int pnIDSucursal)
        {
            return await db.Sucursales.AsNoTracking().FirstOrDefaultAsync(s => s.ID_Sucursal == pnIDSucursal);
        }
        public async Task<Response<Sucursal>> CreateAsync(Sucursal modelo)
        {
            var response = new Response<Sucursal>();
            response.IsSuccess = false;
            try
            {

                //Asignación de atributos. 
                Sucursal sucursal = await db.Sucursales.FirstOrDefaultAsync( s => s.ID_Sucursal == modelo.ID_Sucursal);
                Region region = await db.Regiones.FirstOrDefaultAsync(r => r.ID_Region == modelo.Region.ID_Region);
                modelo.Region = region;
                Comuna comuna = await db.Comunas.FirstOrDefaultAsync(co => co.ID_Comuna == modelo.Comuna.ID_Comuna);
                modelo.Comuna = comuna;
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                Empresa empresa = await db.Empresas.FirstOrDefaultAsync(em => em.ID_Empresa == modelo.Empresa.ID_Empresa);
                modelo.Empresa = empresa;
                Pais pais = await db.Paises.FirstOrDefaultAsync(p => p.ID_Pais == modelo.Pais.ID_Pais);
                modelo.Pais = pais;
                Ciudad ciudad = await db.Ciudades.FirstOrDefaultAsync(ci => ci.ID_Ciudad == modelo.Ciudad.ID_Ciudad);
                modelo.Ciudad = ciudad;

                //Validaciones
                if (modelo == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Sucursales.AsNoTracking().AnyAsync(s => s.ID_Sucursal == modelo.ID_Sucursal))
                {
                    response.Message = "Error el identificador ya existe...";
                    return response;
                }

                if (await db.Sucursales.AsNoTracking().AnyAsync(s => s.N_Sucursal.ToLower() == modelo.N_Sucursal.ToLower()))
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
        public async Task<Response<Sucursal>> UpdateAsync(Sucursal modelo)
        {
            var response = new Response<Sucursal>();
            response.IsSuccess = false;
            try
            {

                //Asignación de atributos. 
                Sucursal sucursal = await db.Sucursales.FirstOrDefaultAsync(s => s.ID_Sucursal == modelo.ID_Sucursal);
                Region region = await db.Regiones.FirstOrDefaultAsync(r => r.ID_Region == modelo.Region.ID_Region);
                modelo.Region = region;
                Comuna comuna = await db.Comunas.FirstOrDefaultAsync(co => co.ID_Comuna == modelo.Comuna.ID_Comuna);
                modelo.Comuna = comuna;
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                Empresa empresa = await db.Empresas.FirstOrDefaultAsync(em => em.ID_Empresa == modelo.Empresa.ID_Empresa);
                modelo.Empresa = empresa;
                Pais pais = await db.Paises.FirstOrDefaultAsync(p => p.ID_Pais == modelo.Pais.ID_Pais);
                modelo.Pais = pais;
                Ciudad ciudad = await db.Ciudades.FirstOrDefaultAsync(ci => ci.ID_Ciudad == modelo.Ciudad.ID_Ciudad);
                modelo.Ciudad = ciudad;

                if (sucursal == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.Sucursales.AsNoTracking().AnyAsync(s => s.N_Sucursal.ToLower() == modelo.N_Sucursal.ToLower() && s.ID_Sucursal != modelo.ID_Sucursal))
                {
                    response.Message = "Error la descripcón ya existe...";
                    return response;
                }

                //Asignación nuevos atributos 

                sucursal.N_Sucursal = modelo.N_Sucursal;
                sucursal.Direccion = modelo.Direccion;
                sucursal.Telefono1 = modelo.Telefono1;
                sucursal.Telefono2 = modelo.Telefono2;
                sucursal.Movil1 = modelo.Movil1;
                sucursal.Movil2 = modelo.Movil2;
                sucursal.Direccion_Correo = modelo.Direccion_Correo;
                sucursal.Ciudad = ciudad;
                sucursal.Comuna = comuna;
                sucursal.Empresa = empresa;
                sucursal.Pais = pais;
                sucursal.Region = region;
                sucursal.Estado = estado; 

                //Asignación tablas anexas 
                db.Sucursales.Update(sucursal);
                await db.SaveChangesAsync();

                db.Entry(sucursal).State = EntityState.Detached;
                db.Entry(sucursal.Region).State = EntityState.Detached;
                db.Entry(sucursal.Comuna).State = EntityState.Detached;
                db.Entry(sucursal.Ciudad).State = EntityState.Detached;
                db.Entry(sucursal.Empresa).State = EntityState.Detached;
                db.Entry(sucursal.Pais).State = EntityState.Detached;
                db.Entry(sucursal.Estado).State = EntityState.Detached;


                //
                response.IsSuccess = true;
                response.Result = sucursal;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            //
            return response;
        }
        public async Task<Response<Sucursal>> DeleteAsync(Sucursal modelo)
        {
            var response = new Response<Sucursal>();
            response.IsSuccess = false;
            try
            {
                //Asignación de atributos. 
                Sucursal sucursal = await db.Sucursales.FirstOrDefaultAsync(s => s.ID_Sucursal == modelo.ID_Sucursal);
                Region region = await db.Regiones.FirstOrDefaultAsync(r => r.ID_Region == modelo.Region.ID_Region);
                modelo.Region = region;
                Comuna comuna = await db.Comunas.FirstOrDefaultAsync(co => co.ID_Comuna == modelo.Comuna.ID_Comuna);
                modelo.Comuna = comuna;
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                Empresa empresa = await db.Empresas.FirstOrDefaultAsync(em => em.ID_Empresa == modelo.Empresa.ID_Empresa);
                modelo.Empresa = empresa;
                Pais pais = await db.Paises.FirstOrDefaultAsync(p => p.ID_Pais == modelo.Pais.ID_Pais);
                modelo.Pais = pais;
                Ciudad ciudad = await db.Ciudades.FirstOrDefaultAsync(ci => ci.ID_Ciudad == modelo.Ciudad.ID_Ciudad);
                modelo.Ciudad = ciudad;

                if (sucursal == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                //
                db.Remove(sucursal);
                await db.SaveChangesAsync();

                //
                response.IsSuccess = true;
                response.Result = sucursal;
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
