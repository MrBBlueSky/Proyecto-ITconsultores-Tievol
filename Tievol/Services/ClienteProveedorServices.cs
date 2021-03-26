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
    public class ClienteProveedorServices
    {
        private readonly ApplicationDbContext db;

        public ClienteProveedorServices(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<List<ClienteProveedor>> GetClienteProveedors()
        {
            return await db.ClienteProveedors
                .Include("Estado")
                //.Include("Region")
                //.Include("Comuna")
                //.Include("Ciudad")
                //.Include("Pais")
                .AsNoTracking().ToListAsync();
        }

        public async Task<ClienteProveedor> GetClienteProveedors(int IDClienteProveedor)
        {
            return await db.ClienteProveedors.AsNoTracking().FirstOrDefaultAsync(tp => tp.ID_Cliente_Proveedor == IDClienteProveedor);
        }
        public async Task<Response<ClienteProveedor>> CreateAsync(ClienteProveedor modelo)
        {
            var response = new Response<ClienteProveedor>();
            response.IsSuccess = false;
            try
            {

                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                //Region region = await db.Regiones.FirstOrDefaultAsync(r => r.ID_Region == modelo.Region.ID_Region);
                //modelo.Region = region;
                //Comuna comuna = await db.Comunas.FirstOrDefaultAsync(co => co.ID_Comuna == modelo.Comuna.ID_Comuna);
                //modelo.Comuna = comuna;
                //Pais pais = await db.Paises.FirstOrDefaultAsync(p => p.ID_Pais == modelo.Pais.ID_Pais);
                //modelo.Pais = pais;
                //Ciudad ciudad = await db.Ciudades.FirstOrDefaultAsync(ci => ci.ID_Ciudad == modelo.Ciudad.ID_Ciudad);
                //modelo.Ciudad = ciudad;
                if (modelo == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.ClienteProveedors.AsNoTracking().AnyAsync(tp => tp.ID_Cliente_Proveedor == modelo.ID_Cliente_Proveedor))
                {
                    response.Message = "Error el identificador ya existe...";
                    return response;
                }

                if (await db.ClienteProveedors.AsNoTracking().AnyAsync(tp => tp.N_Cliente_Proveedor.ToLower() == modelo.N_Cliente_Proveedor.ToLower()))
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
        public async Task<Response<ClienteProveedor>> UpdateAsync(ClienteProveedor modelo)
        {
            var response = new Response<ClienteProveedor>();
            response.IsSuccess = false;
            try
            {
                ClienteProveedor tp = await db.ClienteProveedors.FirstOrDefaultAsync(tp => tp.ID_Cliente_Proveedor == modelo.ID_Cliente_Proveedor);
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (tp == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (await db.ClienteProveedors.AsNoTracking().AnyAsync(tp => tp.N_Cliente_Proveedor.ToLower() == modelo.N_Cliente_Proveedor.ToLower() && tp.ID_Cliente_Proveedor != modelo.ID_Cliente_Proveedor))
                {
                    response.Message = "Error la descripcón ya existe...";
                    return response;
                }

                //Asignación de atributos nuevos 
                tp.ID_Cliente_Proveedor = modelo.ID_Cliente_Proveedor;
                tp.ID_Tipo_Cliente_Proveedor = modelo.ID_Tipo_Cliente_Proveedor;
                tp.ID_Condicion_Venta = modelo.ID_Condicion_Venta;

                tp.N_Cliente_Proveedor = modelo.N_Cliente_Proveedor;
                tp.Rut = modelo.Rut;
                tp.Razon_Social = modelo.Razon_Social;
                tp.Giro = modelo.Giro;
                tp.Direccion = modelo.Direccion;
                tp.ID_Ciudad = modelo.ID_Ciudad;
                tp.ID_Comuna = modelo.ID_Comuna;
                tp.ID_Region = modelo.ID_Region;
                tp.ID_Pais = modelo.ID_Pais;
                tp.Telefono = modelo.Telefono;
                tp.Movil = modelo.Movil;
                tp.Direccion_Correo = modelo.Direccion_Correo;
                tp.Fecha_Ingreso = modelo.Fecha_Ingreso;
                tp.Ult_Actualizacion = modelo.Ult_Actualizacion;
                tp.Monto_Credito = modelo.Monto_Credito;
                tp.Observaciones = modelo.Observaciones;
                tp.Estado = estado;
                //tp.Ciudad = ciudad;
                //tp.Comuna = comuna;
                //tp.Pais = pais;
                //tp.Region = region;

                //Asignación de tablas anexas
                db.ClienteProveedors.Update(tp);
                await db.SaveChangesAsync();
                db.Entry(tp).State = EntityState.Detached;
                //db.Entry(tp.Region).State = EntityState.Detached;
                //db.Entry(tp.Comuna).State = EntityState.Detached;
                //db.Entry(tp.Ciudad).State = EntityState.Detached;
                //db.Entry(tp.Pais).State = EntityState.Detached;
                db.Entry(tp.Estado).State = EntityState.Detached;

                //
                response.IsSuccess = true;
                response.Result = tp;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            //
            return response;
        }
        public async Task<Response<ClienteProveedor>> DeleteAsync(ClienteProveedor modelo)
        {
            var response = new Response<ClienteProveedor>();
            response.IsSuccess = false;
            try
            {
                ClienteProveedor tp = await db.ClienteProveedors.FirstOrDefaultAsync(tp => tp.ID_Cliente_Proveedor == modelo.ID_Cliente_Proveedor);
                Estado estado = await db.Estados.FirstOrDefaultAsync(e => e.ID_Estado == modelo.Estado.ID_Estado);
                modelo.Estado = estado;
                if (tp == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                //
                db.Remove(tp);
                await db.SaveChangesAsync();

                //
                response.IsSuccess = true;
                response.Result = tp;
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

