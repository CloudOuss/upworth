using System.Threading.Tasks;
using HtmlAgilityPack;
using NetworthDomain.Entities;

namespace NetworthInfrastructure.Dependencies.XpathProvider
{
    public class XpathProvider : IXpathProvider
    {
        //xpath constants
        public const string LatestClosePrice = "/html/body/div[2]/div[2]/div/div/div[2]/div/div/div[2]/div[1]/div[1]/p";
        public const string ProjectedDividendAnnualYield = "/html/body/div[2]/div[2]/div/div/div[2]/div/div/div[2]/div[2]/div[2]/span[2]";
        public const string TrailingDividendAnnualYield = "/html/body/div[2]/div[2]/div/div/div[2]/div/div/div[2]/div[2]/div[2]/span[4]";
        public const string DividendRate = "/html/body/div[2]/div[2]/div/div/div[2]/div/div/div[2]/div[2]/div[2]/span[10]";
        public const string DividendGrowth3YearsAverage = "/html/body/div[2]/div[2]/div/div/div[2]/div/div/div[2]/div[2]/div[2]/span[16]";
        public const string DividendGrowth10YearsAverage = "/html/body/div[2]/div[2]/div/div/div[2]/div/div/div[2]/div[2]/div[2]/span[18]";
        public const string DividendExDate = "/html/body/div[2]/div[2]/div/div/div[2]/div/div/div[2]/div[2]/div[3]/span[10]";
        public const string ConsecutiveDividendIncreases = "/html/body/div[2]/div[2]/div/div/div[2]/div/div/div[2]/div[2]/div[2]/span[22]";
        public const string Sector = "/html/body/div[2]/div[2]/div/div/div[2]/div/div/div[2]/div[1]/div[3]/p/a[1]";
        public const string Segment = "/html/body/div[2]/div[2]/div/div/div[2]/div/div/div[2]/div[1]/div[3]/p/a[2]";
        public const string Industry = "/html/body/div[2]/div[2]/div/div/div[2]/div/div/div[2]/div[1]/div[3]/p/a[3]";
        //

        public async Task<Security> GetSecurityDetailsAsync(string ticker)
        {
            var browser = new HtmlWeb();
            var doc = await browser.LoadFromWebAsync($"https://www.dividendinvestor.com/dividend-quote/{ticker}/");
            var latestClosePrice = doc.DocumentNode.SelectSingleNode(LatestClosePrice)?.InnerText;
            var projectedDividendAnnualYield = doc.DocumentNode.SelectSingleNode(ProjectedDividendAnnualYield)?.InnerText;
            var trailingDividendAnnualYield = doc.DocumentNode.SelectSingleNode(TrailingDividendAnnualYield)?.InnerText;
            var dividendRate = doc.DocumentNode.SelectSingleNode(DividendRate)?.InnerText;
            var dividendGrowth3YearsAverage = doc.DocumentNode.SelectSingleNode(DividendGrowth3YearsAverage)?.InnerText;
            var dividendGrowth10YearsAverage = doc.DocumentNode.SelectSingleNode(DividendGrowth10YearsAverage)?.InnerText;
            var dividendExDate = doc.DocumentNode.SelectSingleNode(DividendExDate)?.InnerText;
            var consecutiveDividendIncreases = doc.DocumentNode.SelectSingleNode(ConsecutiveDividendIncreases)?.InnerText;
            var sector = doc.DocumentNode.SelectSingleNode(Sector)?.InnerText;
            var segment = doc.DocumentNode.SelectSingleNode(Segment)?.InnerText;
            var industry = doc.DocumentNode.SelectSingleNode(Industry)?.InnerText;

            return new Security(ticker, GetIndustryValue(sector, segment, industry), latestClosePrice, dividendRate,
                projectedDividendAnnualYield, trailingDividendAnnualYield, dividendGrowth3YearsAverage,
                dividendGrowth10YearsAverage, dividendExDate, consecutiveDividendIncreases);
        }

        private static int GetIndustryValue(string sector, string segment, string industry)
        {
            return NetworthDomain.Enums.Industry.Financials.Value;
        }
    }
}