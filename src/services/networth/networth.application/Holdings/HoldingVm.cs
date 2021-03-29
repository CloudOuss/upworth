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
        public double PurchasePrice { get; set; }
        public int Shares { get; set; }
        public Guid AccountId { get; set; }
        public string Account { get; set; }
        public DateTime PurchaseDate { get; set; }
        [JsonPropertyName("holdingDetails")]
        public HoldingDetailsDto HoldingDetails { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Holding, HoldingVm>()
                .ForMember(d => d.PurchaseDate, opt => opt.MapFrom(s => s.Created))
                .ForMember(d => d.Account, opt => opt.MapFrom(s => s.Account.Name))
                .ForMember(d => d.AccountId, opt => opt.MapFrom(s => s.Account.Id));
        }
    }
}