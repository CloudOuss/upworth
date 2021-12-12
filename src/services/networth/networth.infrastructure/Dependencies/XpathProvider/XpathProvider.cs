using System.Threading.Tasks;
using HtmlAgilityPack;
using NetworthDomain.ValueObjects;

namespace NetworthInfrastructure.Dependencies.XpathProvider
{
    public class XpathProvider : IXpathProvider
    {
        //xpath constants
        public const string LatestClosePrice = "/html/body/div[2]/div[1]/div/div/div/div[2]/div/div/div[2]/div[1]/div[1]/p";
        public const string ProjectedDividendAnnualYield = "/html/body/div[2]/div[1]/div/div/div/div[2]/div/div/div[2]/div[2]/div[2]/span[2]";
        public const string TrailingDividendAnnualYield = "/html/body/div[2]/div[1]/div/div/div/div[2]/div/div/div[2]/div[2]/div[2]/span[4]";
        public const string DividendRate = "/html/body/div[2]/div[1]/div/div/div/div[2]/div/div/div[2]/div[2]/div[2]/span[10]";
        public const string DividendGrowth3YearsAverage = "/html/body/div[2]/div[1]/div/div/div/div[2]/div/div/div[2]/div[2]/div[2]/span[16]";
        public const string DividendGrowth5YearsAverage = "/html/body/div[2]/div[1]/div/div/div/div[2]/div/div/div[2]/div[2]/div[2]/span[18]";
        public const string DividendExDate = "/html/body/div[2]/div[1]/div/div/div/div[2]/div/div/div[2]/div[2]/div[3]/span[10]";
        public const string DividendPayDate = "/html/body/div[2]/div[1]/div/div/div/div[2]/div/div/div[2]/div[2]/div[3]/span[14]";
        public const string ConsecutiveDividendIncreases = "/html/body/div[2]/div[1]/div/div/div/div[2]/div/div/div[2]/div[2]/div[2]/span[22]";
        public const string Sector = "/html/body/div[2]/div[1]/div/div/div/div[2]/div/div/div[2]/div[1]/div[3]/p/a[1]";
        public const string Segment = "/html/body/div[2]/div[1]/div/div/div/div[2]/div/div/div[2]/div[1]/div[3]/p/a[2]";
        public const string Industry = "/html/body/div[2]/div[1]/div/div/div/div[2]/div/div/div[2]/div[1]/div[3]/p/a[3]";
        //

        public async Task<HoldingDetails> GetSecurityDetailsAsync(string ticker)
        {
            var browser = new HtmlWeb();
            var doc = await browser.LoadFromWebAsync($"https://www.dividendinvestor.com/dividend-quote/{ticker}/");
            var latestClosePrice = doc.DocumentNode.SelectSingleNode(LatestClosePrice)?.InnerText;
            var projectedDividendAnnualYield = doc.DocumentNode.SelectSingleNode(ProjectedDividendAnnualYield)?.InnerText;
            var trailingDividendAnnualYield = doc.DocumentNode.SelectSingleNode(TrailingDividendAnnualYield)?.InnerText;
            var dividendRate = doc.DocumentNode.SelectSingleNode(DividendRate)?.InnerText;
            var dividendGrowth3YearsAverage = doc.DocumentNode.SelectSingleNode(DividendGrowth3YearsAverage)?.InnerText;
            var dividendGrowth5YearsAverage = doc.DocumentNode.SelectSingleNode(DividendGrowth5YearsAverage)?.InnerText;
            var dividendExDate = doc.DocumentNode.SelectSingleNode(DividendExDate)?.InnerText;
            var dividendPayDate = doc.DocumentNode.SelectSingleNode(DividendPayDate)?.InnerText;
            var consecutiveDividendIncreases = doc.DocumentNode.SelectSingleNode(ConsecutiveDividendIncreases)?.InnerText;
            var sector = doc.DocumentNode.SelectSingleNode(Sector)?.InnerText;

            return new HoldingDetails(GetIndustryValue(sector), latestClosePrice, dividendRate,
                projectedDividendAnnualYield, trailingDividendAnnualYield, dividendGrowth3YearsAverage,
                dividendGrowth5YearsAverage, dividendExDate, consecutiveDividendIncreases, dividendPayDate);
        }

        private static int GetIndustryValue(string sector)
        {
            NetworthDomain.Enums.Industry industry;
            return NetworthDomain.Enums.Industry.TryGetFromValueOrName(sector, out industry)
                ? industry.Value
                : NetworthDomain.Enums.Industry.NotApplicable.Value;
        }
    }
}
