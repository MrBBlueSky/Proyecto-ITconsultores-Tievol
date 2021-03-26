using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tievol.Data;
using Tievol.Data.Entities;
using Tievol.Data.Models;


namespace Tievol.Services
{
    public class TomaInventarioServices
    {
        private readonly ApplicationDbContext db;

        public TomaInventarioServices(ApplicationDbContext context)
        {
            db = context;
        }
        public async Task<List<Data.Entities.Toma_inventario>> GetToma_inventario()
        {
            return await db.Toma_inventario
                .Include("Estado")
                .Include("Producto")

            .AsNoTracking().ToListAsync();
        }
        public async Task<Data.Entities.Toma_inventario> GetToma_inventario(int IDTomaInventario)
        {
            return await db.Toma_inventario
                .Include("Estado")
                .Include("Producto")

            .AsNoTracking().FirstOrDefaultAsync(ti => ti.ID_TomaInventario == IDTomaInventario);
        }
        public async Task<Response<Data.Entities.Toma_inventario>> CreateAsync(Data.Entities.Toma_inventario modelo)
        {
            var response = new Response<Data.Entities.Toma_inventario>();
            response.IsSuccess = false;
            try
            {
                Estado estado = db.Estados.Find(modelo.Estado.ID_Estado);
                Producto Producto = db.Productos.Find(modelo.Producto.ID_Producto);
                Toma_inventario TInventario = db.Toma_inventario.Find(modelo.ID_TomaInventario);



                modelo.Estado = estado;
                modelo.Producto = Producto;




                if (modelo == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                if (Producto == null && estado == null)
                {
                    response.Message = "Asigne un Estado";
                    return response;
                }

                if (Producto == null)
                {
                    response.Message = "Asigne un Producto";
                    return response;
                }

                if (estado == null)
                {
                    response.Message = "Asigne un Estado";
                    return response;
                }

                if (await db.Toma_inventario.AsNoTracking().AnyAsync(ti => ti.ID_TomaInventario == modelo.ID_TomaInventario))
                {
                    response.Message = "Error el identificador ya existe...";
                    return response;
                }


                db.Add(modelo);
                db.SaveChanges();

                response.IsSuccess = true;
                response.Result = modelo;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
        public Task<Response<Data.Entities.Toma_inventario>> UpdateAsync(Data.Entities.Toma_inventario modelo)
        {
            var response = new Response<Data.Entities.Toma_inventario>();
            response.IsSuccess = false;
            try
            {

                Estado estado = db.Estados.Find(modelo.Estado.ID_Estado);
                Producto Producto = db.Productos.Find(modelo.Producto.ID_Producto);
                Toma_inventario TInventario = db.Toma_inventario.Find(modelo.ID_TomaInventario);


                modelo.Estado = estado;
                modelo.Producto = Producto;


                if (modelo == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return Task.FromResult(response);
                }

                if (Producto == null && estado == null)
                {
                    response.Message = "Debe asignar un estado";
                    return Task.FromResult(response);
                }

                if (Producto == null)
                {
                    response.Message = "Asigne un Producto";
                    return Task.FromResult(response);
                }

                if (estado == null)
                {
                    response.Message = "Debe asignar un estado";
                    return Task.FromResult(response);
                }



                TInventario.N_funcionario = modelo.N_funcionario;
                TInventario.Fecha_Creacion = modelo.Fecha_Creacion;
                TInventario.StockIngresado = modelo.StockIngresado;
                TInventario.StockActual = modelo.StockActual;
                TInventario.StockSolicitado = modelo.StockSolicitado;
                TInventario.Producto = Producto;
                TInventario.Estado = estado;






                //Referenciación a tablas anexas. 
                db.Toma_inventario.Update(TInventario);
                db.SaveChanges();
                db.Entry(TInventario.Estado).State = EntityState.Detached;
                db.Entry(TInventario.Producto).State = EntityState.Detached;

                //
                response.IsSuccess = true;
                response.Result = modelo;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            //
            return Task.FromResult(response);
        }
        public async Task<Response<Data.Entities.Toma_inventario>> DeleteAsync(Data.Entities.Toma_inventario modelo)
        {
            var response = new Response<Data.Entities.Toma_inventario>();
            response.IsSuccess = false;
            try
            {

                Data.Entities.Toma_inventario TInventario = db.Toma_inventario.Find(modelo.ID_TomaInventario);

                if (modelo == null)
                {
                    response.Message = "Debe proveer la información solicitada...";
                    return response;
                }

                //
                db.Remove(modelo);
                db.SaveChanges();

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
