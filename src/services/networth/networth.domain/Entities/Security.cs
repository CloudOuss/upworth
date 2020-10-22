using NetworthDomain.Enums;

namespace NetworthDomain.Entities
{
    public class Security
    {
        public string Ticker { get; set; }
        public Industry Industry { get; set; }

        protected Security()
        {
            
        }

        public Security(string ticker, int industryValue)
        {
            Ticker = ticker;
            Industry = AbstractEnumeration.FromValue<Industry>(industryValue);
        }
    }
}
