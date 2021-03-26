using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tievol.Data;
using Tievol.Services;

namespace Tievol
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Conexion a la Base de datos
           // services.AddDbContext<ApplicationDbContext>(options =>
              // options.UseSqlServer(Configuration.GetConnectionString("DBConnection")), ServiceLifetime.Scoped);

            // String connection
            var stringConnection = Configuration.GetConnectionString("DBConnection");

            // Injection DB
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(stringConnection), ServiceLifetime.Scoped);
            

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddTelerikBlazor();

            //Services to add
            services.AddScoped<BodegasServices>();
            services.AddScoped<ComunasServices>();
            services.AddScoped<RegionesServices>();
            services.AddScoped<CiudadesServices>();
            services.AddScoped<FamiliasServices>();
            services.AddScoped<EmpresasServices>();
            services.AddScoped<EstadosServices>();
            services.AddScoped<SucursalesServices>();
            services.AddScoped<PaisesServices>();
            services.AddScoped<PerfilesServices>();
            services.AddScoped<TipoDocumentosServices>();
            services.AddScoped<TipoProductosServices>();
            services.AddScoped<ProductoServices>();
            services.AddScoped<UnidadesServices>();
            services.AddScoped<UbicacionesServices>();
            services.AddScoped<TipoClienteProveedorServices>();
            services.AddScoped<TipoInventarioServices>();
            services.AddScoped<TipoEmpresaServices>();
            services.AddScoped<TipoMaterialServices>();
            services.AddScoped<TipoPagoServices>();
            services.AddScoped<MarcaServices>();
            services.AddScoped<SubfamiliaServices>();
            services.AddScoped<ClienteProveedorServices>();
            services.AddScoped<TipoDescuentoServices>();
            services.AddScoped<TomaInventarioServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
