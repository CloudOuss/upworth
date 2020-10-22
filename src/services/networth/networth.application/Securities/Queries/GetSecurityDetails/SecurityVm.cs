
using AutoMapper;
using NetworthApplication.Common.Mappings;
using NetworthApplication.TodoLists.Queries.GetTodos;
using NetworthDomain.Entities;

namespace NetworthApplication.Securities.Queries.GetSecurityDetails
{
    public class SecurityVm : IMapFrom<Security>
    {
        public string Ticker { get; set; }
        public string Industry { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Security, SecurityVm>()
                .ForMember(d => d.Industry, opt => opt.MapFrom(s => s.Industry.Name));
        }
    }
}
