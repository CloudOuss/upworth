using System;
using System.Text.Json.Serialization;
using AutoMapper;
using NetworthApplication.Common.Mappings;
using NetworthDomain.Entities;

namespace NetworthApplication.Holdings
{
 

    public class HoldingVm : IMapFrom<Holding>
    {
        public Guid Id { get; set; }
        public string Ticker { get; set; }
        public double BuyPrice { get; set; }
        public int SharesNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        [JsonPropertyName("holdingDetails")]
        public HoldingDetailsDto HoldingDetails { get; private set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Holding, HoldingVm>()
                .ForMember(d => d.PurchaseDate, opt => opt.MapFrom(s => s.Created));
        }
    }
}