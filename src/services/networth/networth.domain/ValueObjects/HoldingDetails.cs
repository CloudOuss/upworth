using System.Collections.Generic;
using NetworthDomain.Common;
using NetworthDomain.Enums;

namespace NetworthDomain.ValueObjects
{
    public class HoldingDetails : ValueObject
    {
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

        protected HoldingDetails()
        {

        }

        public HoldingDetails(int industryValue, string latestClosePrice, string dividendRate, string projectedDividendAnnualYield, string trailingDividendAnnualYield, string dividendGrowth3YearsAverage, 
            string dividendGrowth5YearsAverage, string dividendExDate, string consecutiveDividendIncreases, string dividendPayDate)
        {
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

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Industry;
            yield return LatestClosePrice;
            yield return DividendRate;
            yield return ProjectedDividendAnnualYield;
            yield return TrailingDividendAnnualYield;
            yield return DividendGrowth3YearsAverage;
            yield return DividendGrowth5YearsAverage;
            yield return DividendExDate;
            yield return DividendPayDate;
            yield return ConsecutiveDividendIncreases;
        }
    }
}
