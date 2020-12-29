using System;

namespace RestApiCleanArch.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public string Name { get; }
        public object Key { get; }
        public NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) was not found.")
        {
            this.Name = name;
            this.Key = key;
        }
    }
}
