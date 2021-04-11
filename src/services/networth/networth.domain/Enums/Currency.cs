namespace NetworthDomain.Enums
{
    public class Currency : AbstractEnumeration
    {
        public static readonly Currency Usd = new Currency(1, "USD");
        public static readonly Currency Cad = new Currency(2, "CAD");

        public Currency(int id, string name)
            : base(id, name)
        {
        }

        public Currency() : base()
        {
            
        }
    }
}