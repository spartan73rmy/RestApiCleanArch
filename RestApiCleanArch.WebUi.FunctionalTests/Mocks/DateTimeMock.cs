using RestApiCleanArch.Common;
using System;

namespace RestApiCleanArch.WebUi.FunctionalTests.Mocks
{
    public class DateTimeMock : IDateTime
    {
        public DateTimeMock(DateTime time)
        {
            this.Now = time;
        }

        public DateTime Now { get; private set; }

        public void Add(TimeSpan toAdd)
        {
            Now = Now.Add(toAdd);
        }

    }
}
