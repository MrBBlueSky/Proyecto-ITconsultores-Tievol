using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tievol.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Estados",
                schema: "dbo",
                columns: table => new
                {
                    ID_Estado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Estado = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.ID_Estado);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                schema: "dbo",
                columns: table => new
                {
                    ID_Pais = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.ID_Pais);
                });

            migrationBuilder.CreateTable(
                name: "Regiones",
                schema: "dbo",
                columns: table => new
                {
                    ID_Region = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Region = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiones", x => x.ID_Region);
                });

            migrationBuilder.CreateTable(
                name: "Clientes_Proveedores",
                schema: "dbo",
                columns: table => new
                {
                    ID_Cliente_Proveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Cliente_Proveedor = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ID_Tipo_Cliente_Proveedor = table.Column<int>(type: "int", nullable: false),
                    Rut = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Razon_Social = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Giro = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ID_Ciudad = table.Column<int>(type: "int", nullable: false),
                    ID_Comuna = table.Column<int>(type: "int", nullable: false),
                    ID_Region = table.Column<int>(type: "int", nullable: false),
                    ID_Pais = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Movil = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Direccion_Correo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Fecha_Ingreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_Condicion_Venta = table.Column<int>(type: "int", nullable: false),
                    Monto_Credito = table.Column<double>(type: "float", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_Estado = table.Column<int>(type: "int", nullable: true),
                    ID_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ult_Actualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes_Proveedores", x => x.ID_Cliente_Proveedor);
                    table.ForeignKey(
                        name: "FK_Clientes_Proveedores_Estados_ID_Estado",
                        column: x => x.ID_Estado,
                        principalSchema: "dbo",
                        principalTable: "Estados",
                        principalColumn: "ID_Estado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Familias",
                schema: "dbo",
                columns: table => new
                {
                    ID_Familia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Familia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familias", x => x.ID_Familia);
                    table.ForeignKey(
                        name: "FK_Familias_Estados_ID_Estado",
                        column: x => x.ID_Estado,
                        principalSchema: "dbo",
                        principalTable: "Estados",
                        principalColumn: "ID_Estado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                schema: "dbo",
                columns: table => new
                {
                    ID_Marca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_Estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.ID_Marca);
                    table.ForeignKey(
                        name: "FK_Marca_Estados_ID_Estado",
                        column: x => x.ID_Estado,
                        principalSchema: "dbo",
                        principalTable: "Estados",
                        principalColumn: "ID_Estado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Perfiles",
                schema: "dbo",
                columns: table => new
                {
                    ID_Perfil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Perfil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfiles", x => x.ID_Perfil);
                    table.ForeignKey(
                        name: "FK_Perfiles_Estados_ID_Estado",
                        column: x => x.ID_Estado,
                        principalSchema: "dbo",
                        principalTable: "Estados",
                        principalColumn: "ID_Estado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Cliente_Proveedor",
                schema: "dbo",
                columns: table => new
                {
                    ID_Tipo_Cliente_Proveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Tipo_Cliente_Proveedor = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    ID_Estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Cliente_Proveedor", x => x.ID_Tipo_Cliente_Proveedor);
                    table.ForeignKey(
                        name: "FK_Tipo_Cliente_Proveedor_Estados_ID_Estado",
                        column: x => x.ID_Estado,
                        principalSchema: "dbo",
                        principalTable: "Estados",
                        principalColumn: "ID_Estado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Descuentos",
                schema: "dbo",
                columns: table => new
                {
                    ID_Tipo_Descuento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Tipo_Descuento = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ID_Estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Descuentos", x => x.ID_Tipo_Descuento);
                    table.ForeignKey(
                        name: "FK_Tipo_Descuentos_Estados_ID_Estado",
                        column: x => x.ID_Estado,
                        principalSchema: "dbo",
                        principalTable: "Estados",
                        principalColumn: "ID_Estado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Documentos",
                schema: "dbo",
                columns: table => new
                {
                    ID_Tipo_Documento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Tipo_Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_Estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Documentos", x => x.ID_Tipo_Documento);
                    table.ForeignKey(
                        name: "FK_Tipo_Documentos_Estados_ID_Estado",
                        column: x => x.ID_Estado,
                        principalSchema: "dbo",
                        principalTable: "Estados",
                        principalColumn: "ID_Estado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Empresa",
                schema: "dbo",
                columns: table => new
                {
                    ID_Tipo_Empresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Tipo_Empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_Estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Empresa", x => x.ID_Tipo_Empresa);
                    table.ForeignKey(
                        name: "FK_Tipo_Empresa_Estados_ID_Estado",
                        column: x => x.ID_Estado,
                        principalSchema: "dbo",
                        principalTable: "Estados",
                        principalColumn: "ID_Estado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Inventario",
                schema: "dbo",
                columns: table => new
                {
                    ID_Tipo_Inventario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Tipo_Inventario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_Estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Inventario", x => x.ID_Tipo_Inventario);
                    table.ForeignKey(
                        name: "FK_Tipo_Inventario_Estados_ID_Estado",
                        column: x => x.ID_Estado,
                        principalSchema: "dbo",
                        principalTable: "Estados",
                        principalColumn: "ID_Estado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Material",
                schema: "dbo",
                columns: table => new
                {
                    ID_Tipo_Material = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Tipo_Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_Estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Material", x => x.ID_Tipo_Material);
                    table.ForeignKey(
                        name: "FK_Tipo_Material_Estados_ID_Estado",
                        column: x => x.ID_Estado,
                        principalSchema: "dbo",
                        principalTable: "Estados",
                        principalColumn: "ID_Estado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Pago",
                schema: "dbo",
                columns: table => new
                {
                    ID_Tipo_Pago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Tipo_Pago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_Estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Pago", x => x.ID_Tipo_Pago);
                    table.ForeignKey(
                        name: "FK_Tipo_Pago_Estados_ID_Estado",
                        column: x => x.ID_Estado,
                        principalSchema: "dbo",
                        principalTable: "Estados",
                        principalColumn: "ID_Estado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Productos",
                schema: "dbo",
                columns: table => new
                {
                    ID_Tipo_Producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Tipo_Producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Productos", x => x.ID_Tipo_Producto);
                    table.ForeignKey(
                        name: "FK_Tipo_Productos_Estados_ID_Estado",
                        column: x => x.ID_Estado,
                        principalSchema: "dbo",
                        principalTable: "Estados",
                        principalColumn: "ID_Estado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                schema: "dbo",
                columns: table => new
                {
                    ID_Unidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Unidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.ID_Unidad);
                    table.ForeignKey(
                        name: "FK_Unidades_Estados_ID_Estado",
                        column: x => x.ID_Estado,
                        principalSchema: "dbo",
                        principalTable: "Estados",
                        principalColumn: "ID_Estado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                schema: "dbo",
                columns: table => new
                {
                    ID_Ciudad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Ciudad = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    ID_Region = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.ID_Ciudad);
                    table.ForeignKey(
                        name: "FK_Ciudades_Regiones_ID_Region",
                        column: x => x.ID_Region,
                        principalSchema: "dbo",
                        principalTable: "Regiones",
                        principalColumn: "ID_Region",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comunas",
                schema: "dbo",
                columns: table => new
                {
                    ID_Comuna = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Comuna = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    ID_Region = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comunas", x => x.ID_Comuna);
                    table.ForeignKey(
                        name: "FK_Comunas_Regiones_ID_Region",
                        column: x => x.ID_Region,
                        principalSchema: "dbo",
                        principalTable: "Regiones",
                        principalColumn: "ID_Region",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subfamilia",
                schema: "dbo",
                columns: table => new
                {
                    ID_Subfamilia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Subfamilia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_Estado = table.Column<int>(type: "int", nullable: true),
                    ID_Familia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subfamilia", x => x.ID_Subfamilia);
                    table.ForeignKey(
                        name: "FK_Subfamilia_Estados_ID_Estado",
                        column: x => x.ID_Estado,
                        principalSchema: "dbo",
                        principalTable: "Estados",
                        principalColumn: "ID_Estado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subfamilia_Familias_ID_Familia",
                        column: x => x.ID_Familia,
                        principalSchema: "dbo",
                        principalTable: "Familias",
                        principalColumn: "ID_Familia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                schema: "dbo",
                columns: table => new
                {
                    ID_Empresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Empresa = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Rut = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Razon_Social = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Giro = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Telefono1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Telefono2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Movil = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Direccion_Correo = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Web = table.Column<string>(type: "nvarchar(95)", maxLength: 95, nullable: false),
                    Fecha_Antiguedad = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(95)", maxLength: 95, nullable: false),
                    ID_Ciudad = table.Column<int>(type: "int", nullable: true),
                    ID_Pais = table.Column<int>(type: "int", nullable: true),
                    ID_Comuna = table.Column<int>(type: "int", nullable: true),
                    ID_Region = table.Column<int>(type: "int", nullable: true),
                    ID_Estado = table.Column<int>(type: "int", nullable: true),
                    ID_Tipo_Empresa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.ID_Empresa);
                    table.ForeignKey(
                        name: "FK_Empresas_Ciudades_ID_Ciudad",
                        column: x => x.ID_Ciudad,
                        principalSchema: "dbo",
                        principalTable: "Ciudades",
                        principalColumn: "ID_Ciudad",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empresas_Comunas_ID_Comuna",
                        column: x => x.ID_Comuna,
                        principalSchema: "dbo",
                        principalTable: "Comunas",
                        principalColumn: "ID_Comuna",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empresas_Estados_ID_Estado",
                        column: x => x.ID_Estado,
                        principalSchema: "dbo",
                        principalTable: "Estados",
                        principalColumn: "ID_Estado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empresas_Paises_ID_Pais",
                        column: x => x.ID_Pais,
                        principalSchema: "dbo",
                        principalTable: "Paises",
                        principalColumn: "ID_Pais",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empresas_Regiones_ID_Region",
                        column: x => x.ID_Region,
                        principalSchema: "dbo",
                        principalTable: "Regiones",
                        principalColumn: "ID_Region",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empresas_Tipo_Empresa_ID_Tipo_Empresa",
                        column: x => x.ID_Tipo_Empresa,
                        principalSchema: "dbo",
                        principalTable: "Tipo_Empresa",
                        principalColumn: "ID_Tipo_Empresa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                schema: "dbo",
                columns: table => new
                {
                    ID_Producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Producto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Codigo_Barra = table.Column<long>(type: "bigint", nullable: false),
                    Codigo_Interno = table.Column<long>(type: "bigint", nullable: false),
                    Codigo_Parte = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Codigo_Proveedor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Precio_Venta = table.Column<double>(type: "float", nullable: false),
                    Precio_Web = table.Column<double>(type: "float", nullable: false),
                    Valor_Compra = table.Column<double>(type: "float", nullable: false),
                    Valor_Flete = table.Column<double>(type: "float", nullable: false),
                    Valor_Costo = table.Column<double>(type: "float", nullable: false),
                    Valor_Margen = table.Column<double>(type: "float", nullable: false),
                    Valor_Descuento = table.Column<double>(type: "float", nullable: false),
                    Fecha_Creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ult_Inventario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ult_Reposicion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_Tipo_Descuento = table.Column<int>(type: "int", nullable: true),
                    ID_Unidad = table.Column<int>(type: "int", nullable: false),
                    ID_Marca = table.Column<int>(type: "int", nullable: true),
                    ID_Familia = table.Column<int>(type: "int", nullable: false),
                    ID_SubFamilia = table.Column<int>(type: "int", nullable: false),
                    ID_Tipo_Producto = table.Column<int>(type: "int", nullable: true),
                    ID_Tipo_Inventario = table.Column<int>(type: "int", nullable: true),
                    ID_Tipo_Material = table.Column<int>(type: "int", nullable: true),
                    ID_Cliente_Proveedor = table.Column<int>(type: "int", nullable: false),
                    ID_Estado = table.Column<int>(type: "int", nullable: false),
                    ID_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ult_Actualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ID_Producto);
                    table.ForeignKey(
                        name: "FK_Productos_Clientes_Proveedores_ID_Cliente_Proveedor",
                        column: x => x.ID_Cliente_Proveedor,
                        principalSchema: "dbo",
                        principalTable: "Clientes_Proveedores",
                        principalColumn: "ID_Cliente_Proveedor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Estados_ID_Estado",
                        column: x => x.ID_Estado,
                        principalSchema: "dbo",
                        principalTable: "Estados",
                        principalColumn: "ID_Estado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Familias_ID_Familia",
                        column: x => x.ID_Familia,
                        principalSchema: "dbo",
                        principalTable: "Familias",
                        principalColumn: "ID_Familia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Marca_ID_Marca",
                        column: x => x.ID_Marca,
                        principalSchema: "dbo",
                        principalTable: "Marca",
                        principalColumn: "ID_Marca",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Subfamilia_ID_SubFamilia",
                        column: x => x.ID_SubFamilia,
                        principalSchema: "dbo",
                        principalTable: "Subfamilia",
                        principalColumn: "ID_Subfamilia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Tipo_Descuentos_ID_Tipo_Descuento",
                        column: x => x.ID_Tipo_Descuento,
                        principalSchema: "dbo",
                        principalTable: "Tipo_Descuentos",
                        principalColumn: "ID_Tipo_Descuento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Tipo_Inventario_ID_Tipo_Inventario",
                        column: x => x.ID_Tipo_Inventario,
                        principalSchema: "dbo",
                        principalTable: "Tipo_Inventario",
                        principalColumn: "ID_Tipo_Inventario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Tipo_Material_ID_Tipo_Material",
                        column: x => x.ID_Tipo_Material,
                        principalSchema: "dbo",
                        principalTable: "Tipo_Material",
                        principalColumn: "ID_Tipo_Material",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Tipo_Productos_ID_Tipo_Producto",
                        column: x => x.ID_Tipo_Producto,
                        principalSchema: "dbo",
                        principalTable: "Tipo_Productos",
                        principalColumn: "ID_Tipo_Producto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Unidades_ID_Unidad",
                        column: x => x.ID_Unidad,
                        principalSchema: "dbo",
                        principalTable: "Unidades",
                        principalColumn: "ID_Unidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sucursales",
                schema: "dbo",
                columns: table => new
                {
                    ID_Sucursal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Sucursal = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Telefono1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Movil1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Movil2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion_Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    ID_Ciudad = table.Column<int>(type: "int", nullable: true),
                    ID_Pais = table.Column<int>(type: "int", nullable: true),
                    ID_Comuna = table.Column<int>(type: "int", nullable: true),
                    ID_Region = table.Column<int>(type: "int", nullable: true),
                    ID_Estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.ID_Sucursal);
                    table.ForeignKey(
                        name: "FK_Sucursales_Ciudades_ID_Ciudad",
                        column: x => x.ID_Ciudad,
                        principalSchema: "dbo",
                        principalTable: "Ciudades",
                        principalColumn: "ID_Ciudad",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sucursales_Comunas_ID_Comuna",
                        column: x => x.ID_Comuna,
                        principalSchema: "dbo",
                        principalTable: "Comunas",
                        principalColumn: "ID_Comuna",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sucursales_Empresas_ID_Empresa",
                        column: x => x.ID_Empresa,
                        principalSchema: "dbo",
                        principalTable: "Empresas",
                        principalColumn: "ID_Empresa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sucursales_Estados_ID_Estado",
                        column: x => x.ID_Estado,
                        principalSchema: "dbo",
                        principalTable: "Estados",
                        principalColumn: "ID_Estado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sucursales_Paises_ID_Pais",
                        column: x => x.ID_Pais,
                        principalSchema: "dbo",
                        principalTable: "Paises",
                        principalColumn: "ID_Pais",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sucursales_Regiones_ID_Region",
                        column: x => x.ID_Region,
                        principalSchema: "dbo",
                        principalTable: "Regiones",
                        principalColumn: "ID_Region",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Toma_inventario",
                schema: "dbo",
                columns: table => new
                {
                    ID_TomaInventario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_funcionario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha_Creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StockIngresado = table.Column<int>(type: "int", nullable: false),
                    StockActual = table.Column<int>(type: "int", nullable: false),
                    StockSolicitado = table.Column<int>(type: "int", nullable: false),
                    ID_Producto = table.Column<int>(type: "int", nullable: true),
                    ID_Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toma_inventario", x => x.ID_TomaInventario);
                    table.ForeignKey(
                        name: "FK_Toma_inventario_Estados_ID_Estado",
                        column: x => x.ID_Estado,
                        principalSchema: "dbo",
                        principalTable: "Estados",
                        principalColumn: "ID_Estado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Toma_inventario_Productos_ID_Producto",
                        column: x => x.ID_Producto,
                        principalSchema: "dbo",
                        principalTable: "Productos",
                        principalColumn: "ID_Producto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bodegas",
                schema: "dbo",
                columns: table => new
                {
                    ID_Bodega = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Bodega = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    ID_Sucursal = table.Column<int>(type: "int", nullable: true),
                    ID_Estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodegas", x => x.ID_Bodega);
                    table.ForeignKey(
                        name: "FK_Bodegas_Estados_ID_Estado",
                        column: x => x.ID_Estado,
                        principalSchema: "dbo",
                        principalTable: "Estados",
                        principalColumn: "ID_Estado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bodegas_Sucursales_ID_Sucursal",
                        column: x => x.ID_Sucursal,
                        principalSchema: "dbo",
                        principalTable: "Sucursales",
                        principalColumn: "ID_Sucursal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ubicaciones",
                schema: "dbo",
                columns: table => new
                {
                    ID_Ubicacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Bodega = table.Column<int>(type: "int", nullable: true),
                    ID_Estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicaciones", x => x.ID_Ubicacion);
                    table.ForeignKey(
                        name: "FK_Ubicaciones_Bodegas_ID_Bodega",
                        column: x => x.ID_Bodega,
                        principalSchema: "dbo",
                        principalTable: "Bodegas",
                        principalColumn: "ID_Bodega",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ubicaciones_Estados_ID_Estado",
                        column: x => x.ID_Estado,
                        principalSchema: "dbo",
                        principalTable: "Estados",
                        principalColumn: "ID_Estado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Bodegas",
                columns: new[] { "ID_Bodega", "ID_Estado", "ID_Sucursal", "N_Bodega" },
                values: new object[,]
                {
                    { 1, null, null, "Bodega Prueba 1" },
                    { 2, null, null, "Bodega Prueba 2" },
                    { 3, null, null, "Bodega Prueba 3" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Estados",
                columns: new[] { "ID_Estado", "N_Estado" },
                values: new object[,]
                {
                    { 1, "Activo" },
                    { 2, "Suspendido" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Familias",
                columns: new[] { "ID_Familia", "ID_Estado", "N_Familia" },
                values: new object[,]
                {
                    { 1, null, "Familia Prueba A" },
                    { 2, null, "Familia Prueba B" },
                    { 3, null, "Familia Prueba C" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Paises",
                columns: new[] { "ID_Pais", "N_Pais", "Referencia" },
                values: new object[,]
                {
                    { 168, "Nueva Zelanda", "NZ" },
                    { 167, "Niue, Isla de (Oceanía)", "NU" },
                    { 166, "Zona Neutral (en Oceanía)", "NT" },
                    { 165, "Nauru, Isla de (Micronesia)", "NR" },
                    { 164, "Nepal", "NP" },
                    { 160, "Nigeria", "NG" },
                    { 162, "Holanda (Netherlands)", "NL" },
                    { 161, "Nicaragua", "NI" },
                    { 169, "Omán", "OM" },
                    { 159, "Norfolk, Isla (Oceanía; territorio australiano)", "NF" },
                    { 158, "Níger", "NE" },
                    { 163, "Noruega", "NO" },
                    { 170, "Panamá", "PA" },
                    { 174, "Filipinas (Philippines)", "PH" },
                    { 172, "Polinesia Francesa", "PF" },
                    { 173, "Papúa Nueva Guinea", "PG" },
                    { 157, "Nueva Caledonia", "NC" },
                    { 175, "Pakistán", "PK" },
                    { 176, "Polonia", "PL" },
                    { 177, "San Pedro y Miquelón, Islas de (Caribe)", "PM" },
                    { 178, "Pitcairn, Islas (Oceanía, Polinesia)", "PN" },
                    { 179, "Puerto Rico", "PR" },
                    { 180, "Portugal", "PT" },
                    { 181, "Palau, Islas (Polinesia)", "PW" },
                    { 182, "Paraguay", "PY" },
                    { 183, "Qatar", "QA" },
                    { 184, "Reunión, Isla (África)", "RE" },
                    { 171, "Perú", "PE" },
                    { 156, "Namibia", "NA" },
                    { 152, "Malawi", "MW" },
                    { 154, "Malasia (Malaysia)", "MY" },
                    { 126, "Santa Lucía, Isla de (Caribe)", "LC" },
                    { 127, "Liechtenstein", "LI" },
                    { 128, "Sri Lanka (ex Ceylán)", "LK" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Paises",
                columns: new[] { "ID_Pais", "N_Pais", "Referencia" },
                values: new object[,]
                {
                    { 129, "Liberia", "LR" },
                    { 130, "Lesotho", "LS" },
                    { 131, "Lituania", "LT" },
                    { 132, "Luxemburgo", "LU" },
                    { 134, "Libia", "LY" },
                    { 135, "Marruecos", "MA" },
                    { 136, "Mónaco", "MC" },
                    { 137, "Moldavia", "MD" },
                    { 138, "Madagascar", "MG" },
                    { 139, "Marshall, Islas", "MH" },
                    { 140, "Macedonia", "MK" },
                    { 141, "Malí", "ML" },
                    { 142, "Myanmar (ex Birmania)", "MM" },
                    { 143, "Mongolia", "MN" },
                    { 144, "Macao, Isla", "MO" },
                    { 145, "Mariana del Norte, Islas (Micronesia)", "MP" },
                    { 146, "Martinica (Martinique)", "MQ" },
                    { 147, "Mauritania", "MR" },
                    { 148, "Montserrat", "MS" },
                    { 149, "Malta", "MT" },
                    { 150, "Mauricio, Islas", "MU" },
                    { 151, "Maldivas, Islas", "MV" },
                    { 185, "Rumania (Romania)", "RO" },
                    { 153, "México", "MX" },
                    { 155, "Mozambique", "MZ" },
                    { 186, "Federación Rusa", "RU" },
                    { 190, "Seychelles, Islas", "SC" },
                    { 188, "Arabia Saudita (Saudi Arabia)", "SA" },
                    { 220, "Trinidad y Tobago", "TT" },
                    { 221, "Tuvalu, Islas (usado para sitios de TV)", "TV" },
                    { 222, "Taiwán", "TW" },
                    { 223, "Tanzania", "TZ" },
                    { 224, "Ucrania", "UA" },
                    { 225, "Uganda", "UG" },
                    { 226, "Reino Unido (United Kingdom)", "UK" },
                    { 227, "Islas Menores – Territ. de ultramar de Estados Unidos", "UM" },
                    { 228, "Estados Unidos de America (United States of America)", "US" },
                    { 229, "Uruguay", "UY" },
                    { 230, "Uzbekistán", "UZ" },
                    { 231, "Vaticano, Ciudad del", "VA" },
                    { 232, "San Vicente y Granadinas, Islas (Caribe)", "VC" },
                    { 233, "Venezuela", "VE" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Paises",
                columns: new[] { "ID_Pais", "N_Pais", "Referencia" },
                values: new object[,]
                {
                    { 234, "Vírgenes Británicas, Islas", "VG" },
                    { 235, "Vírgenes Estadounidenses, Islas", "VI" },
                    { 236, "Vietnam", "VN" },
                    { 237, "Vanuatu, Islas (Oceanía)", "VU" },
                    { 238, "Wallis y Futuna, Islas (Oceanía)", "WF" },
                    { 239, "Samoa", "WS" },
                    { 240, "Yemen", "YE" },
                    { 241, "Mayotte", "YT" },
                    { 242, "Yugoslavia", "YU" },
                    { 243, "Sudáfrica", "ZA" },
                    { 244, "Zambia", "ZM" },
                    { 245, "Zaire", "ZR" },
                    { 246, "Zimbabwe", "ZW" },
                    { 219, "Turquía", "TR" },
                    { 187, "Ruanda (Rwanda)", "RW" },
                    { 218, "Timor Oriental", "TP" },
                    { 216, "Túnez", "TN" },
                    { 189, "Salomón, Islas", "SB" },
                    { 125, "Líbano", "LB" },
                    { 191, "Sudán", "SD" },
                    { 192, "Suecia", "SE" },
                    { 193, "Singapur", "SG" },
                    { 194, "Santa Helena, Isla de", "SH" },
                    { 195, "Eslovenia", "SI" },
                    { 196, "Svalbard y Jan Mayen, Islas de (Noruega)", "SJ" },
                    { 197, "República Eslovaca (Slovak Republic)", "SK" },
                    { 198, "Sierra Leona", "SL" },
                    { 199, "San Marino", "SM" },
                    { 200, "Senegal", "SN" },
                    { 201, "Somalía", "SO" },
                    { 202, "Surinam (Guayanas)", "SR" },
                    { 203, "Santo Tomé y Príncipe, Islas de", "ST" },
                    { 204, "Ex-Unión Soviética (USSR (former))", "SU" },
                    { 205, "El Salvador", "SV" },
                    { 206, "Siria (Syria)", "SY" },
                    { 207, "Suazilandia (África)", "SZ" },
                    { 208, "Turks y Caicos, Islas de (Bahamas)", "TC" },
                    { 209, "Chad (Tchad)", "TD" },
                    { 210, "Territorios Franceses del Sur (África)", "TF" },
                    { 211, "Togo", "TG" },
                    { 212, "Tailandia", "TH" },
                    { 213, "Tadjikistan", "TJ" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Paises",
                columns: new[] { "ID_Pais", "N_Pais", "Referencia" },
                values: new object[,]
                {
                    { 214, "Tokelau, Islas (Oceanía)", "TK" },
                    { 215, "Turkmenistán", "TM" },
                    { 217, "Tonga", "TO" },
                    { 124, "Laos", "LA" },
                    { 133, "Latvia", "LV" },
                    { 122, "Caimán, Islas", "KY" },
                    { 33, "Bouvet, Isla", "BV" },
                    { 34, "Botswana", "BW" },
                    { 35, "Bielorrusia (Belarus)", "BY" },
                    { 36, "Bélice", "BZ" },
                    { 37, "Canadá", "CA" },
                    { 38, "Cocos, Islas", "CC" },
                    { 39, "República Centroafricana", "CF" },
                    { 40, "Congo", "CG" },
                    { 41, "Suiza", "CH" },
                    { 42, "Costa de Marfil (Côte D’Ivoire)", "CI" },
                    { 43, "Cook, Islas", "CK" },
                    { 44, "Chile", "CL" },
                    { 45, "Camerún", "CM" },
                    { 46, "China", "CN" },
                    { 47, "Colombia", "CO" },
                    { 48, "Costa Rica", "CR" },
                    { 123, "Kazajstán", "KZ" },
                    { 50, "Cuba", "CU" },
                    { 51, "Cabo Verde", "CV" },
                    { 52, "Navidad, Isla (Kiribati)", "CX" },
                    { 53, "Chipre (Cyprus)", "CY" },
                    { 54, "República Checa (Czech Republic)", "CZ" },
                    { 55, "Alemania", "DE" },
                    { 56, "Djibouti", "DJ" },
                    { 57, "Dinamarca (Denmark)", "DK" },
                    { 58, "Dominica", "DM" },
                    { 59, "República Dominicana", "DO" },
                    { 32, "Bután", "BT" },
                    { 31, "Bahamas", "BS" },
                    { 30, "Brasil", "BR" },
                    { 29, "Bolivia", "BO" },
                    { 1, "Ascension, Islas", "AC" },
                    { 2, "Andorra", "AD" },
                    { 3, "Emiratos Árabes Unidos", "AE" },
                    { 4, "Afganistán", "AF" },
                    { 5, "Antigua y Barbuda", "AG" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Paises",
                columns: new[] { "ID_Pais", "N_Pais", "Referencia" },
                values: new object[,]
                {
                    { 6, "Anguila (Caribe)", "AI" },
                    { 7, "Albania", "AL" },
                    { 8, "Armenia", "AM" },
                    { 9, "Antillas Holandesas", "AN" },
                    { 10, "Angola", "AO" },
                    { 11, "Antártida", "AQ" },
                    { 12, "Argentina", "AR" },
                    { 13, "Samoa Americana (American Samoa)", "AS" },
                    { 60, "Argelia (Algeria)", "DZ" },
                    { 14, "Austria", "AT" },
                    { 16, "Aruba", "AW" },
                    { 17, "Azerbaiján", "AZ" },
                    { 18, "Bosnia-Herzegovina", "BA" },
                    { 19, "Barbados", "BB" },
                    { 20, "Bangladesh", "BD" },
                    { 21, "Bélgica", "BE" },
                    { 22, "Burkina Faso", "BF" },
                    { 23, "Bulgaria", "BG" },
                    { 24, "Bahrein", "BH" },
                    { 25, "Burundi", "BI" },
                    { 26, "Benín", "BJ" },
                    { 27, "Bermudas, Islas", "BM" },
                    { 28, "Brunei Darussalam", "BN" },
                    { 15, "Australia", "AU" },
                    { 61, "Ecuador", "EC" },
                    { 49, "Antigua Checoslovaquia", "CS" },
                    { 63, "Egipto", "EG" },
                    { 95, "Heard y McDonald, Islas de (Antártida)", "HM" },
                    { 96, "Honduras", "HN" },
                    { 97, "Croacia (Hrvatska)", "HR" },
                    { 98, "Haití", "HT" },
                    { 99, "Hungría", "HU" },
                    { 100, "Indonesia", "ID" },
                    { 101, "Irlanda", "IE" },
                    { 102, "Israel", "IL" },
                    { 103, "India", "IN" },
                    { 104, "Territorios Británicos en el Océano Índico", "IO" },
                    { 105, "Irak (Iraq)", "IQ" },
                    { 62, "Estonia", "EE" },
                    { 107, "Islandia", "IS" },
                    { 108, "Italia", "IT" },
                    { 109, "Jersey, Isla (en Channel Islands – Inglaterra)", "JE" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Paises",
                columns: new[] { "ID_Pais", "N_Pais", "Referencia" },
                values: new object[,]
                {
                    { 110, "Jamaica", "JM" },
                    { 111, "Jordania", "JO" },
                    { 112, "Japón", "JP" },
                    { 113, "Kenia", "KE" },
                    { 114, "Kirguistán", "KG" },
                    { 115, "Camboya", "KH" },
                    { 116, "Kiribati", "KI" },
                    { 117, "Comores, Islas", "KM" },
                    { 118, "Saint Kitts y Nevis, Islas de (Caribe)", "KN" },
                    { 119, "Corea del Norte (Korea Popular)", "KP" },
                    { 120, "Corea del Sur (Korea Republic)", "KR" },
                    { 121, "Kuwait", "KW" },
                    { 94, "Hong Kong", "HK" },
                    { 93, "Guyana", "GY" },
                    { 106, "Irán", "IR" },
                    { 91, "Guam", "GU" },
                    { 64, "Sahara Occidental", "EH" },
                    { 92, "Guinea-Bissau", "GW" },
                    { 66, "España", "ES" },
                    { 67, "Etiopía", "ET" },
                    { 68, "Finlandia", "FI" },
                    { 69, "Fiji", "FJ" },
                    { 70, "Malvinas, Islas (Falkland)", "FK" },
                    { 71, "Micronesia", "FM" },
                    { 72, "Feroe, Islas", "FO" },
                    { 73, "Francia", "FR" },
                    { 74, "Francia – Área Metropolitana", "FX" },
                    { 75, "Gabón", "GA" },
                    { 76, "Gran Bretaña (Great Britain) (UK)", "GB" },
                    { 65, "Eritrea", "ER" },
                    { 78, "Georgia (ex-URSS)", "GE" },
                    { 90, "Guatemala", "GT" },
                    { 89, "Georgias y Sandwich del Sur, Islas", "GS" },
                    { 88, "Grecia", "GR" },
                    { 86, "Guadalupe, Isla", "GP" },
                    { 85, "Guinea", "GN" },
                    { 84, "Gambia", "GM" },
                    { 87, "Guinea Ecuatorial", "GQ" },
                    { 82, "Gibraltar", "GI" },
                    { 81, "Ghana", "GH" },
                    { 80, "Guernsey, Isla (en Channel Islands – Inglaterra)", "GG" },
                    { 79, "Guayana Francesa", "GF" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Paises",
                columns: new[] { "ID_Pais", "N_Pais", "Referencia" },
                values: new object[,]
                {
                    { 83, "Groenlandia", "GL" },
                    { 77, "Granada (Grenada) (Caribe)", "GD" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Regiones",
                columns: new[] { "ID_Region", "N_Region" },
                values: new object[,]
                {
                    { 15, "XV - Región de Arica y Parinacota" },
                    { 9, "IX - Región de la Araucanía" },
                    { 14, "XIV - Región de Los Rios" },
                    { 13, "XIII - Región Metropolitana" },
                    { 12, "XII - Región de Magallanes Y Antártica Chilena" },
                    { 11, "XI - Región de Aysén" },
                    { 10, "X - Región de Los Lagos" },
                    { 7, "VII - Región del Maule" },
                    { 6, "VI - Región de O’higgins" },
                    { 5, "V - Región de Valparaíso" },
                    { 4, "IV - Región de Coquimbo" },
                    { 3, "III - Región de Atacama" },
                    { 2, "II - Región de Antofagasta" },
                    { 1, "I - Región de Tarapacá" },
                    { 8, "VIII - Región del Bío Bío" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Subfamilia",
                columns: new[] { "ID_Subfamilia", "ID_Estado", "ID_Familia", "N_Subfamilia" },
                values: new object[,]
                {
                    { 2, null, null, "Subfamilia Prueba Betha" },
                    { 3, null, null, "Subfamilia Prueba Gamma" },
                    { 1, null, null, "Subfamilia Prueba Alpha" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Tipo_Material",
                columns: new[] { "ID_Tipo_Material", "ID_Estado", "N_Tipo_Material" },
                values: new object[,]
                {
                    { 1, null, "Material de Prueba 1" },
                    { 2, null, "Material de Prueba 2" },
                    { 3, null, "Material de Prueba 3" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Tipo_Productos",
                columns: new[] { "ID_Tipo_Producto", "ID_Estado", "N_Tipo_Producto" },
                values: new object[,]
                {
                    { 1, null, "Prueba 1 Tipo de Producto" },
                    { 2, null, "Prueba 2 Tipo de Producto" },
                    { 3, null, "Prueba 3 Tipo de Producto" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Unidades",
                columns: new[] { "ID_Unidad", "ID_Estado", "N_Unidad" },
                values: new object[,]
                {
                    { 2, null, "Unidad de Prueba 200" },
                    { 1, null, "Unidad de Prueba 100" },
                    { 3, null, "Unidad  dePrueba 300" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Ciudades",
                columns: new[] { "ID_Ciudad", "ID_Region", "N_Ciudad" },
                values: new object[,]
                {
                    { 219, 13, "Maipú" },
                    { 228, 13, "Puente Alto" },
                    { 227, 13, "Pudahuel" },
                    { 226, 13, "Providencia" },
                    { 225, 13, "Peñalolén" },
                    { 224, 13, "Peñaflor" },
                    { 223, 13, "Pedro Aguirre Cerda" },
                    { 87, 6, "Chépica" },
                    { 88, 6, "Chimbarongo" },
                    { 89, 6, "Codegua" },
                    { 90, 6, "Coltauco" },
                    { 91, 6, "Doñihue" },
                    { 92, 6, "Graneros" },
                    { 93, 6, "Gultro" },
                    { 229, 13, "Quilicura" },
                    { 94, 6, "La Punta" },
                    { 96, 6, "Lo Miranda" },
                    { 97, 6, "Machalí" },
                    { 98, 6, "Nancagua" },
                    { 99, 6, "Peralillo" },
                    { 100, 6, "Peumo" },
                    { 101, 6, "Pichidegua" },
                    { 102, 6, "Pichilemu" },
                    { 103, 6, "Quinta de Tilcoco" },
                    { 104, 6, "Rancagua" },
                    { 105, 6, "Rengo" },
                    { 106, 6, "Requínoa" },
                    { 107, 6, "San Fernando" },
                    { 108, 6, "San Francisco de Mostazal" },
                    { 95, 6, "Las Cabras" },
                    { 109, 6, "San Vicente de Tagua Tagua" },
                    { 230, 13, "Quillón" },
                    { 232, 13, "Quirihue" },
                    { 143, 8, "Los Álamos" },
                    { 142, 8, "Lebu" },
                    { 141, 8, "Laraquete" },
                    { 140, 8, "La Laja" },
                    { 139, 8, "Huépil" },
                    { 138, 8, "Hualqui" },
                    { 137, 8, "Hualpén" },
                    { 136, 8, "Curanilahue" },
                    { 135, 8, "Coronel" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Ciudades",
                columns: new[] { "ID_Ciudad", "ID_Region", "N_Ciudad" },
                values: new object[,]
                {
                    { 134, 8, "Concepción" },
                    { 133, 8, "Chiguayante" },
                    { 132, 8, "Cañete" },
                    { 131, 8, "Cabrero" },
                    { 231, 13, "Quinta Normal" },
                    { 130, 8, "Arauco" },
                    { 245, 13, "Vitacura" },
                    { 244, 13, "Valle Grande" },
                    { 243, 13, "Tiltil" },
                    { 242, 13, "Talagante" },
                    { 241, 13, "Santiago" },
                    { 240, 13, "San Ramón" },
                    { 239, 13, "San Miguel" },
                    { 238, 13, "San José de Maipo" },
                    { 237, 13, "San Joaquín" },
                    { 236, 13, "San Carlos" },
                    { 235, 13, "San Bernardo" },
                    { 234, 13, "Renca" },
                    { 233, 13, "Recoleta" },
                    { 246, 13, "Yungay" },
                    { 86, 5, "Viña del Mar" },
                    { 110, 6, "Santa Cruz" },
                    { 221, 13, "Ñuñoa" },
                    { 112, 7, "Colbún" },
                    { 113, 7, "Constitución" },
                    { 114, 7, "Culenar" },
                    { 115, 7, "Curicó" },
                    { 116, 7, "Hualañé" },
                    { 117, 7, "Linares" },
                    { 118, 7, "Longaví" },
                    { 119, 7, "Molina" },
                    { 120, 7, "Parral" },
                    { 121, 7, "Rauco" },
                    { 122, 7, "Retiro" },
                    { 123, 7, "Romeral" },
                    { 124, 7, "San Clemente" },
                    { 111, 7, "Cauquenes" },
                    { 125, 7, "San Clemente" },
                    { 127, 7, "Talca" },
                    { 128, 7, "Teno" },
                    { 129, 7, "Villa Alegre" },
                    { 189, 13, "Chamisero" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Ciudades",
                columns: new[] { "ID_Ciudad", "ID_Region", "N_Ciudad" },
                values: new object[,]
                {
                    { 188, 13, "Cerro Navia" },
                    { 187, 13, "Cerrillos" },
                    { 186, 13, "Calera de Tango" },
                    { 185, 13, "Bulnes" },
                    { 184, 13, "Buin" },
                    { 183, 13, "Bollenar" },
                    { 182, 13, "Batuco" },
                    { 181, 13, "Alto Jahuel" },
                    { 178, 12, "Puerto Natales" },
                    { 126, 7, "San Javier" },
                    { 222, 13, "Paine" },
                    { 190, 13, "Chicureo" },
                    { 192, 13, "Chillán Viejo" },
                    { 220, 13, "Melipilla" },
                    { 177, 12, "Porvenir" },
                    { 218, 13, "Macul" },
                    { 217, 13, "Lo Prado" },
                    { 216, 13, "Lo Espejo" },
                    { 215, 13, "Lo Barnechea" },
                    { 214, 13, "Las Condes" },
                    { 213, 13, "Lampa" },
                    { 212, 13, "La Reina" },
                    { 211, 13, "La Pintana" },
                    { 210, 13, "La Islita" },
                    { 209, 13, "La Granja" },
                    { 208, 13, "La Florida" },
                    { 191, 13, "Chillán" },
                    { 207, 13, "La Cisterna" },
                    { 205, 13, "Independencia" },
                    { 204, 13, "Huechuraba" },
                    { 203, 13, "Hospital" },
                    { 202, 13, "Estación Central" },
                    { 201, 13, "El Principal" },
                    { 200, 13, "El Monte" },
                    { 199, 13, "El Bosque" },
                    { 198, 13, "Curacaví" },
                    { 197, 13, "Conchalí" },
                    { 196, 13, "Colina" },
                    { 195, 13, "Coihueco" },
                    { 194, 13, "Coelemu" },
                    { 193, 13, "Ciudad del Valle" },
                    { 206, 13, "Isla de Maipo" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Ciudades",
                columns: new[] { "ID_Ciudad", "ID_Region", "N_Ciudad" },
                values: new object[,]
                {
                    { 85, 5, "Villa Alemana" },
                    { 84, 5, "Santo Domingo" },
                    { 83, 5, "Santa María" },
                    { 31, 9, "Cajón" },
                    { 30, 9, "Angol" },
                    { 4, 2, "Antofagasta" },
                    { 5, 2, "Calama" },
                    { 6, 2, "Mejillones" },
                    { 7, 2, "San Pedro" },
                    { 8, 2, "Taltal" },
                    { 9, 2, "Tocopilla" },
                    { 156, 10, "Alerce" },
                    { 157, 10, "Ancud" },
                    { 158, 10, "Calbuco" },
                    { 159, 10, "Castro" },
                    { 160, 10, "Chaitén" },
                    { 32, 9, "Carahue" },
                    { 161, 10, "Chonchi" },
                    { 163, 10, "Fresia" },
                    { 164, 10, "Frutillar" },
                    { 10, 3, "Caldera" },
                    { 11, 3, "Chañaral" },
                    { 12, 3, "Copiapó" },
                    { 13, 3, "Diego de Almagro" },
                    { 14, 3, "El Salvador" },
                    { 15, 3, "Huasco" },
                    { 16, 3, "Tierra Amarilla" },
                    { 17, 3, "Vallenar" },
                    { 165, 10, "Llanquihue" },
                    { 166, 10, "Los Muermos" },
                    { 167, 10, "Osorno" },
                    { 162, 10, "Dalcahue" },
                    { 168, 10, "Puerto Montt" },
                    { 33, 9, "Collipulli" },
                    { 35, 9, "Freire" },
                    { 50, 9, "Villarrica" },
                    { 49, 9, "Vilcún" },
                    { 256, 15, "Putre" },
                    { 255, 15, "Arica" },
                    { 48, 9, "Victoria" },
                    { 47, 9, "Traiguén" },
                    { 46, 9, "Temuco" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Ciudades",
                columns: new[] { "ID_Ciudad", "ID_Region", "N_Ciudad" },
                values: new object[,]
                {
                    { 45, 9, "Renaico" },
                    { 44, 9, "Purén" },
                    { 43, 9, "Pucón" },
                    { 42, 9, "Pitrufquén" },
                    { 41, 9, "Padre Las Casas" },
                    { 40, 9, "Nueva Imperial" },
                    { 34, 9, "Cunco" },
                    { 39, 9, "Loncoche" },
                    { 37, 9, "Labranza" },
                    { 254, 14, "Valdivia" },
                    { 253, 14, "San José de la Mariquina" },
                    { 252, 14, "Río Bueno" },
                    { 251, 14, "Panguipulli" },
                    { 250, 14, "Paillaco" },
                    { 249, 14, "Lanco" },
                    { 248, 14, "La Unión" },
                    { 247, 14, "Futrono" },
                    { 1, 1, "Alto Hospicio" },
                    { 2, 1, "Iquique" },
                    { 3, 1, "Pozo Almonte" },
                    { 36, 9, "Gorbea" },
                    { 38, 9, "Lautaro" },
                    { 169, 10, "Puerto Varas" },
                    { 170, 10, "Purranque" },
                    { 171, 10, "Quellón" },
                    { 55, 5, "Casablanca" },
                    { 56, 5, "Catemu" },
                    { 57, 5, "Concón" },
                    { 58, 5, "El Melón" },
                    { 59, 5, "El Quisco" },
                    { 60, 5, "El Tabo" },
                    { 61, 5, "Hanga Roa" },
                    { 62, 5, "Hijuelas" },
                    { 63, 5, "La Calera" },
                    { 64, 5, "La Cruz" },
                    { 65, 5, "La Ligua" },
                    { 66, 5, "Las Cruces" },
                    { 67, 5, "Las Ventanas" },
                    { 54, 5, "Cartagena" },
                    { 68, 5, "Limache" },
                    { 70, 5, "Los Andes" },
                    { 71, 5, "Nogales" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Ciudades",
                columns: new[] { "ID_Ciudad", "ID_Region", "N_Ciudad" },
                values: new object[,]
                {
                    { 72, 5, "Olmué" },
                    { 73, 5, "Placilla de Peñuelas" },
                    { 74, 5, "Puchuncaví" },
                    { 75, 5, "Putaendo" },
                    { 76, 5, "Quillota" },
                    { 77, 5, "Quilpué" },
                    { 78, 5, "Quintero" },
                    { 79, 5, "Rinconada" },
                    { 80, 5, "San Antonio" },
                    { 81, 5, "San Esteban" },
                    { 82, 5, "San Felipe" },
                    { 69, 5, "Llaillay" },
                    { 53, 5, "Calle Larga" },
                    { 52, 5, "Cabildo" },
                    { 51, 5, "Algarrobo" },
                    { 172, 10, "Río Negro" },
                    { 173, 11, "Chile Chico" },
                    { 18, 4, "Andacollo" },
                    { 19, 4, "Combarbalá" },
                    { 20, 4, "El Palqui" },
                    { 21, 4, "Illapel" },
                    { 22, 4, "La Serena" },
                    { 23, 4, "Los Vilos" },
                    { 24, 4, "Monte Patria" },
                    { 25, 4, "Ovalle" },
                    { 26, 4, "Punitaqui" },
                    { 27, 4, "Salamanca" },
                    { 28, 4, "Tongoy" },
                    { 29, 4, "Vicuña" },
                    { 174, 11, "Cochrane" },
                    { 175, 11, "Coyhaique" },
                    { 176, 11, "Puerto Aysén" },
                    { 155, 8, "Yumbel" },
                    { 154, 8, "Tomé" },
                    { 153, 8, "Talcahuano" },
                    { 152, 8, "Santa Juana" },
                    { 151, 8, "Santa Bárbara" },
                    { 150, 8, "San Pedro de la Paz" },
                    { 149, 8, "Penco" },
                    { 148, 8, "Nacimiento" },
                    { 147, 8, "Mulchén" },
                    { 146, 8, "Monte Águila" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Ciudades",
                columns: new[] { "ID_Ciudad", "ID_Region", "N_Ciudad" },
                values: new object[,]
                {
                    { 145, 8, "Lota" },
                    { 144, 8, "Los Ángeles" },
                    { 179, 12, "Puerto Williams" },
                    { 180, 12, "Punta Arenas" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Clientes_Proveedores",
                columns: new[] { "ID_Cliente_Proveedor", "Direccion", "Direccion_Correo", "Fecha_Ingreso", "Giro", "ID_Ciudad", "ID_Comuna", "ID_Condicion_Venta", "ID_Estado", "ID_Pais", "ID_Region", "ID_Tipo_Cliente_Proveedor", "ID_Usuario", "Monto_Credito", "Movil", "N_Cliente_Proveedor", "Observaciones", "Razon_Social", "Rut", "Telefono", "Ult_Actualizacion" },
                values: new object[] { 1, "Direccion de prueba 1", "prueba@correo1.com", new DateTime(2021, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), "Prueba de Giro", 10, 10, 1, 1, 10, 10, 1, "Prueba de nombre", 40000.0, "987654321", "Prueba 1 Cliente o Proveedor", "prueba de una observacion, no mirar", "Prueba de razon social", "12345679", "123456789", new DateTime(2021, 3, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Comunas",
                columns: new[] { "ID_Comuna", "ID_Region", "N_Comuna" },
                values: new object[,]
                {
                    { 12206, 12, "LAGUNA BLANCA" },
                    { 16301, 13, "PUENTE ALTO" },
                    { 16165, 13, "EL BOSQUE" },
                    { 16164, 13, "LO ESPEJO" },
                    { 16163, 13, "SAN JOAQUIN" },
                    { 16162, 13, "PEDRO AGUIRRE CERDA" },
                    { 16154, 13, "LA PINTANA" },
                    { 16153, 13, "SAN RAMON" },
                    { 16131, 13, "LA GRANJA" },
                    { 16110, 13, "LA CISTERNA" },
                    { 16106, 13, "SAN MIGUEL" },
                    { 15161, 13, "LO BARNECHEA" },
                    { 15160, 13, "VITACURA" },
                    { 15152, 13, "PENALOLEN" },
                    { 15151, 13, "MACUL" },
                    { 15132, 13, "LA REINA" },
                    { 15128, 13, "LA FLORIDA" },
                    { 15108, 13, "LAS CONDES" },
                    { 15105, 13, "NUNOA" },
                    { 10201, 10, "OSORNO" },
                    { 10202, 10, "SAN PABLO" },
                    { 10203, 10, "PUERTO OCTAY" },
                    { 10204, 10, "PUYEHUE" },
                    { 10205, 10, "RIO NEGRO" },
                    { 10206, 10, "PURRANQUE" },
                    { 10207, 10, "SAN JUAN DE LA COSTA" },
                    { 10301, 10, "PUERTO MONTT" },
                    { 10302, 10, "COCHAMO" },
                    { 10303, 10, "PUERTO VARAS" },
                    { 10304, 10, "FRESIA" },
                    { 16302, 13, "PIRQUE" },
                    { 16303, 13, "SAN JOSE DE MAIPO" },
                    { 16401, 13, "SAN BERNARDO" },
                    { 16402, 13, "CALERA DE TANGO" },
                    { 9208, 9, "NUEVA IMPERIAL" },
                    { 9209, 9, "CARAHUE" },
                    { 9210, 9, "SAAVEDRA" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Comunas",
                columns: new[] { "ID_Comuna", "ID_Region", "N_Comuna" },
                values: new object[,]
                {
                    { 9211, 9, "PITRUFQUEN" },
                    { 9212, 9, "GORBEA" },
                    { 9213, 9, "TOLTEN" },
                    { 9214, 9, "LONCOCHE" },
                    { 9215, 9, "VILLARRICA" },
                    { 9216, 9, "PUCON" },
                    { 9217, 9, "MELIPEUCO" },
                    { 9218, 9, "CURARREHUE" },
                    { 9219, 9, "TEODORO SCHMIDT" },
                    { 9220, 9, "PADRE LAS CASAS" },
                    { 9221, 9, "CHOLCHOL" },
                    { 10305, 10, "FRUTILLAR" },
                    { 1106, 15, "CAMARONES" },
                    { 10112, 14, "LAGO RANCO" },
                    { 10111, 14, "RIO BUENO" },
                    { 10110, 14, "PAILLACO" },
                    { 10109, 14, "LA UNION" },
                    { 10108, 14, "PANGUIPULLI" },
                    { 10107, 14, "MAFIL" },
                    { 10106, 14, "CORRAL" },
                    { 10105, 14, "FUTRONO" },
                    { 10104, 14, "LOS LAGOS" },
                    { 10103, 14, "LANCO" },
                    { 10102, 14, "MARIQUINA" },
                    { 10101, 14, "VALDIVIA" },
                    { 16404, 13, "PAINE" },
                    { 16403, 13, "BUIN" },
                    { 1101, 15, "ARICA" },
                    { 10306, 10, "LLANQUIHUE" },
                    { 10307, 10, "MAULLIN" },
                    { 10308, 10, "LOS MUERMOS" },
                    { 14157, 13, "ESTACION CENTRAL" },
                    { 14156, 13, "CERRO NAVIA" },
                    { 14155, 13, "LO PRADO" },
                    { 14127, 13, "CONCHALI" },
                    { 14114, 13, "QUILICURA" },
                    { 14113, 13, "RENCA" },
                    { 14111, 13, "PUDAHUEL" },
                    { 14109, 13, "MAIPU" },
                    { 14107, 13, "QUINTA NORMAL" },
                    { 13167, 13, "INDEPENDENCIA" },
                    { 13159, 13, "RECOLETA" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Comunas",
                columns: new[] { "ID_Comuna", "ID_Region", "N_Comuna" },
                values: new object[,]
                {
                    { 13135, 13, "SANTIAGO SUR" },
                    { 13134, 13, "SANTIAGO OESTE" },
                    { 13101, 13, "SANTIAGO" },
                    { 14158, 13, "HUECHURABA" },
                    { 11201, 11, "CHILE CHICO" },
                    { 11301, 11, "COCHRANE" },
                    { 11302, 11, "OHIGGINS" },
                    { 11303, 11, "TORTEL" },
                    { 11401, 11, "COYHAIQUE" },
                    { 11402, 11, "LAGO VERDE" },
                    { 9207, 9, "GALVARINO" },
                    { 12401, 12, "CABO DE HORNOS" },
                    { 12304, 12, "TIMAUKEL" },
                    { 12302, 12, "PRIMAVERA" },
                    { 12101, 12, "NATALES" },
                    { 12103, 12, "TORRES DEL PAINE" },
                    { 12202, 12, "RIO VERDE" },
                    { 12204, 12, "SAN GREGORIO" },
                    { 12205, 12, "PUNTA ARENAS" },
                    { 11203, 11, "RIO IBANEZ" },
                    { 12301, 12, "PORVENIR" },
                    { 14166, 13, "CERRILLOS" },
                    { 14202, 13, "LAMPA" },
                    { 10309, 10, "CALBUCO" },
                    { 10401, 10, "CASTRO" },
                    { 10402, 10, "CHONCHI" },
                    { 10403, 10, "QUEILEN" },
                    { 10404, 10, "QUELLON" },
                    { 10405, 10, "PUQUELDON" },
                    { 10406, 10, "ANCUD" },
                    { 10407, 10, "QUEMCHI" },
                    { 10408, 10, "DALCAHUE" },
                    { 10410, 10, "CURACO DE VELEZ" },
                    { 10415, 10, "QUINCHAO" },
                    { 10501, 10, "CHAITEN" },
                    { 10502, 10, "HUALAIHUE" },
                    { 10503, 10, "FUTALEUFU" },
                    { 14201, 13, "COLINA" },
                    { 10504, 10, "PALENA" },
                    { 14605, 13, "ALHUE" },
                    { 14604, 13, "SAN PEDRO" },
                    { 14603, 13, "CURACAVI" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Comunas",
                columns: new[] { "ID_Comuna", "ID_Region", "N_Comuna" },
                values: new object[,]
                {
                    { 11101, 11, "AYSEN" },
                    { 11102, 11, "CISNES" },
                    { 11104, 11, "GUAITECAS" },
                    { 14602, 13, "MARIA PINTO" },
                    { 14601, 13, "MELIPILLA" },
                    { 14505, 13, "PADRE HURTADO" },
                    { 14504, 13, "PENAFLOR" },
                    { 14503, 13, "EL MONTE" },
                    { 14502, 13, "ISLA DE MAIPO" },
                    { 14501, 13, "TALAGANTE" },
                    { 14203, 13, "TIL-TIL" },
                    { 15103, 13, "PROVIDENCIA" },
                    { 9206, 9, "PERQUENCO" },
                    { 8114, 8, "SAN IGNACIO" },
                    { 9204, 9, "CUNCO" },
                    { 5701, 5, "LOS ANDES" },
                    { 5606, 5, "LLAY-LLAY" },
                    { 5605, 5, "SANTA MARIA" },
                    { 5604, 5, "PUTAENDO" },
                    { 5603, 5, "CATEMU" },
                    { 5602, 5, "PANQUEHUE" },
                    { 5601, 5, "SAN FELIPE" },
                    { 5507, 5, "OLMUE" },
                    { 5506, 5, "LIMACHE" },
                    { 5505, 5, "LA CRUZ" },
                    { 5702, 5, "CALLE LARGA" },
                    { 5504, 5, "LA CALERA" },
                    { 5502, 5, "NOGALES" },
                    { 5501, 5, "QUILLOTA" },
                    { 5406, 5, "ALGARROBO" },
                    { 5405, 5, "EL QUISCO" },
                    { 5404, 5, "EL TABO" },
                    { 5403, 5, "CARTAGENA" },
                    { 5402, 5, "SANTO DOMINGO" },
                    { 5401, 5, "SAN ANTONIO" },
                    { 5309, 5, "CONCON" },
                    { 5308, 5, "JUAN FERNANDEZ" },
                    { 5503, 5, "HIJUELAS" },
                    { 5703, 5, "SAN ESTEBAN" },
                    { 5704, 5, "RINCONADA" },
                    { 6101, 6, "RANCAGUA" },
                    { 6207, 6, "PALMILLA" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Comunas",
                columns: new[] { "ID_Comuna", "ID_Region", "N_Comuna" },
                values: new object[,]
                {
                    { 6206, 6, "LOLOL" },
                    { 6205, 6, "SANTA CRUZ" },
                    { 6204, 6, "PLACILLA" },
                    { 6203, 6, "NANCAGUA" },
                    { 6202, 6, "CHIMBARONGO" },
                    { 6201, 6, "SAN FERNANDO" },
                    { 6117, 6, "QUINTA DE TILCOCO" },
                    { 6116, 6, "COINCO" },
                    { 9205, 9, "LAUTARO" },
                    { 6114, 6, "OLIVAR" },
                    { 6113, 6, "REQUINOA" },
                    { 6112, 6, "RENGO" },
                    { 6111, 6, "PICHIDEGUA" },
                    { 6110, 6, "SAN VICENTE" },
                    { 6109, 6, "LAS CABRAS" },
                    { 6108, 6, "PEUMO" },
                    { 6107, 6, "CODEGUA" },
                    { 6106, 6, "COLTAUCO" },
                    { 6105, 6, "DONIHUE" },
                    { 6104, 6, "SAN FRANCISCO DE MOSTAZAL" },
                    { 6103, 6, "GRANEROS" },
                    { 6102, 6, "MACHALI" },
                    { 5307, 5, "PUCHUNCAVI" },
                    { 6208, 6, "PERALILLO" },
                    { 5306, 5, "QUINTERO" },
                    { 5304, 5, "QUILPUE" },
                    { 3301, 3, "VALLENAR" },
                    { 3203, 3, "TIERRA AMARILLA" },
                    { 3202, 3, "CALDERA" },
                    { 3201, 3, "COPIAPO" },
                    { 3102, 3, "DIEGO DE ALMAGRO" },
                    { 3101, 3, "CHANARAL" },
                    { 2303, 2, "SAN PEDRO DE ATACAMA" },
                    { 2302, 2, "OLLAGUE" },
                    { 2301, 2, "CALAMA" },
                    { 2206, 2, "SIERRA GORDA" },
                    { 3302, 3, "FREIRINA" },
                    { 2203, 2, "MEJILLONES" },
                    { 2201, 2, "ANTOFAGASTA" },
                    { 2103, 2, "MARIA ELENA" },
                    { 2101, 2, "TOCOPILLA" },
                    { 1211, 1, "ALTO HOSPICIO" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Comunas",
                columns: new[] { "ID_Comuna", "ID_Region", "N_Comuna" },
                values: new object[,]
                {
                    { 1210, 1, "COLCHANE" },
                    { 1208, 1, "CAMINA" },
                    { 1206, 1, "HUARA" },
                    { 1204, 1, "POZO ALMONTE" },
                    { 1203, 1, "PICA" },
                    { 1201, 1, "IQUIQUE" },
                    { 2202, 2, "TALTAL" },
                    { 3303, 3, "HUASCO" },
                    { 3304, 3, "ALTO DEL CARMEN" },
                    { 4101, 4, "LA SERENA" },
                    { 5303, 5, "VILLA ALEMANA" },
                    { 5302, 5, "VINA DEL MAR" },
                    { 5301, 5, "VALPARAISO" },
                    { 5205, 5, "PAPUDO" },
                    { 5204, 5, "ZAPALLAR" },
                    { 5203, 5, "CABILDO" },
                    { 5202, 5, "PETORCA" },
                    { 5201, 5, "LA LIGUA" },
                    { 5101, 5, "ISLA DE PASCUA" },
                    { 4304, 4, "CANELA" },
                    { 4303, 4, "LOS VILOS" },
                    { 4302, 4, "SALAMANCA" },
                    { 4301, 4, "ILLAPEL" },
                    { 4206, 4, "RIO HURTADO" },
                    { 4205, 4, "COMBARBALA" },
                    { 4204, 4, "PUNITAQUI" },
                    { 4203, 4, "MONTE PATRIA" },
                    { 4201, 4, "OVALLE" },
                    { 4106, 4, "PAIHUANO" },
                    { 4105, 4, "VICUNA" },
                    { 4104, 4, "ANDACOLLO" },
                    { 4103, 4, "COQUIMBO" },
                    { 4102, 4, "LA HIGUERA" },
                    { 5305, 5, "CASABLANCA" },
                    { 6209, 6, "CHEPICA" },
                    { 6115, 6, "MALLOA" },
                    { 6301, 6, "PICHILEMU" },
                    { 8401, 8, "LOS ANGELES" },
                    { 8307, 8, "TIRUA" },
                    { 8306, 8, "CONTULMO" },
                    { 8305, 8, "CANETE" },
                    { 8304, 8, "LOS ALAMOS" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Comunas",
                columns: new[] { "ID_Comuna", "ID_Region", "N_Comuna" },
                values: new object[,]
                {
                    { 8303, 8, "LEBU" },
                    { 8302, 8, "CURANILAHUE" },
                    { 8301, 8, "ARAUCO" },
                    { 8212, 8, "HUALPEN" },
                    { 8211, 8, "CHIGUAYANTE" },
                    { 8402, 8, "SANTA BARBARA" },
                    { 8210, 8, "SAN PEDRO DE LA PAZ" },
                    { 6214, 6, "PUMANQUE" },
                    { 8207, 8, "CORONEL" },
                    { 8206, 8, "TALCAHUANO" },
                    { 8205, 8, "TOME" },
                    { 8204, 8, "FLORIDA" },
                    { 8203, 8, "HUALQUI" },
                    { 8202, 8, "PENCO" },
                    { 8201, 8, "CONCEPCION" },
                    { 8121, 8, "CHILLAN VIEJO" },
                    { 8120, 8, "COELEMU" },
                    { 8209, 8, "SANTA JUANA" },
                    { 8403, 8, "LAJA" },
                    { 8404, 8, "QUILLECO" },
                    { 8405, 8, "NACIMIENTO" },
                    { 9203, 9, "FREIRE" },
                    { 9202, 9, "VILCUN" },
                    { 9201, 9, "TEMUCO" },
                    { 9111, 9, "LONQUIMAY" },
                    { 9110, 9, "CURACAUTIN" },
                    { 9109, 9, "VICTORIA" },
                    { 9108, 9, "LUMACO" },
                    { 9107, 9, "TRAIGUEN" },
                    { 9106, 9, "ERCILLA" },
                    { 9105, 9, "COLLIPULLI" },
                    { 9104, 9, "RENAICO" },
                    { 9103, 9, "LOS SAUCES" },
                    { 9102, 9, "PUREN" },
                    { 9101, 9, "ANGOL" },
                    { 8414, 8, "ALTO BIOBIO" },
                    { 8413, 8, "ANTUCO" },
                    { 8412, 8, "TUCAPEL" },
                    { 8411, 8, "SAN ROSENDO" },
                    { 8410, 8, "CABRERO" },
                    { 8409, 8, "YUMBEL" },
                    { 8408, 8, "QUILACO" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Comunas",
                columns: new[] { "ID_Comuna", "ID_Region", "N_Comuna" },
                values: new object[,]
                {
                    { 8407, 8, "MULCHEN" },
                    { 8406, 8, "NEGRETE" },
                    { 8119, 8, "RANQUIL" },
                    { 8118, 8, "EL CARMEN" },
                    { 8208, 8, "LOTA" },
                    { 8116, 8, "YUNGAY" },
                    { 7209, 7, "EMPEDRADO" },
                    { 7208, 7, "CONSTITUCION" },
                    { 7207, 7, "CUREPTO" },
                    { 7206, 7, "MAULE" },
                    { 7205, 7, "PENCAHUE" },
                    { 7204, 7, "RIO CLARO" },
                    { 7203, 7, "PELARCO" },
                    { 7202, 7, "SAN CLEMENTE" },
                    { 7201, 7, "TALCA" },
                    { 7109, 7, "SAGRADA FAMILIA" },
                    { 8117, 8, "PEMUCO" },
                    { 7107, 7, "HUALANE" },
                    { 7106, 7, "VICHUQUEN" },
                    { 7105, 7, "LICANTEN" },
                    { 7104, 7, "RAUCO" },
                    { 7103, 7, "ROMERAL" },
                    { 7102, 7, "TENO" },
                    { 7101, 7, "CURICO" },
                    { 6306, 6, "PAREDONES" },
                    { 6305, 6, "MARCHIGUE" },
                    { 6304, 6, "LA ESTRELLA" },
                    { 6303, 6, "LITUECHE" },
                    { 6302, 6, "NAVIDAD" },
                    { 7210, 7, "SAN RAFAEL" },
                    { 7301, 7, "LINARES" },
                    { 7108, 7, "MOLINA" },
                    { 7303, 7, "COLBUN" },
                    { 7302, 7, "YERBAS BUENAS" },
                    { 8115, 8, "QUILLON" },
                    { 1301, 15, "PUTRE" },
                    { 8113, 8, "BULNES" },
                    { 8112, 8, "SAN NICOLAS" },
                    { 8111, 8, "SAN FABIAN" },
                    { 8110, 8, "NIQUEN" },
                    { 8109, 8, "SAN CARLOS" },
                    { 8108, 8, "TREHUACO" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Comunas",
                columns: new[] { "ID_Comuna", "ID_Region", "N_Comuna" },
                values: new object[,]
                {
                    { 8107, 8, "COBQUECURA" },
                    { 8106, 8, "PORTEZUELO" },
                    { 8105, 8, "NINHUE" },
                    { 1302, 15, "GENERAL LAGOS" },
                    { 8103, 8, "COIHUECO" },
                    { 8102, 8, "PINTO" },
                    { 8101, 8, "CHILLAN" },
                    { 7403, 7, "CHANCO" },
                    { 7402, 7, "PELLUHUE" },
                    { 7401, 7, "CAUQUENES" },
                    { 7310, 7, "SAN JAVIER" },
                    { 7309, 7, "VILLA ALEGRE" },
                    { 7306, 7, "RETIRO" },
                    { 7305, 7, "PARRAL" },
                    { 7304, 7, "LONGAVI" },
                    { 8104, 8, "QUIRIHUE" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Marca",
                columns: new[] { "ID_Marca", "ID_Estado", "N_Marca" },
                values: new object[] { 1, 1, "Nombre Marca 1" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Perfiles",
                columns: new[] { "ID_Perfil", "ID_Estado", "N_Perfil" },
                values: new object[,]
                {
                    { 4, 1, "Vendedor" },
                    { 2, 1, "Bodeguero" },
                    { 1, 1, "Administrador" },
                    { 3, 1, "Cajero" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Tipo_Cliente_Proveedor",
                columns: new[] { "ID_Tipo_Cliente_Proveedor", "ID_Estado", "N_Tipo_Cliente_Proveedor" },
                values: new object[,]
                {
                    { 1, 1, "Prueba 1 Tipo de Cliente o Proveedor" },
                    { 3, 1, "Prueba 3 Tipo de Cliente o Proveedor" },
                    { 2, 1, "Prueba 2 Tipo de Cliente o Proveedor" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Tipo_Descuentos",
                columns: new[] { "ID_Tipo_Descuento", "ID_Estado", "N_Tipo_Descuento" },
                values: new object[,]
                {
                    { 1, 1, "Prueba 1 Tipo de Descuento" },
                    { 2, 1, "Prueba 2 Tipo de Descuento" },
                    { 3, 1, "Prueba 3 Tipo de Descuento" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Tipo_Documentos",
                columns: new[] { "ID_Tipo_Documento", "ID_Estado", "N_Tipo_Documento" },
                values: new object[,]
                {
                    { 3, 1, "Prueba 3 Tipo de Documento" },
                    { 2, 1, "Prueba 2 Tipo de Documento" },
                    { 1, 1, "Prueba 1 Tipo de Documento" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Tipo_Empresa",
                columns: new[] { "ID_Tipo_Empresa", "ID_Estado", "N_Tipo_Empresa" },
                values: new object[] { 1, 1, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Tipo_Inventario",
                columns: new[] { "ID_Tipo_Inventario", "ID_Estado", "N_Tipo_Inventario" },
                values: new object[,]
                {
                    { 2, 1, "Prueba 2 Tipo de Inventario" },
                    { 3, 1, "Prueba 3 Tipo de Inventario" },
                    { 1, 1, "Prueba 1 Tipo de Inventario" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Tipo_Pago",
                columns: new[] { "ID_Tipo_Pago", "ID_Estado", "N_Tipo_Pago" },
                values: new object[,]
                {
                    { 1, 1, "Prueba 1 Tipo de Pago" },
                    { 2, 1, "Prueba 2 Tipo de Pago" },
                    { 3, 1, "Prueba 3 Tipo de Pago" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Ubicaciones",
                columns: new[] { "ID_Ubicacion", "ID_Bodega", "ID_Estado", "N_Ubicacion" },
                values: new object[,]
                {
                    { 1, 1, 1, "Ubicacion de Prueba 1" },
                    { 2, 2, 1, "Ubicacion de Prueba 2" },
                    { 3, 3, 1, "Ubicacion de Prueba 3" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Empresas",
                columns: new[] { "ID_Empresa", "Direccion", "Direccion_Correo", "Fecha_Antiguedad", "Giro", "ID_Ciudad", "ID_Comuna", "ID_Estado", "ID_Pais", "ID_Region", "ID_Tipo_Empresa", "Movil", "N_Empresa", "Observaciones", "Razon_Social", "Rut", "Telefono1", "Telefono2", "Web" },
                values: new object[] { 1, "Calle 123", "Correo@Correo.cl", new DateTime(1990, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "asdada", 3, 1101, 1, 2, 5, 1, "987654321", "EMPRESA", "Esta es una observacion", "Algo", "123456789-K", "123456789", "24681012", "www.empresa.cl" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Productos",
                columns: new[] { "ID_Producto", "Codigo_Barra", "Codigo_Interno", "Codigo_Parte", "Codigo_Proveedor", "Descripcion", "Fecha_Creacion", "ID_Cliente_Proveedor", "ID_Estado", "ID_Familia", "ID_Marca", "ID_SubFamilia", "ID_Tipo_Descuento", "ID_Tipo_Inventario", "ID_Tipo_Material", "ID_Tipo_Producto", "ID_Unidad", "ID_Usuario", "N_Producto", "Observaciones", "Precio_Venta", "Precio_Web", "Ult_Actualizacion", "Ult_Inventario", "Ult_Reposicion", "Valor_Compra", "Valor_Costo", "Valor_Descuento", "Valor_Flete", "Valor_Margen" },
                values: new object[] { 1, 12300000L, 45600000L, "1000001", "2000002", "Este es una Descripción de prueba", new DateTime(2021, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, "Id Prueba1", "Prueba Producto Alpha", "Esta es una Observación de prueba", 36000.0, 16000.0, new DateTime(2021, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), 50000.0, 30000.0, 500.0, 10000.0, 20000.0 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Sucursales",
                columns: new[] { "ID_Sucursal", "Direccion", "Direccion_Correo", "ID_Ciudad", "ID_Comuna", "ID_Empresa", "ID_Estado", "ID_Pais", "ID_Region", "Movil1", "Movil2", "N_Sucursal", "Telefono1", "Telefono2" },
                values: new object[] { 1, "Calle 123", "Correo@Correo.CL", 3, 1101, 1, 1, 2, 5, "987654321", "121086420", "Sucursal", "123456789", "24681012" });

            migrationBuilder.CreateIndex(
                name: "IX_Bodegas_ID_Estado",
                schema: "dbo",
                table: "Bodegas",
                column: "ID_Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Bodegas_ID_Sucursal",
                schema: "dbo",
                table: "Bodegas",
                column: "ID_Sucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_ID_Region",
                schema: "dbo",
                table: "Ciudades",
                column: "ID_Region");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Proveedores_ID_Estado",
                schema: "dbo",
                table: "Clientes_Proveedores",
                column: "ID_Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Comunas_ID_Region",
                schema: "dbo",
                table: "Comunas",
                column: "ID_Region");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_ID_Ciudad",
                schema: "dbo",
                table: "Empresas",
                column: "ID_Ciudad");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_ID_Comuna",
                schema: "dbo",
                table: "Empresas",
                column: "ID_Comuna");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_ID_Estado",
                schema: "dbo",
                table: "Empresas",
                column: "ID_Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_ID_Pais",
                schema: "dbo",
                table: "Empresas",
                column: "ID_Pais");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_ID_Region",
                schema: "dbo",
                table: "Empresas",
                column: "ID_Region");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_ID_Tipo_Empresa",
                schema: "dbo",
                table: "Empresas",
                column: "ID_Tipo_Empresa");

            migrationBuilder.CreateIndex(
                name: "IX_Familias_ID_Estado",
                schema: "dbo",
                table: "Familias",
                column: "ID_Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Marca_ID_Estado",
                schema: "dbo",
                table: "Marca",
                column: "ID_Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Perfiles_ID_Estado",
                schema: "dbo",
                table: "Perfiles",
                column: "ID_Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ID_Cliente_Proveedor",
                schema: "dbo",
                table: "Productos",
                column: "ID_Cliente_Proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ID_Estado",
                schema: "dbo",
                table: "Productos",
                column: "ID_Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ID_Familia",
                schema: "dbo",
                table: "Productos",
                column: "ID_Familia");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ID_Marca",
                schema: "dbo",
                table: "Productos",
                column: "ID_Marca");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ID_SubFamilia",
                schema: "dbo",
                table: "Productos",
                column: "ID_SubFamilia");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ID_Tipo_Descuento",
                schema: "dbo",
                table: "Productos",
                column: "ID_Tipo_Descuento");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ID_Tipo_Inventario",
                schema: "dbo",
                table: "Productos",
                column: "ID_Tipo_Inventario");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ID_Tipo_Material",
                schema: "dbo",
                table: "Productos",
                column: "ID_Tipo_Material");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ID_Tipo_Producto",
                schema: "dbo",
                table: "Productos",
                column: "ID_Tipo_Producto");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ID_Unidad",
                schema: "dbo",
                table: "Productos",
                column: "ID_Unidad");

            migrationBuilder.CreateIndex(
                name: "IX_Subfamilia_ID_Estado",
                schema: "dbo",
                table: "Subfamilia",
                column: "ID_Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Subfamilia_ID_Familia",
                schema: "dbo",
                table: "Subfamilia",
                column: "ID_Familia");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_ID_Ciudad",
                schema: "dbo",
                table: "Sucursales",
                column: "ID_Ciudad");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_ID_Comuna",
                schema: "dbo",
                table: "Sucursales",
                column: "ID_Comuna");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_ID_Empresa",
                schema: "dbo",
                table: "Sucursales",
                column: "ID_Empresa");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_ID_Estado",
                schema: "dbo",
                table: "Sucursales",
                column: "ID_Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_ID_Pais",
                schema: "dbo",
                table: "Sucursales",
                column: "ID_Pais");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_ID_Region",
                schema: "dbo",
                table: "Sucursales",
                column: "ID_Region");

            migrationBuilder.CreateIndex(
                name: "IX_Tipo_Cliente_Proveedor_ID_Estado",
                schema: "dbo",
                table: "Tipo_Cliente_Proveedor",
                column: "ID_Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Tipo_Descuentos_ID_Estado",
                schema: "dbo",
                table: "Tipo_Descuentos",
                column: "ID_Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Tipo_Documentos_ID_Estado",
                schema: "dbo",
                table: "Tipo_Documentos",
                column: "ID_Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Tipo_Empresa_ID_Estado",
                schema: "dbo",
                table: "Tipo_Empresa",
                column: "ID_Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Tipo_Inventario_ID_Estado",
                schema: "dbo",
                table: "Tipo_Inventario",
                column: "ID_Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Tipo_Material_ID_Estado",
                schema: "dbo",
                table: "Tipo_Material",
                column: "ID_Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Tipo_Pago_ID_Estado",
                schema: "dbo",
                table: "Tipo_Pago",
                column: "ID_Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Tipo_Productos_ID_Estado",
                schema: "dbo",
                table: "Tipo_Productos",
                column: "ID_Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Toma_inventario_ID_Estado",
                schema: "dbo",
                table: "Toma_inventario",
                column: "ID_Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Toma_inventario_ID_Producto",
                schema: "dbo",
                table: "Toma_inventario",
                column: "ID_Producto");

            migrationBuilder.CreateIndex(
                name: "IX_Ubicaciones_ID_Bodega",
                schema: "dbo",
                table: "Ubicaciones",
                column: "ID_Bodega");

            migrationBuilder.CreateIndex(
                name: "IX_Ubicaciones_ID_Estado",
                schema: "dbo",
                table: "Ubicaciones",
                column: "ID_Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_ID_Estado",
                schema: "dbo",
                table: "Unidades",
                column: "ID_Estado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Perfiles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Tipo_Cliente_Proveedor",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Tipo_Documentos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Tipo_Pago",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Toma_inventario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Ubicaciones",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Productos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Bodegas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Clientes_Proveedores",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Marca",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Subfamilia",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Tipo_Descuentos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Tipo_Inventario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Tipo_Material",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Tipo_Productos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Unidades",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Sucursales",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Familias",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Empresas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Ciudades",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Comunas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Paises",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Tipo_Empresa",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Regiones",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Estados",
                schema: "dbo");
        }
    }
}
