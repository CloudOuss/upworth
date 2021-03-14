using AutoMapper;
using NetworthApplication.Common.Mappings;
using NetworthDomain.ValueObjects;

namespace NetworthApplication.Holdings
{
    public class HoldingDetailsDto: IMapFrom<HoldingDetails>
    {
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
            profile.CreateMap<HoldingDetails, HoldingDetailsDto>()
                .ForMember(d => d.Industry, opt => opt.MapFrom(s => s.Industry.Name));
        }
    }
}