using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Plagas.Commands.AgregarPlaga
{
    public class AgregarPlagaHandler : IRequestHandler<AgregarPlagaCommand, AgregarPlagaResponse>
    {
        private readonly IRestApiCleanArchDbContext db;

        public AgregarPlagaHandler(IRestApiCleanArchDbContext db)
        {
            this.db = db;
        }

        public async Task<AgregarPlagaResponse> Handle(AgregarPlagaCommand request, CancellationToken cancellationToken)
        {
            //Search if exist a Plaga with equals or similar name
            string nombre = NormalizeString(request.Nombre);
            Plaga oldPlaga = await
                db.Plaga.Where(el =>
                el.Nombre.Replace(" ", "").ToLower().Equals(nombre))
                .FirstOrDefaultAsync();

            if (oldPlaga == null)
            {
                Plaga newPlaga = new Plaga
                {
                    Nombre = request.Nombre
                };
                db.Plaga.Add(newPlaga);
            }
            else
            {
                oldPlaga.IsDeleted = false;
                oldPlaga.DeletedDate = null;
            }
            await db.SaveChangesAsync(cancellationToken);

            return new AgregarPlagaResponse();
        }
        private string NormalizeString(string toNormalize)
        {
            return NormalizeString(new[] { " ", ".", "," }, toNormalize);
        }
        private string NormalizeString(string[] charsToDelete, string toNormalize)
        {
            foreach (string item in charsToDelete)
            {
                toNormalize = toNormalize.Replace(
                   item, newValue: string.Empty);
            }
            return toNormalize.ToLower();
        }
    }
}
