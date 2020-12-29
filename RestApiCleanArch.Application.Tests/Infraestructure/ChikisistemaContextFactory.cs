using RestApiCleanArch.Domain.Entities;
using RestApiCleanArch.Infraestructure;
using RestApiCleanArch.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace RestApiCleanArch.Application.Tests.Infraestructure
{
    public class RestApiCleanArchDbContextFactory
    {
        public static RestApiCleanArchDbContext Create()
        {
            var options = new DbContextOptionsBuilder<RestApiCleanArchDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new RestApiCleanArchDbContext(options, new MachineDateTime());

            context.Database.EnsureCreated();
            context.Usuario.AddRange(new[] {
                new Usuario { Id = 1, NombreUsuario = "Admin", TipoUsuario = Domain.Enums.TiposUsuario.Admin, Email = "asd@asd.com"},
            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(RestApiCleanArchDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
