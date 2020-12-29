using RestApiCleanArch.Application.Tests.Infraestructure;
using System;

namespace RestApiCleanArch.Application.Tests
{
    public class TestBase : IDisposable
    {
        protected readonly Persistence.RestApiCleanArchDbContext context;
        public TestBase()
        {
            context = RestApiCleanArchDbContextFactory.Create();
        }

        public void Dispose()
        {
            RestApiCleanArchDbContextFactory.Destroy(context);
        }
    }
}
