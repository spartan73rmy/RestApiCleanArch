using RestApiCleanArch.Application.Tests.Infraestructure;
using RestApiCleanArch.Application.UseCases.Usuarios.Queries.GetUsuarioDetail;
using RestApiCleanArch.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace RestApiCleanArch.Application.Tests.Usuarios.Queries
{
    [Collection("QueryCollection")]
    public class GetUsuarioDetailQueryHandlerTests
    {
        private readonly RestApiCleanArchDbContext _context;

        public GetUsuarioDetailQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task GetUsuarioDetail()
        {
            var sut = new GetUsuarioDetailHandler(_context);

            var result = await sut.Handle(new GetUsuarioDetailQuery { IdUsuario = 1 }, CancellationToken.None);

            result.ShouldBeOfType<GetUsuarioDetailResponse>();
            result.IdUsuario.ShouldBe(1);
        }
    }
}
