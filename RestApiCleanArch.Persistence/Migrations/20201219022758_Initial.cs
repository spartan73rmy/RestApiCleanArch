using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApiCleanArch.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enfermedad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    IdReport = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermedad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EtapaFenologica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    IdReport = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtapaFenologica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plaga",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    IdReport = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plaga", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reporte",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Lugar = table.Column<string>(nullable: false),
                    Productor = table.Column<string>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitud = table.Column<double>(nullable: false),
                    Ubicacion = table.Column<string>(nullable: false),
                    Predio = table.Column<string>(nullable: false),
                    Cultivo = table.Column<string>(nullable: false),
                    Observaciones = table.Column<string>(nullable: false),
                    Litros = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reporte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TokenDescargaArchivo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Token = table.Column<string>(nullable: false),
                    HashArchivo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenDescargaArchivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    NombreUsuario = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    HashedPassword = table.Column<string>(unicode: false, nullable: false),
                    TipoUsuario = table.Column<int>(nullable: false),
                    Confirmado = table.Column<bool>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    TokenConfirmacion = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    LockoutEnd = table.Column<DateTime>(nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    NormalizedEmail = table.Column<string>(maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false),
                    ApellidoPaterno = table.Column<string>(maxLength: 20, nullable: false),
                    ApellidoMaterno = table.Column<string>(maxLength: 20, nullable: false),
                    ImagenPerfil = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IdReport = table.Column<int>(nullable: false),
                    Unidad = table.Column<string>(nullable: false),
                    Cantidad = table.Column<double>(nullable: false),
                    NombreProducto = table.Column<string>(nullable: false),
                    IngredienteActivo = table.Column<string>(nullable: false),
                    Concentracion = table.Column<string>(nullable: false),
                    IntervaloSeguridad = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Reporte",
                        column: x => x.IdReport,
                        principalTable: "Reporte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReporteEnfermedad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IdReporte = table.Column<int>(nullable: false),
                    IdEnfermedad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReporteEnfermedad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReporteEnfermedad_Enfermedad_IdEnfermedad",
                        column: x => x.IdEnfermedad,
                        principalTable: "Enfermedad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReporteEnfermedad_Reporte_IdReporte",
                        column: x => x.IdReporte,
                        principalTable: "Reporte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReporteEtapaFenologica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IdReporte = table.Column<int>(nullable: false),
                    IdEtapaFenologica = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReporteEtapaFenologica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReporteEtapaFenologica_EtapaFenologica_IdEtapaFenologica",
                        column: x => x.IdEtapaFenologica,
                        principalTable: "EtapaFenologica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReporteEtapaFenologica_Reporte_IdReporte",
                        column: x => x.IdReporte,
                        principalTable: "Reporte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportePlaga",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IdReporte = table.Column<int>(nullable: false),
                    IdPlaga = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportePlaga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportePlaga_Plaga_IdPlaga",
                        column: x => x.IdPlaga,
                        principalTable: "Plaga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportePlaga_Reporte_IdReporte",
                        column: x => x.IdReporte,
                        principalTable: "Reporte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArchivoUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IdReporte = table.Column<int>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    Hash = table.Column<string>(nullable: false),
                    ContentType = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivoUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArchivoUsuario_Reporte",
                        column: x => x.IdReporte,
                        principalTable: "Reporte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArchivoUsuario_Usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioToken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IdUsuario = table.Column<int>(nullable: false),
                    RefreshToken = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioToken_Usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchivoUsuario_IdReporte",
                table: "ArchivoUsuario",
                column: "IdReporte");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivoUsuario_IdUsuario",
                table: "ArchivoUsuario",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Enfermedad_IdReport",
                table: "Enfermedad",
                column: "IdReport");

            migrationBuilder.CreateIndex(
                name: "IX_EtapaFenologica_IdReport",
                table: "EtapaFenologica",
                column: "IdReport");

            migrationBuilder.CreateIndex(
                name: "IX_Plaga_IdReport",
                table: "Plaga",
                column: "IdReport");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdReport",
                table: "Producto",
                column: "IdReport");

            migrationBuilder.CreateIndex(
                name: "IX_ReporteEnfermedad_IdEnfermedad",
                table: "ReporteEnfermedad",
                column: "IdEnfermedad");

            migrationBuilder.CreateIndex(
                name: "IX_ReporteEnfermedad_IdReporte",
                table: "ReporteEnfermedad",
                column: "IdReporte");

            migrationBuilder.CreateIndex(
                name: "IX_ReporteEtapaFenologica_IdEtapaFenologica",
                table: "ReporteEtapaFenologica",
                column: "IdEtapaFenologica");

            migrationBuilder.CreateIndex(
                name: "IX_ReporteEtapaFenologica_IdReporte",
                table: "ReporteEtapaFenologica",
                column: "IdReporte");

            migrationBuilder.CreateIndex(
                name: "IX_ReportePlaga_IdPlaga",
                table: "ReportePlaga",
                column: "IdPlaga");

            migrationBuilder.CreateIndex(
                name: "IX_ReportePlaga_IdReporte",
                table: "ReportePlaga",
                column: "IdReporte");

            migrationBuilder.CreateIndex(
                name: "IX_TokenDescargaArchivo_HashArchivo",
                table: "TokenDescargaArchivo",
                column: "HashArchivo");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_NombreUsuario",
                table: "Usuario",
                column: "NombreUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioToken_IdUsuario",
                table: "UsuarioToken",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioToken_RefreshToken",
                table: "UsuarioToken",
                column: "RefreshToken",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchivoUsuario");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "ReporteEnfermedad");

            migrationBuilder.DropTable(
                name: "ReporteEtapaFenologica");

            migrationBuilder.DropTable(
                name: "ReportePlaga");

            migrationBuilder.DropTable(
                name: "TokenDescargaArchivo");

            migrationBuilder.DropTable(
                name: "UsuarioToken");

            migrationBuilder.DropTable(
                name: "Enfermedad");

            migrationBuilder.DropTable(
                name: "EtapaFenologica");

            migrationBuilder.DropTable(
                name: "Plaga");

            migrationBuilder.DropTable(
                name: "Reporte");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
