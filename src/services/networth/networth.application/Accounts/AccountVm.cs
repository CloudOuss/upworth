using System;
using AutoMapper;
using NetworthApplication.Common.Mappings;
using NetworthDomain.Entities;

namespace NetworthApplication.Accounts
{
 

    public class AccountVm : IMapFrom<Account>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AccountType { get; set; }
        public string Institution { get; set; }
        public int AccountTypeId { get; set; }
        public int InstitutionId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Account, AccountVm>()
                .ForMember(d => d.Institution, opt => opt.MapFrom(s => s.Institution.Name))
                .ForMember(d => d.AccountType, opt => opt.MapFrom(s => s.AccountType.Name));
        }
    }
}