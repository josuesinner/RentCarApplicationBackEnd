using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentCarApplication.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(name: "Id_Cliente", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoTarjetaCR = table.Column<string>(name: "No_Tarjeta_CR", type: "nvarchar(max)", nullable: true),
                    LímiteCredito = table.Column<string>(name: "Límite_Credito", type: "nvarchar(max)", nullable: true),
                    TipoPersona = table.Column<string>(name: "Tipo_Persona", type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Combustibles",
                columns: table => new
                {
                    IdCombustible = table.Column<int>(name: "Id_Combustible", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combustibles", x => x.IdCombustible);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(name: "Id_Empleado", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TandaLabor = table.Column<string>(name: "Tanda_Labor", type: "nvarchar(max)", nullable: true),
                    PorcientoComision = table.Column<string>(name: "Porciento_Comision", type: "nvarchar(max)", nullable: true),
                    FechaIngreso = table.Column<DateTime>(name: "Fecha_Ingreso", type: "datetime2", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.IdEmpleado);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    IdMarca = table.Column<int>(name: "Id_Marca", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.IdMarca);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Vehiculos",
                columns: table => new
                {
                    IdTipoVehiculo = table.Column<int>(name: "Id_Tipo_Vehiculo", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Vehiculos", x => x.IdTipoVehiculo);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    IdModelo = table.Column<int>(name: "Id_Modelo", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.IdModelo);
                    table.ForeignKey(
                        name: "FK_Modelos_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id_Marca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    IdVehiculo = table.Column<int>(name: "Id_Vehiculo", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripción = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoChasis = table.Column<string>(name: "No_Chasis", type: "nvarchar(max)", nullable: true),
                    NoMotor = table.Column<string>(name: "No_Motor", type: "nvarchar(max)", nullable: true),
                    NoPlaca = table.Column<string>(name: "No_Placa", type: "nvarchar(max)", nullable: true),
                    TipoVehiculoId = table.Column<int>(name: "Tipo_VehiculoId", type: "int", nullable: false),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    ModeloId = table.Column<int>(type: "int", nullable: false),
                    CombustibleId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.IdVehiculo);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Combustibles_CombustibleId",
                        column: x => x.CombustibleId,
                        principalTable: "Combustibles",
                        principalColumn: "Id_Combustible",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id_Marca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Modelos_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelos",
                        principalColumn: "Id_Modelo");
                    table.ForeignKey(
                        name: "FK_Vehiculos_Tipo_Vehiculos_Tipo_VehiculoId",
                        column: x => x.TipoVehiculoId,
                        principalTable: "Tipo_Vehiculos",
                        principalColumn: "Id_Tipo_Vehiculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inspeccions",
                columns: table => new
                {
                    IdTransaccion = table.Column<int>(name: "Id_Transaccion", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiculoId = table.Column<int>(type: "int", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    TieneRalladuras = table.Column<bool>(name: "Tiene_Ralladuras", type: "bit", nullable: false),
                    CantidadCombustible = table.Column<string>(name: "Cantidad_Combustible", type: "nvarchar(max)", nullable: true),
                    Gomarespuesta = table.Column<bool>(name: "Goma_respuesta", type: "bit", nullable: false),
                    TieneGato = table.Column<bool>(name: "Tiene_Gato", type: "bit", nullable: false),
                    Roturascristal = table.Column<bool>(name: "Roturas_cristal", type: "bit", nullable: false),
                    IzqFrontal = table.Column<bool>(type: "bit", nullable: false),
                    DerFrontal = table.Column<bool>(type: "bit", nullable: false),
                    IzqTrasera = table.Column<bool>(type: "bit", nullable: false),
                    DerTrasera = table.Column<bool>(type: "bit", nullable: false),
                    Etc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspeccions", x => x.IdTransaccion);
                    table.ForeignKey(
                        name: "FK_Inspeccions_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id_Cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inspeccions_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id_Empleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inspeccions_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id_Vehiculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Renta_Devolucions",
                columns: table => new
                {
                    NoRenta = table.Column<int>(name: "No_Renta", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    VehiculoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    FechaRenta = table.Column<DateTime>(name: "Fecha_Renta", type: "datetime2", nullable: false),
                    FechaDevolucion = table.Column<DateTime>(name: "Fecha_Devolucion", type: "datetime2", nullable: false),
                    MontoDia = table.Column<string>(name: "Monto_Dia", type: "nvarchar(max)", nullable: true),
                    Cantidaddias = table.Column<int>(name: "Cantidad_dias", type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Devolucion = table.Column<bool>(type: "bit", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renta_Devolucions", x => x.NoRenta);
                    table.ForeignKey(
                        name: "FK_Renta_Devolucions_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id_Cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Renta_Devolucions_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id_Empleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Renta_Devolucions_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id_Vehiculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inspeccions_ClienteId",
                table: "Inspeccions",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspeccions_EmpleadoId",
                table: "Inspeccions",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspeccions_VehiculoId",
                table: "Inspeccions",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_MarcaId",
                table: "Modelos",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Renta_Devolucions_ClienteId",
                table: "Renta_Devolucions",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Renta_Devolucions_EmpleadoId",
                table: "Renta_Devolucions",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Renta_Devolucions_VehiculoId",
                table: "Renta_Devolucions",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_CombustibleId",
                table: "Vehiculos",
                column: "CombustibleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_MarcaId",
                table: "Vehiculos",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_ModeloId",
                table: "Vehiculos",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_Tipo_VehiculoId",
                table: "Vehiculos",
                column: "Tipo_VehiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inspeccions");

            migrationBuilder.DropTable(
                name: "Renta_Devolucions");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Combustibles");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Tipo_Vehiculos");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
