using AutoMapper;
using NetworthApplication.Common.Mappings;
using NetworthDomain.Entities;
using NetworthDomain.ValueObjects;

namespace NetworthApplication.Securities.Queries.GetSecurityDetails
{
    public class SecurityVm : IMapFrom<HoldingDetails>
    {
        public string Ticker { get; set; }
        public string Industry { get; set; }
        public string LatestClosePrice { get; set; }
        public string DividendRate { get; set; }
        public string ProjectedDividendAnnualYield { get; set; }
        public string TrailingDividendAnnualYield { get; set; }
        public string DividendGrowth3YearsAverage { get; set; }
        public string DividendGrowth5YearsAverage { get; set; }
        public string DividendExDate { get; set; }
        public string DividendPayDate { get; set; }
        public string ConsecutiveDividendIncreases { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HoldingDetails, SecurityVm>()
                .ForMember(d => d.Industry, opt => opt.MapFrom(s => s.Industry.Name));
        }
    }
}
