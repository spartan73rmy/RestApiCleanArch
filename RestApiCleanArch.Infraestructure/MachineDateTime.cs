using RestApiCleanArch.Common;
using System;

namespace RestApiCleanArch.Infraestructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
