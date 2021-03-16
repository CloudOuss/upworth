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
        public int AccountTypeId { get; private set; }
        public AccountType AccountType { get; private set; }
        public int InstitutionId { get; private set; }
        public Institution Institution { get; private set; }
        public IList<Holding> Holdings { get; private set; }

        protected Account()
        {
            
        }

        public Account(string name, Institution institution, AccountType accountType)
        {
            Name = name;
            AccountType = accountType;
            Institution = institution;

            AccountTypeId = AccountType.Value;
            InstitutionId = Institution.Value;

            Holdings = new List<Holding>();
        }

        public void SetInstitution(Institution institution)
        {
            Institution = institution;
            InstitutionId = Institution.Value;
        }

        public void SetAccountType(AccountType accountType)
        {
            AccountType = accountType;
            AccountTypeId = AccountType.Value;
        }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
