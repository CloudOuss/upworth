using System;

namespace NetworthDomain.Common
{
    public abstract class AuditableEntity
    {
        public DateTime Created { get; set; }

        public string UserId { get; set; }

        public DateTime? LastModified { get; set; }
    }
}
