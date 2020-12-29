using System;

namespace RestApiCleanArch.Domain
{
    public class DeleteableEntity : BaseEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
