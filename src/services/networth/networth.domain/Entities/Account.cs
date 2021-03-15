using System;
using System.Collections.Generic;
using NetworthDomain.Common;
using NetworthDomain.Enums;

namespace NetworthDomain.Entities
{
    public class Account : AuditableEntity, IHasDomainEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AccountType AccountType { get; set; }
        public IList<Holding> Holdings { get; private set; } = new List<Holding>();

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
