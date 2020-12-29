using RestApiCleanArch.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.Usuarios.Queries.GetImagenPerfil
{
    public class GetImagenPerfilHandler : IRequestHandler<GetImagenPerfilQuery, GetImagenPerfilResponse>
    {
        private readonly IRestApiCleanArchDbContext db;
        private readonly IFileService fileService;
        private readonly IAvatarService avatarService;

        public GetImagenPerfilHandler(IRestApiCleanArchDbContext db, IFileService fileService, IAvatarService avatarService)
        {
            this.db = db;
            this.fileService = fileService;
            this.avatarService = avatarService;
        }

        public async Task<GetImagenPerfilResponse> Handle(GetImagenPerfilQuery request, CancellationToken cancellationToken)
        {
            var fotoPerfil = await db
                .Usuario
                .Where(el => el.NormalizedUserName == request.NombreUsuario.ToUpper())
                .Select(el => new { el.ImagenPerfil, el.NombreUsuario })
                .SingleOrDefaultAsync();

            if (fotoPerfil == null)
            {
                return null;
            }

            if (fotoPerfil.ImagenPerfil == null)
            {
                return new GetImagenPerfilResponse
                {
                    Imagen = avatarService.DefaultAvatar(request.Size),
                    ContentType = "image/jpg"
                };
            }

            if (!avatarService.Exists(fotoPerfil.ImagenPerfil, request.Size))
            {
                using (var strea = fileService.GetStreamFile(fotoPerfil.ImagenPerfil))
                {
                    avatarService.Genera(strea, fotoPerfil.ImagenPerfil, request.Size);
                }
            }

            var stream = avatarService.Get(fotoPerfil.ImagenPerfil, request.Size);

            return new GetImagenPerfilResponse
            {
                Imagen = stream,
                ContentType = "image/jpg"
            };
        }
    }
}