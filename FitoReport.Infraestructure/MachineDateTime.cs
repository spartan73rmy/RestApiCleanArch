using FitoReport.Common;
using System;

namespace FitoReport.Infraestructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
