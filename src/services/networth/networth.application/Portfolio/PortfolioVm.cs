using System.Collections.Generic;
using NetworthApplication.Holdings;

namespace NetworthApplication.Portfolio
{
    public class PortfolioVm
    {
        public List<HoldingVm> Holdings { get; set; }
        public int TotalShares { get; set; }
        public double TotalAverageCost { get; set; }
        public double TotalCostBasis { get; set; }
        public double TotalMarketValue { get; set; }
        public double TotalGainLoss { get; set; }
        public double TotalGainLossPercent { get; set; }
    }
}