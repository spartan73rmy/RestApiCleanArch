
using FitoReport.Persistence;
using System;
using Xunit;

namespace FitoReport.Application.Tests.Infraestructure
{
    public class QueryTestFixture : IDisposable
    {
        public FitoReportDbContext Context { get; private set; }

        public QueryTestFixture()
        {
            Context = FitoReportDbContextFactory.Create();
        }

        public void Dispose()
        {
            FitoReportDbContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
