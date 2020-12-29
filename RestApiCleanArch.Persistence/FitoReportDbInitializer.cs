using RestApiCleanArch.Domain.Entities;
using System.Linq;

namespace RestApiCleanArch.Persistence
{
    public class RestApiCleanArchDbInitializer
    {
        public static void Initialize(RestApiCleanArchDbContext context)
        {
            var initializer = new RestApiCleanArchDbInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(RestApiCleanArchDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Usuario.Any())
            {
                return; // Db has been seeded
            }
            SeedUsuario(context);
            SeedArchivoUsuario(context);
            SeedPlaga(context);
            SeedEnfermedad(context);
            SeedEtapaFenologica(context);
            SeedReporte(context);
        }

        private void SeedEnfermedad(RestApiCleanArchDbContext context)
        {
            var enfermedadades = new Enfermedad[]
            {
                new Enfermedad
                {
                    Nombre="Mancha negra (Cercospora purpura)"
                },
                new Enfermedad
                {
                    Nombre="Anillamiento del Pedúnculo"
                },
                new Enfermedad
                {
                    Nombre="Roña (Sphaceloma persea)",
                },
                new Enfermedad
                {
                    Nombre="Antracnosis (colletotrichum gloesporoides)",
                },
                new Enfermedad
                {
                    Nombre="Phytophthora cinnamomi",
                },
            };

            foreach (var enfermedad in enfermedadades)
            {
                context.Enfermedad.Add(enfermedad);
                context.SaveChanges();
            }
        }

        private void SeedEtapaFenologica(RestApiCleanArchDbContext context)
        {
            var etapaFenologica = new EtapaFenologica[]
            {
                new EtapaFenologica
                {
                    Nombre="Floracion"
                },
                new EtapaFenologica
                {
                    Nombre="Amarre"
                },
                new EtapaFenologica
                {
                    Nombre="Desarrollo vegetativo"
                },
                new EtapaFenologica
                {
                    Nombre="Llenado de fruto"
                },
                new EtapaFenologica
                {
                    Nombre="Yema inchada"
                },
            };

            foreach (var etapa in etapaFenologica)
            {
                context.EtapaFenologica.Add(etapa);
                context.SaveChanges();
            }
        }

        private void SeedPlaga(RestApiCleanArchDbContext context)
        {
            var plagas = new Plaga[]
            {
                new Plaga
                {
                    Nombre="Agallador del Aguacatero (Trioza anceps Tuthill)"
                },
                new Plaga
                {
                    Nombre="Barrenador de Ramas (Copturus aguacatae)"
                },
                new Plaga
                {
                    Nombre="Barrenador pequeño del hueso (Conotrachelus perseae)",
                },
                new Plaga
                {
                    Nombre="Araña roja",
                },
                new Plaga
                {
                    Nombre="Trips",
                },
            };

            foreach (var plaga in plagas)
            {
                context.Plaga.Add(plaga);
                context.SaveChanges();
            }
        }

        private void SeedArchivoUsuario(RestApiCleanArchDbContext context)
        {
            var materialApoyo = new Archivo[]
            {
                new Archivo
                {
                    // Id = 1,
                    ContentType = "application/pdf",
                    Hash = "123",
                    IdUsuario = 1,
                    Nombre = "NombreArchivo.pdf"
                },
                new Archivo
                {
                    // Id = 2,
                    ContentType = "image/png",
                    Hash = "133",
                    IdUsuario = 2,
                    Nombre = "NombreArchivo.png"
                },
                new Archivo
                {
                    // Id = 3,
                    ContentType = "application/zip",
                    Hash = "323",
                    IdUsuario = 3,
                    Nombre = "NombreArchivo.zip"
                },
                new Archivo
                {
                    // Id = 4,
                    ContentType = "application/zip",
                    Hash = "789",
                    IdUsuario = 3,
                    Nombre = "NombreArchivo.zip"
                },
            };

            foreach (var archivo in materialApoyo)
            {
                context.ArchivoUsuario.Add(archivo);
                context.SaveChanges();
            }
        }

        private void SeedUsuario(RestApiCleanArchDbContext db)
        {
            var usuarios = new Usuario[]
            {
                new Usuario
                {
                    // Id = 1,
                    Email = "asd@asd.com",
                    NombreUsuario = "Admin",
                    TipoUsuario = Domain.Enums.TiposUsuario.Admin,
                    HashedPassword = "sha1:64000:18:GDo9HgM4Ke1BNgkIkvG1wlejZAS0qlpG:BPesev8ueqRpNVojKKcJMwDD",
                    Confirmado = true,
                    TokenConfirmacion = "",
                    Nombre = "Nombre",
                    ApellidoMaterno = "Apellido materno",
                    ApellidoPaterno = "Apellido paterno",
                    NormalizedEmail = "ASD@ASD.COM",
                    NormalizedUserName = "ADMIN"
                },
                new Usuario
                {
                    // Id = 2,
                    Email = "elvin@asd.com",
                    NombreUsuario = "User",
                    TipoUsuario = Domain.Enums.TiposUsuario.User,
                    HashedPassword = "sha1:64000:18:GDo9HgM4Ke1BNgkIkvG1wlejZAS0qlpG:BPesev8ueqRpNVojKKcJMwDD",
                    Confirmado = true,
                    TokenConfirmacion = "",
                    Nombre = "Nombre",
                    ApellidoMaterno = "Apellido materno",
                    ApellidoPaterno = "Apellido paterno",
                    NormalizedEmail = "ELVIN@ASD.COM",
                    NormalizedUserName = "ELVIN"
                },
                new Usuario
                {
                    // Id = 3,
                    Email = "termy@asd.com",
                    NombreUsuario = "Productor",
                    TipoUsuario = Domain.Enums.TiposUsuario.Productor,
                    HashedPassword = "sha1:64000:18:GDo9HgM4Ke1BNgkIkvG1wlejZAS0qlpG:BPesev8ueqRpNVojKKcJMwDD",
                    Confirmado = true,
                    TokenConfirmacion = "",
                    Nombre = "Nombre",
                    ApellidoMaterno = "Apellido materno",
                    ApellidoPaterno = "Apellido paterno",
                    NormalizedEmail = "TERMY@ASD.COM",
                    NormalizedUserName = "TERMY"
                },
                new Usuario
                {
                    // Id = 4,
                    Email = "Hola@asd2.com",
                    NombreUsuario = "Visor",
                    TipoUsuario = Domain.Enums.TiposUsuario.Visor,
                    HashedPassword = "sha1:64000:18:GDo9HgM4Ke1BNgkIkvG1wlejZAS0qlpG:BPesev8ueqRpNVojKKcJMwDD",
                    Confirmado = true,
                    TokenConfirmacion = "",
                    Nombre = "Nombre",
                    ApellidoMaterno = "Apellido materno",
                    ApellidoPaterno = "Apellido paterno",
                    NormalizedEmail = "HOLA@ASD2.COM",
                    NormalizedUserName = "HOLA"
                },
                new Usuario
                {
                    // Id = 5,
                    Email = "usuarioasasdadad@aasdassd2.com",
                    NombreUsuario = "Admin2",
                    TipoUsuario = Domain.Enums.TiposUsuario.Admin,
                    HashedPassword = "sha1:64000:18:GDo9HgM4Ke1BNgkIkvG1wlejZAS0qlpG:BPesev8ueqRpNVojKKcJMwDD",
                    Confirmado = false,
                    TokenConfirmacion = "123",
                    Nombre = "Nombre",
                    ApellidoMaterno = "Apellido materno",
                    ApellidoPaterno = "Apellido paterno",
                    NormalizedEmail = "USUARIOASASDADAD@AASDASSD2.COM",
                    NormalizedUserName = "ALGUIEN23"
                },
                new Usuario
                {
                    // Id = 6,
                    Email = "SOME@asdwe2.com",
                    NombreUsuario = "Admin3",
                    TipoUsuario = Domain.Enums.TiposUsuario.Admin,
                    HashedPassword = "sha1:64000:18:GDo9HgM4Ke1BNgkIkvG1wlejZAS0qlpG:BPesev8ueqRpNVojKKcJMwDD",
                    Confirmado = false,
                    TokenConfirmacion = "1234",
                    Nombre = "Nombre",
                    ApellidoMaterno = "Apellido materno",
                    ApellidoPaterno = "Apellido paterno",
                    NormalizedEmail = "SOME@ASDWE2.COM",
                    NormalizedUserName = "SOME123"
                },
                new Usuario
                {
                    // Id = 7,
                    Email = "alberto@ASD.com",
                    NombreUsuario = "Alberto",
                    TipoUsuario = Domain.Enums.TiposUsuario.User,
                    HashedPassword = "sha1:64000:18:GDo9HgM4Ke1BNgkIkvG1wlejZAS0qlpG:BPesev8ueqRpNVojKKcJMwDD",
                    Confirmado = true,
                    TokenConfirmacion = "12345",
                    Nombre = "Jose",
                    ApellidoMaterno = "Morelos",
                    ApellidoPaterno = "Espinosa",
                    NormalizedEmail = "ALBERTO@ASD.COM",
                    NormalizedUserName = "ALBERTO"
                },
            };

            foreach (var usuario in usuarios)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
            }
        }
        private void SeedReporte(RestApiCleanArchDbContext context)
        {
            var reportes = new Reporte[]
            {
                new Reporte
                {
                    Lugar="Cotija",
                    Productor="Miguel Hernandez Mendez",
                    Latitude=123.0,
                    Longitud=123.1,
                    Ubicacion="Cotija",
                    Predio="Joya del cupadero",
                    Cultivo="Aguacate",
                    Observaciones="La floracion aparecio adelantada al tiempo normal",
                    Litros=100,
                    Productos=new Producto[]
                    {
                        new Producto
                        {
                            NombreProducto="Producto 1",
                            IdReport=1,
                            IntervaloSeguridad="15 Dias",
                            Cantidad=100,
                            Unidad="Kg",
                            Concentracion="50%",
                            IngredienteActivo="Ingrediente Activo 1",
                        },
                        new Producto
                        {
                            NombreProducto="Producto 2",
                            IdReport=1,
                            IntervaloSeguridad="20 Dias",
                            Cantidad=50,
                            Unidad="Kg",
                            Concentracion="100%",
                            IngredienteActivo="Ingrediente Activo 2",
                        },
                        new Producto
                        {
                            NombreProducto="Producto 3",
                            IdReport=1,
                            IntervaloSeguridad="0 Dias",
                            Cantidad=10,
                            Unidad="Kg",
                            Concentracion="100%",
                            IngredienteActivo="Ingrediente Activo 3",
                        }
                    },
                    ReporteEnfermedad=new ReporteEnfermedad[]
                    {
                        new ReporteEnfermedad
                        {
                            IdEnfermedad=1,
                            IdReporte=1
                        },new ReporteEnfermedad
                        {
                            IdEnfermedad=2,
                            IdReporte=1
                        },new ReporteEnfermedad
                        {
                            IdEnfermedad=3,
                            IdReporte=1
                        }
                    },
                    ReporteEtapaFenologica=new ReporteEtapaFenologica[]
                    {
                        new ReporteEtapaFenologica
                        {
                            IdEtapaFenologica=1,
                            IdReporte=1
                        },
                        new ReporteEtapaFenologica
                        {
                            IdEtapaFenologica=2,
                            IdReporte=1
                        },
                        new ReporteEtapaFenologica
                        {
                            IdEtapaFenologica=3,
                            IdReporte=1
                        }
                    },
                    ReportePlaga=new ReportePlaga[]
                    {
                        new ReportePlaga
                        {
                            IdPlaga=1,
                            IdReporte=1
                        },
                        new ReportePlaga
                        {
                            IdPlaga=2,
                            IdReporte=1
                        },
                        new ReportePlaga
                        {
                            IdPlaga=3,
                            IdReporte=1
                        },
                    }
                },
                 new Reporte
                {
                    Lugar="Periban",
                    Productor="Juan Manuel Espinoza Mendez",
                    Latitude=154.0,
                    Longitud=12.1,
                    Ubicacion="Periban de ramos",
                    Predio="Pedregal",
                    Cultivo="Aguacate",
                    Observaciones="La floracion aparecio adelantada al tiempo normal",
                    Litros=500,
                    Productos=new Producto[]
                    {
                        new Producto
                        {
                            NombreProducto="Producto 1.0",
                            IdReport=2,
                            IntervaloSeguridad="16 Dias",
                            Cantidad=100,
                            Unidad="Kg",
                            Concentracion="60%",
                            IngredienteActivo="Ingrediente Activo 1.0",
                        },
                        new Producto
                        {
                            NombreProducto="Producto 2.0",
                            IdReport=2,
                            IntervaloSeguridad="26 Dias",
                            Cantidad=50,
                            Unidad="Kg",
                            Concentracion="90%",
                            IngredienteActivo="Ingrediente Activo 2.0",
                        },
                        new Producto
                        {
                            NombreProducto="Producto 3.0",
                            IdReport=2,
                            IntervaloSeguridad="0 Dias",
                            Cantidad=1,
                            Unidad="L",
                            Concentracion="1%",
                            IngredienteActivo="Ingrediente Activo 3.0",
                        }
                    },
                    ReporteEtapaFenologica=new ReporteEtapaFenologica[]
                    {
                        new ReporteEtapaFenologica
                        {
                            IdEtapaFenologica=1,
                            IdReporte=2
                        }
                    },
                    ReporteEnfermedad=new ReporteEnfermedad[]
                    {
                        new ReporteEnfermedad
                        {
                            IdEnfermedad=1,
                            IdReporte=2
                        },new ReporteEnfermedad
                        {
                            IdEnfermedad=2,
                            IdReporte=2
                        },new ReporteEnfermedad
                        {
                            IdEnfermedad=3,
                            IdReporte=2
                        }
                    },
                    ReportePlaga=new ReportePlaga[]
                    {
                        new ReportePlaga
                        {
                            IdPlaga=1,
                            IdReporte=2
                        },
                        new ReportePlaga
                        {
                            IdPlaga=2,
                            IdReporte=2
                        },
                        new ReportePlaga
                        {
                            IdPlaga=3,
                            IdReporte=2
                        },
                    }
                }
            };

            foreach (Reporte item in reportes)
            {
                context.Reporte.Add(item);
                context.SaveChanges();
            }
        }

    }
}
