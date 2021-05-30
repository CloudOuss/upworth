using System;
using System.Collections.Generic;
using NetworthDomain.Common;
using NetworthDomain.Enums;

namespace NetworthDomain.ValueObjects
{
    public class PositionDetails : ValueObject
    {
        public Industry Industry { get; set; }
        public double LatestClosePrice { get; set; }
        public double DividendRate { get; set; }
        public double ProjectedDividendAnnualYield { get; set; }
        public double TrailingDividendAnnualYield { get; set; }
        public double DividendGrowth3YearsAverage { get; set; }
        public double DividendGrowth5YearsAverage { get; set; }
        public DateTime DividendExDate { get; set; }
        public DateTime DividendPayDate { get; set; }
        public string ConsecutiveDividendIncreases { get; set; }

        protected PositionDetails()
        {
        }

        public PositionDetails(int industryValue, string latestClosePrice, string dividendRate, string projectedDividendAnnualYield, string trailingDividendAnnualYield, string dividendGrowth3YearsAverage, 
            string dividendGrowth5YearsAverage, string dividendExDate, string consecutiveDividendIncreases, string dividendPayDate)
        {
            LatestClosePrice = MathUtils.DoubleParse(latestClosePrice);
            DividendRate =  MathUtils.DoubleParse(dividendRate);
            ProjectedDividendAnnualYield =  MathUtils.DoubleParse(projectedDividendAnnualYield);
            TrailingDividendAnnualYield =  MathUtils.DoubleParse(trailingDividendAnnualYield);
            DividendGrowth3YearsAverage =  MathUtils.DoubleParse(dividendGrowth3YearsAverage);
            DividendGrowth5YearsAverage =  MathUtils.DoubleParse(dividendGrowth5YearsAverage);
            DividendExDate =  DateTime.Parse(dividendExDate);
            DividendPayDate = DateTime.Parse(dividendPayDate);
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