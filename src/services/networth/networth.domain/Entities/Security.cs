using NetworthDomain.Enums;

namespace NetworthDomain.Entities
{
    public class Security
    {
        public string Ticker { get; set; }
        public Industry Industry { get; set; }
        public string LatestClosePrice { get; set; }
        public string DividendRate { get; set; }
        public string ProjectedDividendAnnualYield { get; set; }
        public string TrailingDividendAnnualYield { get; set; }
        public string DividendGrowth3YearsAverage { get; set; }
        public string DividendGrowth5YearsAverage { get; set; }
        public string DividendExDate { get; set; }
        public string DividendPayDate { get; set; }
        public string ConsecutiveDividendIncreases { get; set; }

        protected Security()
        {

        }

        public Security(string ticker, int industryValue, string latestClosePrice, string dividendRate, string projectedDividendAnnualYield, string trailingDividendAnnualYield, string dividendGrowth3YearsAverage, 
            string dividendGrowth5YearsAverage, string dividendExDate, string consecutiveDividendIncreases, string dividendPayDate)
        {
            Ticker = ticker;
            LatestClosePrice = latestClosePrice;
            DividendRate = dividendRate;
            ProjectedDividendAnnualYield = projectedDividendAnnualYield;
            TrailingDividendAnnualYield = trailingDividendAnnualYield;
            DividendGrowth3YearsAverage = dividendGrowth3YearsAverage;
            DividendGrowth5YearsAverage = dividendGrowth5YearsAverage;
            DividendExDate = dividendExDate;
            DividendPayDate = dividendPayDate;
            ConsecutiveDividendIncreases = consecutiveDividendIncreases;
            Industry = AbstractEnumeration.FromValue<Industry>(industryValue);
        }
    }
}
