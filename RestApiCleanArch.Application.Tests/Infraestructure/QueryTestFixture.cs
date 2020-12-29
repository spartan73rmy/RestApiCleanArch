
using RestApiCleanArch.Persistence;
using System;
using Xunit;

namespace RestApiCleanArch.Application.Tests.Infraestructure
{
    public class QueryTestFixture : IDisposable
    {
        public RestApiCleanArchDbContext Context { get; private set; }

        public QueryTestFixture()
        {
            Context = RestApiCleanArchDbContextFactory.Create();
        }

        public void Dispose()
        {
            RestApiCleanArchDbContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
