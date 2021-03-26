using Microsoft.EntityFrameworkCore;
using System;
using Tievol.Data.Entities;

namespace Tievol.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Set BD 
        public DbSet<Bodega> Bodegas { get; set; }
        public DbSet<Comuna> Comunas { get; set; }
        public DbSet<Region> Regiones { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<Familia> Familias { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Tipo_documento> Tipo_Documentos { get; set; }
        public DbSet<Tipo_producto> Tipo_Productos { get; set; }
        public DbSet<Tipo_cliente_proveedor> Tipo_Cliente_Proveedor { get; set; }
        public DbSet<Tipo_inventario> Tipo_Inventario { get; set; }
        public DbSet<Tipo_empresa> Tipo_Empresa { get; set; }
        public DbSet<Tipo_material> Tipo_Material { get; set; }
        public DbSet<Tipo_pago> Tipo_Pago { get; set; }

        public DbSet<Toma_inventario> Toma_inventario { get; set; }
        public DbSet<TipoDescuento> Tipo_Descuentos { get; set; }
        public DbSet<ClienteProveedor> ClienteProveedors { get; set; }

        public DbSet<Marca> Marca { get; set; }
        public DbSet<Subfamilia> Subfamilia { get; set; }
        public DbSet<Unidad> Unidades { get; set; }
        public DbSet<Producto> Productos { get; set; }

        public DbSet<Ubicacion> Ubicaciones { get; set; }
        public DbSet<Pais> Paises { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("dbo");
            #region Estados
            modelBuilder.Entity<Estado>().HasData(new { ID_Estado = 1, N_Estado = "Activo" });
            modelBuilder.Entity<Estado>().HasData(new { ID_Estado = 2, N_Estado = "Suspendido" });
            #endregion

            #region Regiones
            modelBuilder.Entity<Region>().HasData(new { ID_Region = 1, N_Region = "I - Región de Tarapacá" });
            modelBuilder.Entity<Region>().HasData(new { ID_Region = 2, N_Region = "II - Región de Antofagasta" });
            modelBuilder.Entity<Region>().HasData(new { ID_Region = 3, N_Region = "III - Región de Atacama" });
            modelBuilder.Entity<Region>().HasData(new { ID_Region = 4, N_Region = "IV - Región de Coquimbo" });
            modelBuilder.Entity<Region>().HasData(new { ID_Region = 5, N_Region = "V - Región de Valparaíso" });
            modelBuilder.Entity<Region>().HasData(new { ID_Region = 6, N_Region = "VI - Región de O’higgins" });
            modelBuilder.Entity<Region>().HasData(new { ID_Region = 7, N_Region = "VII - Región del Maule" });
            modelBuilder.Entity<Region>().HasData(new { ID_Region = 8, N_Region = "VIII - Región del Bío Bío" });
            modelBuilder.Entity<Region>().HasData(new { ID_Region = 9, N_Region = "IX - Región de la Araucanía" });
            modelBuilder.Entity<Region>().HasData(new { ID_Region = 10, N_Region = "X - Región de Los Lagos" });
            modelBuilder.Entity<Region>().HasData(new { ID_Region = 11, N_Region = "XI - Región de Aysén" });
            modelBuilder.Entity<Region>().HasData(new { ID_Region = 12, N_Region = "XII - Región de Magallanes Y Antártica Chilena" });
            modelBuilder.Entity<Region>().HasData(new { ID_Region = 13, N_Region = "XIII - Región Metropolitana" });
            modelBuilder.Entity<Region>().HasData(new { ID_Region = 14, N_Region = "XIV - Región de Los Rios" });
            modelBuilder.Entity<Region>().HasData(new { ID_Region = 15, N_Region = "XV - Región de Arica y Parinacota" });
            #endregion

            #region Ciudades
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 1, N_Ciudad = "Alto Hospicio", ID_Region = 1 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 2, N_Ciudad = "Iquique", ID_Region = 1 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 3, N_Ciudad = "Pozo Almonte", ID_Region = 1 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 4, N_Ciudad = "Antofagasta", ID_Region = 2 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 5, N_Ciudad = "Calama", ID_Region = 2 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 6, N_Ciudad = "Mejillones", ID_Region = 2 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 7, N_Ciudad = "San Pedro", ID_Region = 2 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 8, N_Ciudad = "Taltal", ID_Region = 2 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 9, N_Ciudad = "Tocopilla", ID_Region = 2 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 10, N_Ciudad = "Caldera", ID_Region = 3 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 11, N_Ciudad = "Chañaral", ID_Region = 3 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 12, N_Ciudad = "Copiapó", ID_Region = 3 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 13, N_Ciudad = "Diego de Almagro", ID_Region = 3 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 14, N_Ciudad = "El Salvador", ID_Region = 3 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 15, N_Ciudad = "Huasco", ID_Region = 3 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 16, N_Ciudad = "Tierra Amarilla", ID_Region = 3 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 17, N_Ciudad = "Vallenar", ID_Region = 3 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 18, N_Ciudad = "Andacollo", ID_Region = 4 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 19, N_Ciudad = "Combarbalá", ID_Region = 4 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 20, N_Ciudad = "El Palqui", ID_Region = 4 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 21, N_Ciudad = "Illapel", ID_Region = 4 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 22, N_Ciudad = "La Serena", ID_Region = 4 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 23, N_Ciudad = "Los Vilos", ID_Region = 4 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 24, N_Ciudad = "Monte Patria", ID_Region = 4 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 25, N_Ciudad = "Ovalle", ID_Region = 4 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 26, N_Ciudad = "Punitaqui", ID_Region = 4 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 27, N_Ciudad = "Salamanca", ID_Region = 4 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 28, N_Ciudad = "Tongoy", ID_Region = 4 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 29, N_Ciudad = "Vicuña", ID_Region = 4 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 30, N_Ciudad = "Angol", ID_Region = 9 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 31, N_Ciudad = "Cajón", ID_Region = 9 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 32, N_Ciudad = "Carahue", ID_Region = 9 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 33, N_Ciudad = "Collipulli", ID_Region = 9 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 34, N_Ciudad = "Cunco", ID_Region = 9 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 35, N_Ciudad = "Freire", ID_Region = 9 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 36, N_Ciudad = "Gorbea", ID_Region = 9 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 37, N_Ciudad = "Labranza", ID_Region = 9 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 38, N_Ciudad = "Lautaro", ID_Region = 9 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 39, N_Ciudad = "Loncoche", ID_Region = 9 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 40, N_Ciudad = "Nueva Imperial", ID_Region = 9 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 41, N_Ciudad = "Padre Las Casas", ID_Region = 9 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 42, N_Ciudad = "Pitrufquén", ID_Region = 9 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 43, N_Ciudad = "Pucón", ID_Region = 9 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 44, N_Ciudad = "Purén", ID_Region = 9 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 45, N_Ciudad = "Renaico", ID_Region = 9 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 46, N_Ciudad = "Temuco", ID_Region = 9 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 47, N_Ciudad = "Traiguén", ID_Region = 9 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 48, N_Ciudad = "Victoria", ID_Region = 9 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 49, N_Ciudad = "Vilcún", ID_Region = 9 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 50, N_Ciudad = "Villarrica", ID_Region = 9 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 51, N_Ciudad = "Algarrobo", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 52, N_Ciudad = "Cabildo", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 53, N_Ciudad = "Calle Larga", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 54, N_Ciudad = "Cartagena", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 55, N_Ciudad = "Casablanca", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 56, N_Ciudad = "Catemu", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 57, N_Ciudad = "Concón", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 58, N_Ciudad = "El Melón", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 59, N_Ciudad = "El Quisco", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 60, N_Ciudad = "El Tabo", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 61, N_Ciudad = "Hanga Roa", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 62, N_Ciudad = "Hijuelas", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 63, N_Ciudad = "La Calera", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 64, N_Ciudad = "La Cruz", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 65, N_Ciudad = "La Ligua", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 66, N_Ciudad = "Las Cruces", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 67, N_Ciudad = "Las Ventanas", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 68, N_Ciudad = "Limache", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 69, N_Ciudad = "Llaillay", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 70, N_Ciudad = "Los Andes", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 71, N_Ciudad = "Nogales", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 72, N_Ciudad = "Olmué", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 73, N_Ciudad = "Placilla de Peñuelas", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 74, N_Ciudad = "Puchuncaví", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 75, N_Ciudad = "Putaendo", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 76, N_Ciudad = "Quillota", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 77, N_Ciudad = "Quilpué", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 78, N_Ciudad = "Quintero", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 79, N_Ciudad = "Rinconada", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 80, N_Ciudad = "San Antonio", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 81, N_Ciudad = "San Esteban", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 82, N_Ciudad = "San Felipe", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 83, N_Ciudad = "Santa María", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 84, N_Ciudad = "Santo Domingo", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 85, N_Ciudad = "Villa Alemana", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 86, N_Ciudad = "Viña del Mar", ID_Region = 5 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 87, N_Ciudad = "Chépica", ID_Region = 6 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 88, N_Ciudad = "Chimbarongo", ID_Region = 6 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 89, N_Ciudad = "Codegua", ID_Region = 6 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 90, N_Ciudad = "Coltauco", ID_Region = 6 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 91, N_Ciudad = "Doñihue", ID_Region = 6 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 92, N_Ciudad = "Graneros", ID_Region = 6 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 93, N_Ciudad = "Gultro", ID_Region = 6 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 94, N_Ciudad = "La Punta", ID_Region = 6 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 95, N_Ciudad = "Las Cabras", ID_Region = 6 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 96, N_Ciudad = "Lo Miranda", ID_Region = 6 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 97, N_Ciudad = "Machalí", ID_Region = 6 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 98, N_Ciudad = "Nancagua", ID_Region = 6 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 99, N_Ciudad = "Peralillo", ID_Region = 6 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 100, N_Ciudad = "Peumo", ID_Region = 6 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 101, N_Ciudad = "Pichidegua", ID_Region = 6 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 102, N_Ciudad = "Pichilemu", ID_Region = 6 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 103, N_Ciudad = "Quinta de Tilcoco", ID_Region = 6 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 104, N_Ciudad = "Rancagua", ID_Region = 6 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 105, N_Ciudad = "Rengo", ID_Region = 6 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 106, N_Ciudad = "Requínoa", ID_Region = 6 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 107, N_Ciudad = "San Fernando", ID_Region = 6 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 108, N_Ciudad = "San Francisco de Mostazal", ID_Region = 6 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 109, N_Ciudad = "San Vicente de Tagua Tagua", ID_Region = 6 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 110, N_Ciudad = "Santa Cruz", ID_Region = 6 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 111, N_Ciudad = "Cauquenes", ID_Region = 7 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 112, N_Ciudad = "Colbún", ID_Region = 7 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 113, N_Ciudad = "Constitución", ID_Region = 7 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 114, N_Ciudad = "Culenar", ID_Region = 7 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 115, N_Ciudad = "Curicó", ID_Region = 7 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 116, N_Ciudad = "Hualañé", ID_Region = 7 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 117, N_Ciudad = "Linares", ID_Region = 7 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 118, N_Ciudad = "Longaví", ID_Region = 7 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 119, N_Ciudad = "Molina", ID_Region = 7 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 120, N_Ciudad = "Parral", ID_Region = 7 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 121, N_Ciudad = "Rauco", ID_Region = 7 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 122, N_Ciudad = "Retiro", ID_Region = 7 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 123, N_Ciudad = "Romeral", ID_Region = 7 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 124, N_Ciudad = "San Clemente", ID_Region = 7 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 125, N_Ciudad = "San Clemente", ID_Region = 7 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 126, N_Ciudad = "San Javier", ID_Region = 7 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 127, N_Ciudad = "Talca", ID_Region = 7 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 128, N_Ciudad = "Teno", ID_Region = 7 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 129, N_Ciudad = "Villa Alegre", ID_Region = 7 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 130, N_Ciudad = "Arauco", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 131, N_Ciudad = "Cabrero", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 132, N_Ciudad = "Cañete", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 133, N_Ciudad = "Chiguayante", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 134, N_Ciudad = "Concepción", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 135, N_Ciudad = "Coronel", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 136, N_Ciudad = "Curanilahue", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 137, N_Ciudad = "Hualpén", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 138, N_Ciudad = "Hualqui", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 139, N_Ciudad = "Huépil", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 140, N_Ciudad = "La Laja", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 141, N_Ciudad = "Laraquete", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 142, N_Ciudad = "Lebu", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 143, N_Ciudad = "Los Álamos", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 144, N_Ciudad = "Los Ángeles", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 145, N_Ciudad = "Lota", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 146, N_Ciudad = "Monte Águila", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 147, N_Ciudad = "Mulchén", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 148, N_Ciudad = "Nacimiento", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 149, N_Ciudad = "Penco", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 150, N_Ciudad = "San Pedro de la Paz", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 151, N_Ciudad = "Santa Bárbara", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 152, N_Ciudad = "Santa Juana", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 153, N_Ciudad = "Talcahuano", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 154, N_Ciudad = "Tomé", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 155, N_Ciudad = "Yumbel", ID_Region = 8 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 156, N_Ciudad = "Alerce", ID_Region = 10 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 157, N_Ciudad = "Ancud", ID_Region = 10 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 158, N_Ciudad = "Calbuco", ID_Region = 10 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 159, N_Ciudad = "Castro", ID_Region = 10 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 160, N_Ciudad = "Chaitén", ID_Region = 10 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 161, N_Ciudad = "Chonchi", ID_Region = 10 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 162, N_Ciudad = "Dalcahue", ID_Region = 10 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 163, N_Ciudad = "Fresia", ID_Region = 10 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 164, N_Ciudad = "Frutillar", ID_Region = 10 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 165, N_Ciudad = "Llanquihue", ID_Region = 10 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 166, N_Ciudad = "Los Muermos", ID_Region = 10 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 167, N_Ciudad = "Osorno", ID_Region = 10 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 168, N_Ciudad = "Puerto Montt", ID_Region = 10 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 169, N_Ciudad = "Puerto Varas", ID_Region = 10 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 170, N_Ciudad = "Purranque", ID_Region = 10 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 171, N_Ciudad = "Quellón", ID_Region = 10 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 172, N_Ciudad = "Río Negro", ID_Region = 10 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 173, N_Ciudad = "Chile Chico", ID_Region = 11 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 174, N_Ciudad = "Cochrane", ID_Region = 11 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 175, N_Ciudad = "Coyhaique", ID_Region = 11 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 176, N_Ciudad = "Puerto Aysén", ID_Region = 11 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 177, N_Ciudad = "Porvenir", ID_Region = 12 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 178, N_Ciudad = "Puerto Natales", ID_Region = 12 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 179, N_Ciudad = "Puerto Williams", ID_Region = 12 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 180, N_Ciudad = "Punta Arenas", ID_Region = 12 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 181, N_Ciudad = "Alto Jahuel", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 182, N_Ciudad = "Batuco", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 183, N_Ciudad = "Bollenar", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 184, N_Ciudad = "Buin", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 185, N_Ciudad = "Bulnes", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 186, N_Ciudad = "Calera de Tango", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 187, N_Ciudad = "Cerrillos", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 188, N_Ciudad = "Cerro Navia", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 189, N_Ciudad = "Chamisero", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 190, N_Ciudad = "Chicureo", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 191, N_Ciudad = "Chillán", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 192, N_Ciudad = "Chillán Viejo", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 193, N_Ciudad = "Ciudad del Valle", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 194, N_Ciudad = "Coelemu", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 195, N_Ciudad = "Coihueco", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 196, N_Ciudad = "Colina", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 197, N_Ciudad = "Conchalí", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 198, N_Ciudad = "Curacaví", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 199, N_Ciudad = "El Bosque", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 200, N_Ciudad = "El Monte", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 201, N_Ciudad = "El Principal", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 202, N_Ciudad = "Estación Central", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 203, N_Ciudad = "Hospital", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 204, N_Ciudad = "Huechuraba", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 205, N_Ciudad = "Independencia", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 206, N_Ciudad = "Isla de Maipo", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 207, N_Ciudad = "La Cisterna", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 208, N_Ciudad = "La Florida", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 209, N_Ciudad = "La Granja", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 210, N_Ciudad = "La Islita", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 211, N_Ciudad = "La Pintana", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 212, N_Ciudad = "La Reina", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 213, N_Ciudad = "Lampa", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 214, N_Ciudad = "Las Condes", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 215, N_Ciudad = "Lo Barnechea", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 216, N_Ciudad = "Lo Espejo", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 217, N_Ciudad = "Lo Prado", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 218, N_Ciudad = "Macul", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 219, N_Ciudad = "Maipú", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 220, N_Ciudad = "Melipilla", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 221, N_Ciudad = "Ñuñoa", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 222, N_Ciudad = "Paine", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 223, N_Ciudad = "Pedro Aguirre Cerda", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 224, N_Ciudad = "Peñaflor", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 225, N_Ciudad = "Peñalolén", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 226, N_Ciudad = "Providencia", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 227, N_Ciudad = "Pudahuel", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 228, N_Ciudad = "Puente Alto", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 229, N_Ciudad = "Quilicura", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 230, N_Ciudad = "Quillón", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 231, N_Ciudad = "Quinta Normal", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 232, N_Ciudad = "Quirihue", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 233, N_Ciudad = "Recoleta", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 234, N_Ciudad = "Renca", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 235, N_Ciudad = "San Bernardo", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 236, N_Ciudad = "San Carlos", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 237, N_Ciudad = "San Joaquín", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 238, N_Ciudad = "San José de Maipo", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 239, N_Ciudad = "San Miguel", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 240, N_Ciudad = "San Ramón", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 241, N_Ciudad = "Santiago", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 242, N_Ciudad = "Talagante", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 243, N_Ciudad = "Tiltil", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 244, N_Ciudad = "Valle Grande", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 245, N_Ciudad = "Vitacura", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 246, N_Ciudad = "Yungay", ID_Region = 13 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 247, N_Ciudad = "Futrono", ID_Region = 14 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 248, N_Ciudad = "La Unión", ID_Region = 14 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 249, N_Ciudad = "Lanco", ID_Region = 14 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 250, N_Ciudad = "Paillaco", ID_Region = 14 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 251, N_Ciudad = "Panguipulli", ID_Region = 14 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 252, N_Ciudad = "Río Bueno", ID_Region = 14 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 253, N_Ciudad = "San José de la Mariquina", ID_Region = 14 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 254, N_Ciudad = "Valdivia", ID_Region = 14 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 255, N_Ciudad = "Arica", ID_Region = 15 });
            modelBuilder.Entity<Ciudad>().HasData(new { ID_Ciudad = 256, N_Ciudad = "Putre", ID_Region = 15 });
            #endregion

            #region Comunas
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 1101, N_Comuna = "ARICA", ID_Region = 15 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 1106, N_Comuna = "CAMARONES", ID_Region = 15 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 1301, N_Comuna = "PUTRE", ID_Region = 15 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 1302, N_Comuna = "GENERAL LAGOS", ID_Region = 15 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 1201, N_Comuna = "IQUIQUE", ID_Region = 1 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 1203, N_Comuna = "PICA", ID_Region = 1 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 1204, N_Comuna = "POZO ALMONTE", ID_Region = 1 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 1206, N_Comuna = "HUARA", ID_Region = 1 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 1208, N_Comuna = "CAMINA", ID_Region = 1 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 1210, N_Comuna = "COLCHANE", ID_Region = 1 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 1211, N_Comuna = "ALTO HOSPICIO", ID_Region = 1 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 2101, N_Comuna = "TOCOPILLA", ID_Region = 2 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 2103, N_Comuna = "MARIA ELENA", ID_Region = 2 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 2201, N_Comuna = "ANTOFAGASTA", ID_Region = 2 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 2202, N_Comuna = "TALTAL", ID_Region = 2 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 2203, N_Comuna = "MEJILLONES", ID_Region = 2 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 2206, N_Comuna = "SIERRA GORDA", ID_Region = 2 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 2301, N_Comuna = "CALAMA", ID_Region = 2 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 2302, N_Comuna = "OLLAGUE", ID_Region = 2 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 2303, N_Comuna = "SAN PEDRO DE ATACAMA", ID_Region = 2 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 3101, N_Comuna = "CHANARAL", ID_Region = 3 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 3102, N_Comuna = "DIEGO DE ALMAGRO", ID_Region = 3 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 3201, N_Comuna = "COPIAPO", ID_Region = 3 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 3202, N_Comuna = "CALDERA", ID_Region = 3 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 3203, N_Comuna = "TIERRA AMARILLA", ID_Region = 3 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 3301, N_Comuna = "VALLENAR", ID_Region = 3 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 3302, N_Comuna = "FREIRINA", ID_Region = 3 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 3303, N_Comuna = "HUASCO", ID_Region = 3 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 3304, N_Comuna = "ALTO DEL CARMEN", ID_Region = 3 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 4101, N_Comuna = "LA SERENA", ID_Region = 4 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 4102, N_Comuna = "LA HIGUERA", ID_Region = 4 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 4103, N_Comuna = "COQUIMBO", ID_Region = 4 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 4104, N_Comuna = "ANDACOLLO", ID_Region = 4 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 4105, N_Comuna = "VICUNA", ID_Region = 4 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 4106, N_Comuna = "PAIHUANO", ID_Region = 4 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 4201, N_Comuna = "OVALLE", ID_Region = 4 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 4203, N_Comuna = "MONTE PATRIA", ID_Region = 4 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 4204, N_Comuna = "PUNITAQUI", ID_Region = 4 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 4205, N_Comuna = "COMBARBALA", ID_Region = 4 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 4206, N_Comuna = "RIO HURTADO", ID_Region = 4 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 4301, N_Comuna = "ILLAPEL", ID_Region = 4 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 4302, N_Comuna = "SALAMANCA", ID_Region = 4 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 4303, N_Comuna = "LOS VILOS", ID_Region = 4 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 4304, N_Comuna = "CANELA", ID_Region = 4 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5101, N_Comuna = "ISLA DE PASCUA", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5201, N_Comuna = "LA LIGUA", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5202, N_Comuna = "PETORCA", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5203, N_Comuna = "CABILDO", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5204, N_Comuna = "ZAPALLAR", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5205, N_Comuna = "PAPUDO", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5301, N_Comuna = "VALPARAISO", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5302, N_Comuna = "VINA DEL MAR", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5303, N_Comuna = "VILLA ALEMANA", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5304, N_Comuna = "QUILPUE", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5305, N_Comuna = "CASABLANCA", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5306, N_Comuna = "QUINTERO", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5307, N_Comuna = "PUCHUNCAVI", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5308, N_Comuna = "JUAN FERNANDEZ", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5309, N_Comuna = "CONCON", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5401, N_Comuna = "SAN ANTONIO", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5402, N_Comuna = "SANTO DOMINGO", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5403, N_Comuna = "CARTAGENA", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5404, N_Comuna = "EL TABO", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5405, N_Comuna = "EL QUISCO", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5406, N_Comuna = "ALGARROBO", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5501, N_Comuna = "QUILLOTA", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5502, N_Comuna = "NOGALES", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5503, N_Comuna = "HIJUELAS", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5504, N_Comuna = "LA CALERA", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5505, N_Comuna = "LA CRUZ", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5506, N_Comuna = "LIMACHE", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5507, N_Comuna = "OLMUE", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5601, N_Comuna = "SAN FELIPE", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5602, N_Comuna = "PANQUEHUE", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5603, N_Comuna = "CATEMU", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5604, N_Comuna = "PUTAENDO", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5605, N_Comuna = "SANTA MARIA", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5606, N_Comuna = "LLAY-LLAY", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5701, N_Comuna = "LOS ANDES", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5702, N_Comuna = "CALLE LARGA", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5703, N_Comuna = "SAN ESTEBAN", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 5704, N_Comuna = "RINCONADA", ID_Region = 5 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6101, N_Comuna = "RANCAGUA", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6102, N_Comuna = "MACHALI", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6103, N_Comuna = "GRANEROS", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6104, N_Comuna = "SAN FRANCISCO DE MOSTAZAL", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6105, N_Comuna = "DONIHUE", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6106, N_Comuna = "COLTAUCO", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6107, N_Comuna = "CODEGUA", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6108, N_Comuna = "PEUMO", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6109, N_Comuna = "LAS CABRAS", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6110, N_Comuna = "SAN VICENTE", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6111, N_Comuna = "PICHIDEGUA", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6112, N_Comuna = "RENGO", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6113, N_Comuna = "REQUINOA", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6114, N_Comuna = "OLIVAR", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6115, N_Comuna = "MALLOA", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6116, N_Comuna = "COINCO", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6117, N_Comuna = "QUINTA DE TILCOCO", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6201, N_Comuna = "SAN FERNANDO", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6202, N_Comuna = "CHIMBARONGO", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6203, N_Comuna = "NANCAGUA", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6204, N_Comuna = "PLACILLA", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6205, N_Comuna = "SANTA CRUZ", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6206, N_Comuna = "LOLOL", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6207, N_Comuna = "PALMILLA", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6208, N_Comuna = "PERALILLO", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6209, N_Comuna = "CHEPICA", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6214, N_Comuna = "PUMANQUE", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6301, N_Comuna = "PICHILEMU", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6302, N_Comuna = "NAVIDAD", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6303, N_Comuna = "LITUECHE", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6304, N_Comuna = "LA ESTRELLA", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6305, N_Comuna = "MARCHIGUE", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 6306, N_Comuna = "PAREDONES", ID_Region = 6 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7101, N_Comuna = "CURICO", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7102, N_Comuna = "TENO", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7103, N_Comuna = "ROMERAL", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7104, N_Comuna = "RAUCO", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7105, N_Comuna = "LICANTEN", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7106, N_Comuna = "VICHUQUEN", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7107, N_Comuna = "HUALANE", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7108, N_Comuna = "MOLINA", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7109, N_Comuna = "SAGRADA FAMILIA", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7201, N_Comuna = "TALCA", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7202, N_Comuna = "SAN CLEMENTE", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7203, N_Comuna = "PELARCO", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7204, N_Comuna = "RIO CLARO", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7205, N_Comuna = "PENCAHUE", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7206, N_Comuna = "MAULE", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7207, N_Comuna = "CUREPTO", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7208, N_Comuna = "CONSTITUCION", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7209, N_Comuna = "EMPEDRADO", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7210, N_Comuna = "SAN RAFAEL", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7301, N_Comuna = "LINARES", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7302, N_Comuna = "YERBAS BUENAS", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7303, N_Comuna = "COLBUN", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7304, N_Comuna = "LONGAVI", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7305, N_Comuna = "PARRAL", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7306, N_Comuna = "RETIRO", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7309, N_Comuna = "VILLA ALEGRE", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7310, N_Comuna = "SAN JAVIER", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7401, N_Comuna = "CAUQUENES", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7402, N_Comuna = "PELLUHUE", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 7403, N_Comuna = "CHANCO", ID_Region = 7 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8101, N_Comuna = "CHILLAN", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8102, N_Comuna = "PINTO", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8103, N_Comuna = "COIHUECO", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8104, N_Comuna = "QUIRIHUE", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8105, N_Comuna = "NINHUE", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8106, N_Comuna = "PORTEZUELO", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8107, N_Comuna = "COBQUECURA", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8108, N_Comuna = "TREHUACO", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8109, N_Comuna = "SAN CARLOS", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8110, N_Comuna = "NIQUEN", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8111, N_Comuna = "SAN FABIAN", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8112, N_Comuna = "SAN NICOLAS", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8113, N_Comuna = "BULNES", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8114, N_Comuna = "SAN IGNACIO", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8115, N_Comuna = "QUILLON", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8116, N_Comuna = "YUNGAY", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8117, N_Comuna = "PEMUCO", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8118, N_Comuna = "EL CARMEN", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8119, N_Comuna = "RANQUIL", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8120, N_Comuna = "COELEMU", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8121, N_Comuna = "CHILLAN VIEJO", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8201, N_Comuna = "CONCEPCION", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8202, N_Comuna = "PENCO", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8203, N_Comuna = "HUALQUI", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8204, N_Comuna = "FLORIDA", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8205, N_Comuna = "TOME", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8206, N_Comuna = "TALCAHUANO", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8207, N_Comuna = "CORONEL", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8208, N_Comuna = "LOTA", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8209, N_Comuna = "SANTA JUANA", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8210, N_Comuna = "SAN PEDRO DE LA PAZ", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8211, N_Comuna = "CHIGUAYANTE", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8212, N_Comuna = "HUALPEN", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8301, N_Comuna = "ARAUCO", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8302, N_Comuna = "CURANILAHUE", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8303, N_Comuna = "LEBU", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8304, N_Comuna = "LOS ALAMOS", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8305, N_Comuna = "CANETE", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8306, N_Comuna = "CONTULMO", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8307, N_Comuna = "TIRUA", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8401, N_Comuna = "LOS ANGELES", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8402, N_Comuna = "SANTA BARBARA", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8403, N_Comuna = "LAJA", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8404, N_Comuna = "QUILLECO", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8405, N_Comuna = "NACIMIENTO", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8406, N_Comuna = "NEGRETE", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8407, N_Comuna = "MULCHEN", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8408, N_Comuna = "QUILACO", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8409, N_Comuna = "YUMBEL", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8410, N_Comuna = "CABRERO", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8411, N_Comuna = "SAN ROSENDO", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8412, N_Comuna = "TUCAPEL", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8413, N_Comuna = "ANTUCO", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 8414, N_Comuna = "ALTO BIOBIO", ID_Region = 8 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9101, N_Comuna = "ANGOL", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9102, N_Comuna = "PUREN", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9103, N_Comuna = "LOS SAUCES", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9104, N_Comuna = "RENAICO", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9105, N_Comuna = "COLLIPULLI", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9106, N_Comuna = "ERCILLA", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9107, N_Comuna = "TRAIGUEN", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9108, N_Comuna = "LUMACO", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9109, N_Comuna = "VICTORIA", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9110, N_Comuna = "CURACAUTIN", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9111, N_Comuna = "LONQUIMAY", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9201, N_Comuna = "TEMUCO", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9202, N_Comuna = "VILCUN", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9203, N_Comuna = "FREIRE", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9204, N_Comuna = "CUNCO", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9205, N_Comuna = "LAUTARO", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9206, N_Comuna = "PERQUENCO", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9207, N_Comuna = "GALVARINO", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9208, N_Comuna = "NUEVA IMPERIAL", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9209, N_Comuna = "CARAHUE", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9210, N_Comuna = "SAAVEDRA", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9211, N_Comuna = "PITRUFQUEN", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9212, N_Comuna = "GORBEA", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9213, N_Comuna = "TOLTEN", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9214, N_Comuna = "LONCOCHE", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9215, N_Comuna = "VILLARRICA", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9216, N_Comuna = "PUCON", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9217, N_Comuna = "MELIPEUCO", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9218, N_Comuna = "CURARREHUE", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9219, N_Comuna = "TEODORO SCHMIDT", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9220, N_Comuna = "PADRE LAS CASAS", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 9221, N_Comuna = "CHOLCHOL", ID_Region = 9 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10101, N_Comuna = "VALDIVIA", ID_Region = 14 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10102, N_Comuna = "MARIQUINA", ID_Region = 14 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10103, N_Comuna = "LANCO", ID_Region = 14 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10104, N_Comuna = "LOS LAGOS", ID_Region = 14 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10105, N_Comuna = "FUTRONO", ID_Region = 14 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10106, N_Comuna = "CORRAL", ID_Region = 14 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10107, N_Comuna = "MAFIL", ID_Region = 14 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10108, N_Comuna = "PANGUIPULLI", ID_Region = 14 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10109, N_Comuna = "LA UNION", ID_Region = 14 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10110, N_Comuna = "PAILLACO", ID_Region = 14 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10111, N_Comuna = "RIO BUENO", ID_Region = 14 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10112, N_Comuna = "LAGO RANCO", ID_Region = 14 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10201, N_Comuna = "OSORNO", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10202, N_Comuna = "SAN PABLO", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10203, N_Comuna = "PUERTO OCTAY", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10204, N_Comuna = "PUYEHUE", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10205, N_Comuna = "RIO NEGRO", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10206, N_Comuna = "PURRANQUE", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10207, N_Comuna = "SAN JUAN DE LA COSTA", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10301, N_Comuna = "PUERTO MONTT", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10302, N_Comuna = "COCHAMO", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10303, N_Comuna = "PUERTO VARAS", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10304, N_Comuna = "FRESIA", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10305, N_Comuna = "FRUTILLAR", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10306, N_Comuna = "LLANQUIHUE", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10307, N_Comuna = "MAULLIN", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10308, N_Comuna = "LOS MUERMOS", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10309, N_Comuna = "CALBUCO", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10401, N_Comuna = "CASTRO", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10402, N_Comuna = "CHONCHI", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10403, N_Comuna = "QUEILEN", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10404, N_Comuna = "QUELLON", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10405, N_Comuna = "PUQUELDON", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10406, N_Comuna = "ANCUD", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10407, N_Comuna = "QUEMCHI", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10408, N_Comuna = "DALCAHUE", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10410, N_Comuna = "CURACO DE VELEZ", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10415, N_Comuna = "QUINCHAO", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10501, N_Comuna = "CHAITEN", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10502, N_Comuna = "HUALAIHUE", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10503, N_Comuna = "FUTALEUFU", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 10504, N_Comuna = "PALENA", ID_Region = 10 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 11101, N_Comuna = "AYSEN", ID_Region = 11 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 11102, N_Comuna = "CISNES", ID_Region = 11 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 11104, N_Comuna = "GUAITECAS", ID_Region = 11 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 11201, N_Comuna = "CHILE CHICO", ID_Region = 11 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 11203, N_Comuna = "RIO IBANEZ", ID_Region = 11 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 11301, N_Comuna = "COCHRANE", ID_Region = 11 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 11302, N_Comuna = "OHIGGINS", ID_Region = 11 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 11303, N_Comuna = "TORTEL", ID_Region = 11 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 11401, N_Comuna = "COYHAIQUE", ID_Region = 11 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 11402, N_Comuna = "LAGO VERDE", ID_Region = 11 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 12101, N_Comuna = "NATALES", ID_Region = 12 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 12103, N_Comuna = "TORRES DEL PAINE", ID_Region = 12 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 12202, N_Comuna = "RIO VERDE", ID_Region = 12 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 12204, N_Comuna = "SAN GREGORIO", ID_Region = 12 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 12205, N_Comuna = "PUNTA ARENAS", ID_Region = 12 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 12206, N_Comuna = "LAGUNA BLANCA", ID_Region = 12 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 12301, N_Comuna = "PORVENIR", ID_Region = 12 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 12302, N_Comuna = "PRIMAVERA", ID_Region = 12 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 12304, N_Comuna = "TIMAUKEL", ID_Region = 12 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 12401, N_Comuna = "CABO DE HORNOS", ID_Region = 12 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 13101, N_Comuna = "SANTIAGO", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 13134, N_Comuna = "SANTIAGO OESTE", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 13135, N_Comuna = "SANTIAGO SUR", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 13159, N_Comuna = "RECOLETA", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 13167, N_Comuna = "INDEPENDENCIA", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 14107, N_Comuna = "QUINTA NORMAL", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 14109, N_Comuna = "MAIPU", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 14111, N_Comuna = "PUDAHUEL", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 14113, N_Comuna = "RENCA", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 14114, N_Comuna = "QUILICURA", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 14127, N_Comuna = "CONCHALI", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 14155, N_Comuna = "LO PRADO", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 14156, N_Comuna = "CERRO NAVIA", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 14157, N_Comuna = "ESTACION CENTRAL", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 14158, N_Comuna = "HUECHURABA", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 14166, N_Comuna = "CERRILLOS", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 14201, N_Comuna = "COLINA", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 14202, N_Comuna = "LAMPA", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 14203, N_Comuna = "TIL-TIL", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 14501, N_Comuna = "TALAGANTE", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 14502, N_Comuna = "ISLA DE MAIPO", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 14503, N_Comuna = "EL MONTE", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 14504, N_Comuna = "PENAFLOR", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 14505, N_Comuna = "PADRE HURTADO", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 14601, N_Comuna = "MELIPILLA", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 14602, N_Comuna = "MARIA PINTO", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 14603, N_Comuna = "CURACAVI", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 14604, N_Comuna = "SAN PEDRO", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 14605, N_Comuna = "ALHUE", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 15103, N_Comuna = "PROVIDENCIA", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 15105, N_Comuna = "NUNOA", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 15108, N_Comuna = "LAS CONDES", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 15128, N_Comuna = "LA FLORIDA", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 15132, N_Comuna = "LA REINA", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 15151, N_Comuna = "MACUL", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 15152, N_Comuna = "PENALOLEN", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 15160, N_Comuna = "VITACURA", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 15161, N_Comuna = "LO BARNECHEA", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 16106, N_Comuna = "SAN MIGUEL", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 16110, N_Comuna = "LA CISTERNA", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 16131, N_Comuna = "LA GRANJA", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 16153, N_Comuna = "SAN RAMON", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 16154, N_Comuna = "LA PINTANA", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 16162, N_Comuna = "PEDRO AGUIRRE CERDA", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 16163, N_Comuna = "SAN JOAQUIN", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 16164, N_Comuna = "LO ESPEJO", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 16165, N_Comuna = "EL BOSQUE", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 16301, N_Comuna = "PUENTE ALTO", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 16302, N_Comuna = "PIRQUE", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 16303, N_Comuna = "SAN JOSE DE MAIPO", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 16401, N_Comuna = "SAN BERNARDO", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 16402, N_Comuna = "CALERA DE TANGO", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 16403, N_Comuna = "BUIN", ID_Region = 13 });
            modelBuilder.Entity<Comuna>().HasData(new { ID_Comuna = 16404, N_Comuna = "PAINE", ID_Region = 13 });
            #endregion

            #region Paises
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 1, N_Pais = "Ascension, Islas", Referencia = "AC" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 2, N_Pais = "Andorra", Referencia = "AD" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 3, N_Pais = "Emiratos Árabes Unidos", Referencia = "AE" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 4, N_Pais = "Afganistán", Referencia = "AF" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 5, N_Pais = "Antigua y Barbuda", Referencia = "AG" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 6, N_Pais = "Anguila (Caribe)", Referencia = "AI" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 7, N_Pais = "Albania", Referencia = "AL" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 8, N_Pais = "Armenia", Referencia = "AM" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 9, N_Pais = "Antillas Holandesas", Referencia = "AN" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 10, N_Pais = "Angola", Referencia = "AO" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 11, N_Pais = "Antártida", Referencia = "AQ" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 12, N_Pais = "Argentina", Referencia = "AR" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 13, N_Pais = "Samoa Americana (American Samoa)", Referencia = "AS" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 14, N_Pais = "Austria", Referencia = "AT" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 15, N_Pais = "Australia", Referencia = "AU" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 16, N_Pais = "Aruba", Referencia = "AW" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 17, N_Pais = "Azerbaiján", Referencia = "AZ" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 18, N_Pais = "Bosnia-Herzegovina", Referencia = "BA" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 19, N_Pais = "Barbados", Referencia = "BB" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 20, N_Pais = "Bangladesh", Referencia = "BD" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 21, N_Pais = "Bélgica", Referencia = "BE" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 22, N_Pais = "Burkina Faso", Referencia = "BF" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 23, N_Pais = "Bulgaria", Referencia = "BG" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 24, N_Pais = "Bahrein", Referencia = "BH" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 25, N_Pais = "Burundi", Referencia = "BI" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 26, N_Pais = "Benín", Referencia = "BJ" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 27, N_Pais = "Bermudas, Islas", Referencia = "BM" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 28, N_Pais = "Brunei Darussalam", Referencia = "BN" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 29, N_Pais = "Bolivia", Referencia = "BO" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 30, N_Pais = "Brasil", Referencia = "BR" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 31, N_Pais = "Bahamas", Referencia = "BS" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 32, N_Pais = "Bután", Referencia = "BT" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 33, N_Pais = "Bouvet, Isla", Referencia = "BV" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 34, N_Pais = "Botswana", Referencia = "BW" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 35, N_Pais = "Bielorrusia (Belarus)", Referencia = "BY" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 36, N_Pais = "Bélice", Referencia = "BZ" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 37, N_Pais = "Canadá", Referencia = "CA" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 38, N_Pais = "Cocos, Islas", Referencia = "CC" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 39, N_Pais = "República Centroafricana", Referencia = "CF" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 40, N_Pais = "Congo", Referencia = "CG" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 41, N_Pais = "Suiza", Referencia = "CH" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 42, N_Pais = "Costa de Marfil (Côte D’Ivoire)", Referencia = "CI" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 43, N_Pais = "Cook, Islas", Referencia = "CK" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 44, N_Pais = "Chile", Referencia = "CL" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 45, N_Pais = "Camerún", Referencia = "CM" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 46, N_Pais = "China", Referencia = "CN" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 47, N_Pais = "Colombia", Referencia = "CO" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 48, N_Pais = "Costa Rica", Referencia = "CR" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 49, N_Pais = "Antigua Checoslovaquia", Referencia = "CS" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 50, N_Pais = "Cuba", Referencia = "CU" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 51, N_Pais = "Cabo Verde", Referencia = "CV" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 52, N_Pais = "Navidad, Isla (Kiribati)", Referencia = "CX" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 53, N_Pais = "Chipre (Cyprus)", Referencia = "CY" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 54, N_Pais = "República Checa (Czech Republic)", Referencia = "CZ" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 55, N_Pais = "Alemania", Referencia = "DE" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 56, N_Pais = "Djibouti", Referencia = "DJ" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 57, N_Pais = "Dinamarca (Denmark)", Referencia = "DK" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 58, N_Pais = "Dominica", Referencia = "DM" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 59, N_Pais = "República Dominicana", Referencia = "DO" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 60, N_Pais = "Argelia (Algeria)", Referencia = "DZ" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 61, N_Pais = "Ecuador", Referencia = "EC" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 62, N_Pais = "Estonia", Referencia = "EE" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 63, N_Pais = "Egipto", Referencia = "EG" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 64, N_Pais = "Sahara Occidental", Referencia = "EH" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 65, N_Pais = "Eritrea", Referencia = "ER" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 66, N_Pais = "España", Referencia = "ES" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 67, N_Pais = "Etiopía", Referencia = "ET" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 68, N_Pais = "Finlandia", Referencia = "FI" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 69, N_Pais = "Fiji", Referencia = "FJ" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 70, N_Pais = "Malvinas, Islas (Falkland)", Referencia = "FK" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 71, N_Pais = "Micronesia", Referencia = "FM" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 72, N_Pais = "Feroe, Islas", Referencia = "FO" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 73, N_Pais = "Francia", Referencia = "FR" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 74, N_Pais = "Francia – Área Metropolitana", Referencia = "FX" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 75, N_Pais = "Gabón", Referencia = "GA" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 76, N_Pais = "Gran Bretaña (Great Britain) (UK)", Referencia = "GB" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 77, N_Pais = "Granada (Grenada) (Caribe)", Referencia = "GD" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 78, N_Pais = "Georgia (ex-URSS)", Referencia = "GE" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 79, N_Pais = "Guayana Francesa", Referencia = "GF" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 80, N_Pais = "Guernsey, Isla (en Channel Islands – Inglaterra)", Referencia = "GG" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 81, N_Pais = "Ghana", Referencia = "GH" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 82, N_Pais = "Gibraltar", Referencia = "GI" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 83, N_Pais = "Groenlandia", Referencia = "GL" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 84, N_Pais = "Gambia", Referencia = "GM" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 85, N_Pais = "Guinea", Referencia = "GN" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 86, N_Pais = "Guadalupe, Isla", Referencia = "GP" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 87, N_Pais = "Guinea Ecuatorial", Referencia = "GQ" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 88, N_Pais = "Grecia", Referencia = "GR" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 89, N_Pais = "Georgias y Sandwich del Sur, Islas", Referencia = "GS" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 90, N_Pais = "Guatemala", Referencia = "GT" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 91, N_Pais = "Guam", Referencia = "GU" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 92, N_Pais = "Guinea-Bissau", Referencia = "GW" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 93, N_Pais = "Guyana", Referencia = "GY" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 94, N_Pais = "Hong Kong", Referencia = "HK" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 95, N_Pais = "Heard y McDonald, Islas de (Antártida)", Referencia = "HM" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 96, N_Pais = "Honduras", Referencia = "HN" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 97, N_Pais = "Croacia (Hrvatska)", Referencia = "HR" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 98, N_Pais = "Haití", Referencia = "HT" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 99, N_Pais = "Hungría", Referencia = "HU" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 100, N_Pais = "Indonesia", Referencia = "ID" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 101, N_Pais = "Irlanda", Referencia = "IE" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 102, N_Pais = "Israel", Referencia = "IL" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 103, N_Pais = "India", Referencia = "IN" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 104, N_Pais = "Territorios Británicos en el Océano Índico", Referencia = "IO" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 105, N_Pais = "Irak (Iraq)", Referencia = "IQ" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 106, N_Pais = "Irán", Referencia = "IR" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 107, N_Pais = "Islandia", Referencia = "IS" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 108, N_Pais = "Italia", Referencia = "IT" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 109, N_Pais = "Jersey, Isla (en Channel Islands – Inglaterra)", Referencia = "JE" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 110, N_Pais = "Jamaica", Referencia = "JM" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 111, N_Pais = "Jordania", Referencia = "JO" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 112, N_Pais = "Japón", Referencia = "JP" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 113, N_Pais = "Kenia", Referencia = "KE" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 114, N_Pais = "Kirguistán", Referencia = "KG" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 115, N_Pais = "Camboya", Referencia = "KH" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 116, N_Pais = "Kiribati", Referencia = "KI" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 117, N_Pais = "Comores, Islas", Referencia = "KM" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 118, N_Pais = "Saint Kitts y Nevis, Islas de (Caribe)", Referencia = "KN" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 119, N_Pais = "Corea del Norte (Korea Popular)", Referencia = "KP" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 120, N_Pais = "Corea del Sur (Korea Republic)", Referencia = "KR" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 121, N_Pais = "Kuwait", Referencia = "KW" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 122, N_Pais = "Caimán, Islas", Referencia = "KY" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 123, N_Pais = "Kazajstán", Referencia = "KZ" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 124, N_Pais = "Laos", Referencia = "LA" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 125, N_Pais = "Líbano", Referencia = "LB" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 126, N_Pais = "Santa Lucía, Isla de (Caribe)", Referencia = "LC" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 127, N_Pais = "Liechtenstein", Referencia = "LI" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 128, N_Pais = "Sri Lanka (ex Ceylán)", Referencia = "LK" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 129, N_Pais = "Liberia", Referencia = "LR" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 130, N_Pais = "Lesotho", Referencia = "LS" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 131, N_Pais = "Lituania", Referencia = "LT" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 132, N_Pais = "Luxemburgo", Referencia = "LU" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 133, N_Pais = "Latvia", Referencia = "LV" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 134, N_Pais = "Libia", Referencia = "LY" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 135, N_Pais = "Marruecos", Referencia = "MA" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 136, N_Pais = "Mónaco", Referencia = "MC" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 137, N_Pais = "Moldavia", Referencia = "MD" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 138, N_Pais = "Madagascar", Referencia = "MG" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 139, N_Pais = "Marshall, Islas", Referencia = "MH" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 140, N_Pais = "Macedonia", Referencia = "MK" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 141, N_Pais = "Malí", Referencia = "ML" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 142, N_Pais = "Myanmar (ex Birmania)", Referencia = "MM" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 143, N_Pais = "Mongolia", Referencia = "MN" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 144, N_Pais = "Macao, Isla", Referencia = "MO" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 145, N_Pais = "Mariana del Norte, Islas (Micronesia)", Referencia = "MP" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 146, N_Pais = "Martinica (Martinique)", Referencia = "MQ" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 147, N_Pais = "Mauritania", Referencia = "MR" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 148, N_Pais = "Montserrat", Referencia = "MS" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 149, N_Pais = "Malta", Referencia = "MT" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 150, N_Pais = "Mauricio, Islas", Referencia = "MU" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 151, N_Pais = "Maldivas, Islas", Referencia = "MV" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 152, N_Pais = "Malawi", Referencia = "MW" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 153, N_Pais = "México", Referencia = "MX" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 154, N_Pais = "Malasia (Malaysia)", Referencia = "MY" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 155, N_Pais = "Mozambique", Referencia = "MZ" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 156, N_Pais = "Namibia", Referencia = "NA" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 157, N_Pais = "Nueva Caledonia", Referencia = "NC" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 158, N_Pais = "Níger", Referencia = "NE" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 159, N_Pais = "Norfolk, Isla (Oceanía; territorio australiano)", Referencia = "NF" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 160, N_Pais = "Nigeria", Referencia = "NG" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 161, N_Pais = "Nicaragua", Referencia = "NI" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 162, N_Pais = "Holanda (Netherlands)", Referencia = "NL" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 163, N_Pais = "Noruega", Referencia = "NO" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 164, N_Pais = "Nepal", Referencia = "NP" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 165, N_Pais = "Nauru, Isla de (Micronesia)", Referencia = "NR" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 166, N_Pais = "Zona Neutral (en Oceanía)", Referencia = "NT" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 167, N_Pais = "Niue, Isla de (Oceanía)", Referencia = "NU" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 168, N_Pais = "Nueva Zelanda", Referencia = "NZ" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 169, N_Pais = "Omán", Referencia = "OM" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 170, N_Pais = "Panamá", Referencia = "PA" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 171, N_Pais = "Perú", Referencia = "PE" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 172, N_Pais = "Polinesia Francesa", Referencia = "PF" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 173, N_Pais = "Papúa Nueva Guinea", Referencia = "PG" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 174, N_Pais = "Filipinas (Philippines)", Referencia = "PH" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 175, N_Pais = "Pakistán", Referencia = "PK" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 176, N_Pais = "Polonia", Referencia = "PL" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 177, N_Pais = "San Pedro y Miquelón, Islas de (Caribe)", Referencia = "PM" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 178, N_Pais = "Pitcairn, Islas (Oceanía, Polinesia)", Referencia = "PN" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 179, N_Pais = "Puerto Rico", Referencia = "PR" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 180, N_Pais = "Portugal", Referencia = "PT" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 181, N_Pais = "Palau, Islas (Polinesia)", Referencia = "PW" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 182, N_Pais = "Paraguay", Referencia = "PY" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 183, N_Pais = "Qatar", Referencia = "QA" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 184, N_Pais = "Reunión, Isla (África)", Referencia = "RE" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 185, N_Pais = "Rumania (Romania)", Referencia = "RO" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 186, N_Pais = "Federación Rusa", Referencia = "RU" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 187, N_Pais = "Ruanda (Rwanda)", Referencia = "RW" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 188, N_Pais = "Arabia Saudita (Saudi Arabia)", Referencia = "SA" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 189, N_Pais = "Salomón, Islas", Referencia = "SB" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 190, N_Pais = "Seychelles, Islas", Referencia = "SC" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 191, N_Pais = "Sudán", Referencia = "SD" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 192, N_Pais = "Suecia", Referencia = "SE" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 193, N_Pais = "Singapur", Referencia = "SG" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 194, N_Pais = "Santa Helena, Isla de", Referencia = "SH" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 195, N_Pais = "Eslovenia", Referencia = "SI" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 196, N_Pais = "Svalbard y Jan Mayen, Islas de (Noruega)", Referencia = "SJ" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 197, N_Pais = "República Eslovaca (Slovak Republic)", Referencia = "SK" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 198, N_Pais = "Sierra Leona", Referencia = "SL" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 199, N_Pais = "San Marino", Referencia = "SM" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 200, N_Pais = "Senegal", Referencia = "SN" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 201, N_Pais = "Somalía", Referencia = "SO" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 202, N_Pais = "Surinam (Guayanas)", Referencia = "SR" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 203, N_Pais = "Santo Tomé y Príncipe, Islas de", Referencia = "ST" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 204, N_Pais = "Ex-Unión Soviética (USSR (former))", Referencia = "SU" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 205, N_Pais = "El Salvador", Referencia = "SV" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 206, N_Pais = "Siria (Syria)", Referencia = "SY" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 207, N_Pais = "Suazilandia (África)", Referencia = "SZ" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 208, N_Pais = "Turks y Caicos, Islas de (Bahamas)", Referencia = "TC" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 209, N_Pais = "Chad (Tchad)", Referencia = "TD" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 210, N_Pais = "Territorios Franceses del Sur (África)", Referencia = "TF" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 211, N_Pais = "Togo", Referencia = "TG" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 212, N_Pais = "Tailandia", Referencia = "TH" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 213, N_Pais = "Tadjikistan", Referencia = "TJ" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 214, N_Pais = "Tokelau, Islas (Oceanía)", Referencia = "TK" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 215, N_Pais = "Turkmenistán", Referencia = "TM" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 216, N_Pais = "Túnez", Referencia = "TN" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 217, N_Pais = "Tonga", Referencia = "TO" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 218, N_Pais = "Timor Oriental", Referencia = "TP" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 219, N_Pais = "Turquía", Referencia = "TR" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 220, N_Pais = "Trinidad y Tobago", Referencia = "TT" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 221, N_Pais = "Tuvalu, Islas (usado para sitios de TV)", Referencia = "TV" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 222, N_Pais = "Taiwán", Referencia = "TW" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 223, N_Pais = "Tanzania", Referencia = "TZ" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 224, N_Pais = "Ucrania", Referencia = "UA" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 225, N_Pais = "Uganda", Referencia = "UG" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 226, N_Pais = "Reino Unido (United Kingdom)", Referencia = "UK" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 227, N_Pais = "Islas Menores – Territ. de ultramar de Estados Unidos", Referencia = "UM" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 228, N_Pais = "Estados Unidos de America (United States of America)", Referencia = "US" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 229, N_Pais = "Uruguay", Referencia = "UY" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 230, N_Pais = "Uzbekistán", Referencia = "UZ" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 231, N_Pais = "Vaticano, Ciudad del", Referencia = "VA" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 232, N_Pais = "San Vicente y Granadinas, Islas (Caribe)", Referencia = "VC" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 233, N_Pais = "Venezuela", Referencia = "VE" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 234, N_Pais = "Vírgenes Británicas, Islas", Referencia = "VG" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 235, N_Pais = "Vírgenes Estadounidenses, Islas", Referencia = "VI" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 236, N_Pais = "Vietnam", Referencia = "VN" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 237, N_Pais = "Vanuatu, Islas (Oceanía)", Referencia = "VU" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 238, N_Pais = "Wallis y Futuna, Islas (Oceanía)", Referencia = "WF" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 239, N_Pais = "Samoa", Referencia = "WS" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 240, N_Pais = "Yemen", Referencia = "YE" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 241, N_Pais = "Mayotte", Referencia = "YT" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 242, N_Pais = "Yugoslavia", Referencia = "YU" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 243, N_Pais = "Sudáfrica", Referencia = "ZA" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 244, N_Pais = "Zambia", Referencia = "ZM" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 245, N_Pais = "Zaire", Referencia = "ZR" });
            modelBuilder.Entity<Pais>().HasData(new { ID_Pais = 246, N_Pais = "Zimbabwe", Referencia = "ZW" });
            #endregion

            #region Perfiles
            modelBuilder.Entity<Perfil>().HasData(new { ID_Perfil = 1, N_Perfil = "Administrador", ID_Estado = 1 });
            modelBuilder.Entity<Perfil>().HasData(new { ID_Perfil = 2, N_Perfil = "Bodeguero", ID_Estado = 1 });
            modelBuilder.Entity<Perfil>().HasData(new { ID_Perfil = 3, N_Perfil = "Cajero", ID_Estado = 1 });
            modelBuilder.Entity<Perfil>().HasData(new { ID_Perfil = 4, N_Perfil = "Vendedor", ID_Estado = 1 });
            #endregion

            #region Sucursales
            modelBuilder.Entity<Sucursal>().HasData(new
            {
                ID_Sucursal = 1,
                N_Sucursal = "Sucursal",
                Direccion = "Calle 123",
                Telefono1 = "123456789",
                Telefono2 = "24681012",
                Movil1 = "987654321",
                Movil2 = "121086420",
                Direccion_Correo = "Correo@Correo.CL",
                ID_Empresa = 1,
                ID_Comuna = 1101,
                ID_Ciudad = 3,
                ID_Pais = 2,
                ID_Region = 5,
                ID_Estado = 1
            });

            #endregion

            #region Empresas
            modelBuilder.Entity<Empresa>().HasData(new
            {
                ID_Empresa = 1,
                N_Empresa = "EMPRESA",
                Rut = "123456789-K",
                Direccion = "Calle 123",
                Razon_Social = "Algo",
                Giro = "asdada",
                Telefono1 = "123456789",
                Telefono2 = "24681012",
                Movil = "987654321",
                Direccion_Correo = "Correo@Correo.cl",
                Web = "www.empresa.cl",
                Observaciones = "Esta es una observacion",
                Fecha_Antiguedad = DateTime.Parse("1990-04-02"),
                ID_Ciudad = 3,
                ID_Comuna = 1101,
                ID_Pais = 2,
                ID_Region = 5,
                ID_Estado = 1,
                ID_Tipo_Empresa = 1,
                ID_Sucursal = 1
            });

            #endregion

            #region Marca
            modelBuilder.Entity<Marca>().HasData(new
            {
                ID_Marca = 1,
                N_Marca = "Nombre Marca 1",
                ID_Estado = 1,
            });


            #endregion


            #region Tipo_Empresa
            modelBuilder.Entity<Tipo_empresa>().HasData(new
            {
                ID_Tipo_Empresa= 1,
                N_TipoEmpresa = "adadsa",
                ID_Estado = 1,
                
            });
            #endregion


            # region Bodegas
            modelBuilder.Entity<Bodega>().HasData(new { ID_Bodega = 1, N_Bodega = "Bodega Prueba 1" });
            modelBuilder.Entity<Bodega>().HasData(new { ID_Bodega = 2, N_Bodega = "Bodega Prueba 2" });
            modelBuilder.Entity<Bodega>().HasData(new { ID_Bodega = 3, N_Bodega = "Bodega Prueba 3" });
            # endregion

            # region Tipo_material
            modelBuilder.Entity<Tipo_material>().HasData(new { ID_Tipo_Material = 1, N_Tipo_Material = "Material de Prueba 1" });
            modelBuilder.Entity<Tipo_material>().HasData(new { ID_Tipo_Material = 2, N_Tipo_Material = "Material de Prueba 2" });
            modelBuilder.Entity<Tipo_material>().HasData(new { ID_Tipo_Material = 3, N_Tipo_Material = "Material de Prueba 3" });
            # endregion

            # region Familias
            modelBuilder.Entity<Familia>().HasData(new { ID_Familia = 1, N_Familia = "Familia Prueba A" });
            modelBuilder.Entity<Familia>().HasData(new { ID_Familia = 2, N_Familia = "Familia Prueba B" });
            modelBuilder.Entity<Familia>().HasData(new { ID_Familia = 3, N_Familia = "Familia Prueba C" });
            # endregion

            # region Subfamilia
            modelBuilder.Entity<Subfamilia>().HasData(new { ID_Subfamilia = 1, N_Subfamilia = "Subfamilia Prueba Alpha" });
            modelBuilder.Entity<Subfamilia>().HasData(new { ID_Subfamilia = 2, N_Subfamilia = "Subfamilia Prueba Betha" });
            modelBuilder.Entity<Subfamilia>().HasData(new { ID_Subfamilia = 3, N_Subfamilia = "Subfamilia Prueba Gamma" });
            # endregion

            # region Unidades
            modelBuilder.Entity<Unidad>().HasData(new { ID_Unidad = 1, N_Unidad = "Unidad de Prueba 100" });
            modelBuilder.Entity<Unidad>().HasData(new { ID_Unidad = 2, N_Unidad = "Unidad de Prueba 200" });
            modelBuilder.Entity<Unidad>().HasData(new { ID_Unidad = 3, N_Unidad = "Unidad  dePrueba 300" });
            # endregion

            # region Ubicaciones
            modelBuilder.Entity<Ubicacion>().HasData(new { ID_Ubicacion = 1, N_Ubicacion = "Ubicacion de Prueba 1", ID_Bodega = 1, ID_Estado = 1 });
            modelBuilder.Entity<Ubicacion>().HasData(new { ID_Ubicacion = 2, N_Ubicacion = "Ubicacion de Prueba 2", ID_Bodega = 2, ID_Estado = 1 });
            modelBuilder.Entity<Ubicacion>().HasData(new { ID_Ubicacion = 3, N_Ubicacion = "Ubicacion de Prueba 3", ID_Bodega = 3, ID_Estado = 1 });
            # endregion

            # region Tipo_Documentos
            modelBuilder.Entity<Tipo_documento>().HasData(new { ID_Tipo_Documento = 1, N_Tipo_Documento = "Prueba 1 Tipo de Documento", ID_Estado = 1 });
            modelBuilder.Entity<Tipo_documento>().HasData(new { ID_Tipo_Documento = 2, N_Tipo_Documento = "Prueba 2 Tipo de Documento", ID_Estado = 1 });
            modelBuilder.Entity<Tipo_documento>().HasData(new { ID_Tipo_Documento = 3, N_Tipo_Documento = "Prueba 3 Tipo de Documento", ID_Estado = 1 });
            #endregion

            #region Tipo_Productos
            modelBuilder.Entity<Tipo_producto>().HasData(new { ID_Tipo_Producto = 1, N_Tipo_Producto = "Prueba 1 Tipo de Producto" });
            modelBuilder.Entity<Tipo_producto>().HasData(new { ID_Tipo_Producto = 2, N_Tipo_Producto = "Prueba 2 Tipo de Producto" });
            modelBuilder.Entity<Tipo_producto>().HasData(new { ID_Tipo_Producto = 3, N_Tipo_Producto = "Prueba 3 Tipo de Producto" });
            #endregion

            #region Tipo_Inventario
            modelBuilder.Entity<Tipo_inventario>().HasData(new { ID_Tipo_Inventario = 1, N_Tipo_Inventario = "Prueba 1 Tipo de Inventario", ID_Estado = 1 });
            modelBuilder.Entity<Tipo_inventario>().HasData(new { ID_Tipo_Inventario = 2, N_Tipo_Inventario = "Prueba 2 Tipo de Inventario", ID_Estado = 1 });
            modelBuilder.Entity<Tipo_inventario>().HasData(new { ID_Tipo_Inventario = 3, N_Tipo_Inventario = "Prueba 3 Tipo de Inventario", ID_Estado = 1 });
            #endregion

            #region Tipo_Pago
            modelBuilder.Entity<Tipo_pago>().HasData(new { ID_Tipo_Pago = 1, N_Tipo_Pago = "Prueba 1 Tipo de Pago", ID_Estado = 1 });
            modelBuilder.Entity<Tipo_pago>().HasData(new { ID_Tipo_Pago = 2, N_Tipo_Pago = "Prueba 2 Tipo de Pago", ID_Estado = 1 });
            modelBuilder.Entity<Tipo_pago>().HasData(new { ID_Tipo_Pago = 3, N_Tipo_Pago = "Prueba 3 Tipo de Pago", ID_Estado = 1 });
            #endregion

            #region Tipo_Descuentos
            modelBuilder.Entity<TipoDescuento>().HasData(new { ID_Tipo_Descuento = 1, N_Tipo_Descuento = "Prueba 1 Tipo de Descuento", ID_Estado = 1 });
            modelBuilder.Entity<TipoDescuento>().HasData(new { ID_Tipo_Descuento = 2, N_Tipo_Descuento = "Prueba 2 Tipo de Descuento", ID_Estado = 1 });
            modelBuilder.Entity<TipoDescuento>().HasData(new { ID_Tipo_Descuento = 3, N_Tipo_Descuento = "Prueba 3 Tipo de Descuento", ID_Estado = 1 });
            #endregion

            #region Tipo_Cliente_Proveedor
            modelBuilder.Entity<Tipo_cliente_proveedor>().HasData(new { ID_Tipo_Cliente_Proveedor = 1, N_Tipo_Cliente_Proveedor = "Prueba 1 Tipo de Cliente o Proveedor", ID_Estado = 1 });
            modelBuilder.Entity<Tipo_cliente_proveedor>().HasData(new { ID_Tipo_Cliente_Proveedor = 2, N_Tipo_Cliente_Proveedor = "Prueba 2 Tipo de Cliente o Proveedor", ID_Estado = 1 });
            modelBuilder.Entity<Tipo_cliente_proveedor>().HasData(new { ID_Tipo_Cliente_Proveedor = 3, N_Tipo_Cliente_Proveedor = "Prueba 3 Tipo de Cliente o Proveedor", ID_Estado = 1 });
            #endregion

            //#region Toma_Inventario
            //modelBuilder.Entity<Toma_inventario>().HasData(new {
            //    ID_TomaInventario = 1,
            //    N_funcionario = "Funcionario Prueba 1", 
            //    Fecha_Creacion = DateTime.Today, 
            //    StockIngresado = 1,
            //    StockActual = 1, 
            //    StockSolicitado = 1,
            //    ID_Producto = 1,
            //    ID_Estado = 1,
            //});
            //#endregion

            #region ClienteProveedores
            modelBuilder.Entity<ClienteProveedor>().HasData(new 
            {
                ID_Cliente_Proveedor = 1,
                N_Cliente_Proveedor = "Prueba 1 Cliente o Proveedor",
                ID_Tipo_Cliente_Proveedor = 1,
                Rut = "12345679",
                Razon_Social = "Prueba de razon social",
                Giro = "Prueba de Giro",
                Direccion = "Direccion de prueba 1",
                ID_Ciudad = 10,
                ID_Comuna = 10,
                ID_Region = 10,
                ID_Pais = 10,
                Telefono = "123456789",
                Movil = "987654321",
                Direccion_Correo = "prueba@correo1.com",
                Fecha_Ingreso = DateTime.Today,
                ID_Condicion_Venta = 1,
                Monto_Credito = (double) 40000,
                Observaciones = "prueba de una observacion, no mirar",
                ID_Usuario = "Prueba de nombre",
                Ult_Actualizacion = DateTime.Today,
                ID_Estado = 1,

            });

            #endregion

            #region Productos
            modelBuilder.Entity<Producto>().HasData(new
            {
                ID_Producto = 1,
                N_Producto = "Prueba Producto Alpha",
                Descripcion = "Este es una Descripción de prueba",
                Observaciones = "Esta es una Observación de prueba",
                Codigo_Barra = (long)12300000,
                Codigo_Interno = (long)45600000,
                Codigo_Parte = "1000001",
                Codigo_Proveedor = "2000002",
                Precio_Venta = (double)36000,
                Precio_Web = (double)16000,
                Valor_Compra = (double)50000,
                Valor_Flete = (double)10000,
                Valor_Costo = (double)30000,
                Valor_Margen = (double)20000,
                Valor_Descuento = (double)500,
                Fecha_Creacion = DateTime.Today,
                Ult_Inventario = DateTime.Today,
                Ult_Reposicion = DateTime.Today,
                Ult_Actualizacion = DateTime.Today,
                ID_Usuario = "Id Prueba1",
                ID_Tipo_Descuento = 1,
                ID_Unidad = 1,
                ID_Marca = 1,
                ID_Familia = 1,
                ID_SubFamilia = 1,
                ID_Tipo_Producto = 1,
                ID_Tipo_Inventario = 1,
                ID_Tipo_Material = 1,
                ID_Cliente_Proveedor = 1,
                ID_Estado = 1,

            });

            #endregion


        }
    }
}

