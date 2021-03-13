using System;

namespace NetworthDomain.Common
{
    public abstract class AuditableEntity
    {
        public DateTime Created { get; set; }

        public Guid UserId { get; set; }

        public DateTime? LastModified { get; set; }
    }
}
