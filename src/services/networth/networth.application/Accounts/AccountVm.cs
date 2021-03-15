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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Account, AccountVm>()
                .ForMember(d => d.AccountType, opt => opt.MapFrom(s => s.AccountType.Name));
        }
    }
}