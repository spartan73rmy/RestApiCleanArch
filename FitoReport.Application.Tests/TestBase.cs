using FitoReport.Application.Tests.Infraestructure;
using System;

namespace FitoReport.Application.Tests
{
    public class TestBase : IDisposable
    {
        protected readonly Persistence.FitoReportDbContext context;
        public TestBase()
        {
            context = FitoReportDbContextFactory.Create();
        }

        public void Dispose()
        {
            FitoReportDbContextFactory.Destroy(context);
        }
    }
}
